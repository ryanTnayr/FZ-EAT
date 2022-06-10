using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FZ_POS
{
    public partial class FormShopMenu : Form
    {
        string sel_meal_id = "";
        string strMealName = "";
        int intMealPrice = 0;
        int intSelIndex = 0;
        bool isModify = false;
        bool isAddMeal = false;
        DataTable dt;
        List<object> listSideContain = new List<object>();
        List<object> listOriginalSideContain = new List<object>();

        public FormShopMenu()
        {
            InitializeComponent();
        }

        private void FormShopMenu_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'fzDBDataSet1.shop_side_dtl' 資料表。您可以視需要進行移動或移除。
            this.shop_side_dtlTableAdapter.FillBy(this.fzDBDataSet1.shop_side_dtl);
            loadDgv();
        }

        void loadDgv()
        {
            dgvMenuList.AutoSize = true;
            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
            con.Open();
            string strSQL = "select * from shop_list_meal where user_id = @user_id and is_use = 1";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue(@"user_id", GlobalVar.SHOP_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                dgvMenuList.Rows.Add(reader["meal"], reader["price"]);
                dgvMenuList.Rows[i].Tag = reader["meal_id"];
                i++;
            }
            dgvMenuList.Size = new Size(700, dgvMenuList.RowCount * 32 - (dgvMenuList.RowCount - 1));  //不知為何最後會有一行沒有資料  dgvMenuList.RowCount * 29 就會看到
            dgvMenuList.ClearSelection();

            btnAddMeal.Location = new Point(30, 80 + dgvMenuList.RowCount * 32 - (dgvMenuList.RowCount - 1) + 10);
            reader.Close();
            con.Close();

            SqlConnection con1 = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
            con1.Open();
            dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT DISTINCT side_group_id, side_group_name FROM  shop_side_dtl WHERE user_id =" + GlobalVar.SHOP_ID, con1);
            adp.Fill(dt);
            con1.Close();
        }

        private void dgvMenuList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (isModify == true)
            {
                DialogResult r;
                r = MessageBox.Show("Give up the changes?", "Warning", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    showMealDtl(e);
                    //isInsert = false;
                }
                else if (r == DialogResult.No)
                {
                    dgvMenuList.ClearSelection();
                    dgvMenuList.Rows[intSelIndex].Selected = true;
                }
            }
            else
            {
                showMealDtl(e);
            }
        }

        void showMealDtl(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;  // 修正若點到 header 所出現的錯誤
            listSideContain.Clear();
            listOriginalSideContain.Clear();
            intSelIndex = e.RowIndex;
            btnSave.ForeColor = Color.Silver;
            isModify = false;
            isAddMeal = false;
            flpSide.Controls.Clear();
            pnlSide.Visible = true;
            sel_meal_id = (string)dgvMenuList.Rows[e.RowIndex].Tag;

            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True; MultipleActiveResultSets = true");
            con.Open();
            string strSQL = "select * from shop_list_meal where user_id = @user_id and meal_id = @meal_id";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue(@"user_id", GlobalVar.SHOP_ID);
            cmd.Parameters.AddWithValue(@"meal_id", sel_meal_id);
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = string.Format("{0}", reader["meal"]);
                txtPrice.Text = string.Format("{0}", reader["price"]);

                strMealName = string.Format("{0}", reader["meal"]);
                intMealPrice = (int)reader["price"];
            }
            reader.Close();

            strSQL = "select * from shop_meal_side where user_id = @user_id and meal_id = @meal_id";
            cmd.CommandText = strSQL;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ucSideLabel ucSL = new ucSideLabel();
                ucSL.lblSide.Text = (string)reader["side_group_name"];
                ucSL.cbtnCancel.Click += CbtnCancel_Click;
                ucSL.cbtnCancel.Tag = reader["side_group_id"];
                listSideContain.Add(reader["side_group_id"]);
                listOriginalSideContain.Add(reader["side_group_id"]);
                flpSide.Controls.Add(ucSL);
            }

            Button btn = new Button();
            btn.Font = new Font("新細明體", 18.0f, FontStyle.Bold);
            btn.Text = "┼";
            btn.FlatStyle = FlatStyle.Flat;
            btn.TabStop = false;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = SystemColors.Control;
            btn.AutoSize = false;
            btn.Size = new Size(30, 30);
            btn.Click += BtnAddSide_Click;
            flpSide.Controls.Add(btn);

            reader.Close();
            con.Close();
        }
        private void BtnAddSide_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ComboBox cbox = new ComboBox();
            cbox.Font = new Font("Segoe UI", 12.0f);
            cbox.Size = new Size(100, 29);

            if (dt.Rows.Count > 0)
            {
                cbox.DataSource = dt;
                cbox.DisplayMember = "side_group_name";
                cbox.ValueMember = "side_group_id";
            }

            cbox.SelectionChangeCommitted += Cbox_SelectionChangeCommitted;
            flpSide.Controls.Add(cbox);
            flpSide.Controls.SetChildIndex(btn, flpSide.Controls.GetChildIndex(cbox) + 1);
            
        }

        private void Cbox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cbox = (ComboBox)sender;
            if (!listSideContain.Contains(cbox.SelectedValue))
            {
                ucSideLabel ucSL = new ucSideLabel();
                ucSL.lblSide.Text = cbox.Text;
                ucSL.cbtnCancel.Tag = cbox.SelectedValue;
                ucSL.cbtnCancel.Click += CbtnCancel_Click;
                flpSide.Controls.Add(ucSL);
                flpSide.Controls.SetChildIndex(ucSL, flpSide.Controls.IndexOf(ucSL) - 1);
                
                listSideContain.Add(cbox.SelectedValue);

                flpSide.Controls.Remove(cbox);
                if (txtName.Text == strMealName && txtPrice.Text == intMealPrice.ToString() && listOriginalSideContain.Intersect(listSideContain).ToList().Count == listOriginalSideContain.Count)
                { 
                    isModify = false;
                    btnSave.ForeColor = Color.Silver;
                }
                else
                {
                    isModify = true;
                    btnSave.ForeColor = Color.FromArgb(6, 193, 103);
                    
                }
            }
            else
            {
                MessageBox.Show("This meal alreay have this side.");
            }
           
           
        }



        private void CbtnCancel_Click(object sender, EventArgs e)
        {
            
            CircleButton cbtn = (CircleButton)sender;
            listSideContain.Remove(cbtn.Tag);
            flpSide.Controls.Remove(cbtn.Parent.Parent);
            if (txtName.Text == strMealName && txtPrice.Text == intMealPrice.ToString() && listOriginalSideContain.Intersect(listSideContain).ToList().Count == listOriginalSideContain.Count)
            {
                isModify = false;
                btnSave.ForeColor = Color.Silver;
            }
            else
            {
                isModify = true;
                btnSave.ForeColor = Color.FromArgb(6, 193, 103);
            }
        }

        private void btnCloseSidePanel_Click(object sender, EventArgs e)
        {
            if (isModify == true)
            {
                DialogResult r;
                r = MessageBox.Show("Give up the changes?", "Warning", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    pnlSide.Visible = false;
                    isModify = false;
                    //isInsert = false;
                }
                else if (r == DialogResult.No)
                {

                }
            }
            else
            {
                pnlSide.Visible = false;
            }
            isAddMeal = false;
        }

        private void dgvMenuList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvMenuList.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Control;
            }
        }

        private void dgvMenuList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvMenuList.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                dgvMenuList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.WindowText;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL;
            if (isModify == true)
            {
                DialogResult r;
                r = MessageBox.Show("Ready to save all?", "Warning", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    //取得編碼
                    int id_num = 0;
                    SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True; MultipleActiveResultSets = true");
                    con.Open();
                    strSQL = "DECLARE @id_num int;" +
                              "select  @id_num = count (meal_id)+1  from shop_list_meal; " +
                              "select @id_num";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id_num = reader.GetInt32(0);
                    }
                    reader.Close();
                    if (isAddMeal == false)
                    {// update is_use
                        strSQL = "UPDATE shop_list_meal set is_use = 0 where meal_id = '" + sel_meal_id + "'";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                    }
                    
                    // insert meal
                    strSQL = "INSERT shop_list_meal VALUES ( @user_id, 'A0" + id_num + "' , @meal,  @price ,default)";
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue(@"user_id", GlobalVar.SHOP_ID);
                    cmd.Parameters.AddWithValue(@"meal", txtName.Text);
                    int p = 0;
                    Int32.TryParse(txtPrice.Text, out p);
                    cmd.Parameters.AddWithValue(@"price", p);
                    cmd.ExecuteNonQuery();
                    // insert side
                    for (int i = 0; i < listSideContain.Count; i++)
                    {
                        DataRow[] dr = dt.Select("side_group_id = '" + (string)listSideContain[i] + "' ");  //利用前面的 Datatable dt 作為 dictionary 的功用，以 side_id 找到 side_name
                        strSQL =
                             "INSERT shop_meal_side (user_id , meal_id , side_group_id , side_group_name) " +
                             "VALUES( '" + GlobalVar.SHOP_ID + "','A0" + id_num + "','" +
                               (string)listSideContain[i] + "','" + dr[0].ItemArray[1] + "')";  //(user_id , meal_id , side_id , side_name)
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                    }
                 
                    con.Close();
                    isModify = false;
                    isAddMeal = false;
                    btnSave.ForeColor = Color.Silver;
                    pnlSide.Visible = false;
                    dgvMenuList.Rows.Clear();
                    loadDgv();
                    //以下可有可無，做了以防會有其他沒有預期的錯誤
                    strMealName = "";
                    intMealPrice = 0;
                }
                else if (r == DialogResult.No)
                {

                } 
            }
            else
            {
                
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == strMealName && txtPrice.Text == intMealPrice.ToString() && listOriginalSideContain.Intersect(listSideContain).ToList().Count == listOriginalSideContain.Count)
            {
                isModify = false;
                btnSave.ForeColor = Color.Silver;
            }
            else
            {
                isModify = true;
                btnSave.ForeColor = Color.FromArgb(6, 193, 103);
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            int p = 0;
            if (Int32.TryParse(txtPrice.Text, out p))
            {
                if (p == intMealPrice && txtName.Text == strMealName && listOriginalSideContain.Intersect(listSideContain).ToList().Count == listOriginalSideContain.Count)
                {
                    isModify = false;
                    btnSave.ForeColor = Color.Silver;
                }
                else
                {
                    isModify = true;
                    btnSave.ForeColor = Color.FromArgb(6, 193, 103);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
                txtPrice.Text = intMealPrice.ToString();      //使用者輸入無效數字，幫回復最初值
            }
        }

        private void btnAddMeal_Click(object sender, EventArgs e)
        {
            pnlSide.Visible = true;
            isAddMeal = true;
            sel_meal_id = "";
            strMealName = "";
            intMealPrice = 0;
            listSideContain.Clear();
            listOriginalSideContain.Clear();
            dgvMenuList.ClearSelection();

            txtName.Text = strMealName;
            txtPrice.Text = intMealPrice.ToString();
            flpSide.Controls.Clear();


            Button btn = new Button();
            btn.Font = new Font("新細明體", 18.0f, FontStyle.Bold);
            btn.Text = "┼";
            btn.FlatStyle = FlatStyle.Flat;
            btn.TabStop = false;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = SystemColors.Control;
            btn.AutoSize = false;
            btn.Size = new Size(30, 30);
            btn.Click += BtnAddSide_Click;
            flpSide.Controls.Add(btn);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Are you sure to DELETE this meal?", "Warning", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True; MultipleActiveResultSets = true");
                con.Open();
                string strSQL = "UPDATE shop_list_meal set is_use = 0 where meal_id = '" + sel_meal_id + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();
                dgvMenuList.Rows.Clear();
                loadDgv();
                pnlSide.Visible = false;
            }
            else if (r == DialogResult.No)
            {

            }
        }
    }
}
