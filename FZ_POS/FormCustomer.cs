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
    public partial class FormCustomer : Form
    {
        SqlConnectionStringBuilder scsb;
        string fzDBConnectionString = "";
        List<string> listMealGroupId = new List<string>();
        List<string> listMealGroupName = new List<string>();
        Dictionary<string,int> listBtnLocation = new Dictionary<string, int>();
        List<UserControlMealMenu> listUCMM = new List<UserControlMealMenu>();
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"";
            scsb.InitialCatalog = "fzDB";
            scsb.IntegratedSecurity = true;
            fzDBConnectionString = scsb.ToString();
            //以上省略為以下這行
            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True; MultipleActiveResultSets = true");
            con.Open();
            string strSQL = "SELECT * from shop_meal_group where user_id = @user_id and is_use = 1";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue(@"user_id", GlobalVar.SEL_SHOP_ID);
            SqlDataReader reader = cmd.ExecuteReader();

            int j = 0;
            while (reader.Read())
            {
                Button btn = new Button();
                btn.Size = new Size(156, 60);
                //btn.Tag = ;
                btn.Location = new Point(0, 5 + 65 * j++);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.Font = new Font("Gill Sans Ultra Bold", 12.0f);
                btn.Text = (string)reader["meal_group_name"];
                btn.Image = Properties.Resources.哈囉豬1;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Click += Btn_Click;
                panel3.Controls.Add(btn);
                listMealGroupId.Add((string)reader["meal_group_id"]);
                listMealGroupName.Add((string)reader["meal_group_name"]);
            }
            reader.Close();

            // dock fill lacation (156, 0) size (475, 602)
            for (int i = 0; i < listMealGroupId.Count; i++)
            {
                strSQL = "select * from shop_list_meal where user_id = @user_id and meal_group_id = @meal_group_id and is_use = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(@"user_id", GlobalVar.SEL_SHOP_ID);
                cmd.Parameters.AddWithValue(@"meal_group_id", listMealGroupId[i]);
                cmd.CommandText = strSQL;
                reader = cmd.ExecuteReader();
                //判斷筆數
                if (reader.HasRows)
                {
                    Label lbl = new Label();
                    lbl.Font = new Font("Gill Sans Ultra Bold", 18.0f);
                    lbl.ForeColor = Color.Coral;
                    lbl.AutoSize = true;
                    lbl.Text = listMealGroupName[i];
                    flowLayoutPanel1.Controls.Add(lbl);
                    lbl.Tag = lbl.Location.Y;
                    flowLayoutPanel1.SetFlowBreak(lbl, true);

                    Panel pnl = new Panel();
                    pnl.Size = new Size(0, 50);
                    flowLayoutPanel1.Controls.Add(pnl);

                    int rowCount = 0;
                    while (reader.Read())
                    {
                        //將店家 Meal 物件化 ，後面都沒有用到，但就先留著
                        Meal meal = new Meal();
                        meal.Meal_group_id = (string)reader["meal_group_id"];
                        meal.Name = (string)reader["meal"];
                        meal.Meal_id = (string)reader["meal_id"];
                        meal.Price = (int)reader["price"];
                        GlobalVar.listMealInfo.Add(meal);
                        //產生 ucMM 並顯示
                        UserControlMealMenu ucMM = new UserControlMealMenu();
                        ucMM.gboxMeal.Text = meal.Name;
                        ucMM.gboxMeal.Tag = meal.Meal_id;
                        ucMM.lblPrice.Text = meal.Price.ToString();
                        ucMM.Tag = meal.Price;
                        ucMM.btnAdd.Click += btnAdd_Click;
                        this.flowLayoutPanel1.Controls.Add(ucMM);
                        listUCMM.Add(ucMM);
                        rowCount++;
                    }
                    flowLayoutPanel1.SetFlowBreak(listUCMM[listUCMM.Count-1],true);  //設最後一項為換行
                }
                else
                {
                    MessageBox.Show("This shop don't have any meal.");
                }
                reader.Close();
            }
            con.Close();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (Control ct in flowLayoutPanel1.Controls)
            {
                if(ct.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (ct.Text == btn.Text)
                    {
                        flowLayoutPanel1.VerticalScroll.Value = (int)ct.Tag;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //儲存所選 Meal
            Button btnPick = (Button)sender;
            Control control = btnPick.Parent; //gbox
            GlobalVar.order.Order_name = control.Text;
            GlobalVar.order.Meal_id = (string)control.Tag;
            GlobalVar.order.Qty = 1;
            GlobalVar.order.Unit_price += (int)control.Parent.Tag; //ucMM.Tag = meal.Price

            //儲存該 meal_id 所擁有的 side 名稱
            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
            con.Open();
            string strSQL = "select * from shop_meal_side where meal_id = @newMealID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue(@"newMealID", (string)control.Tag);  //gbox.tag = meal_id
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GlobalVar.listMealSideInfo.Add((string)reader["side_group_id"]);
                }
                FormAdd formAdd = new FormAdd();
                DialogResult r = formAdd.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //把最新的項目加入 DGV
                    for (int i = dgvOrderList.Rows.Count; i< GlobalVar.listOrderInfo.Count;i++)
                    {
                        
                        dgvOrderList.Rows.Add(GlobalVar.listOrderInfo[i].Order_name, GlobalVar.listOrderInfo[i].Qty, GlobalVar.listOrderInfo[i].Total_price);
                    }
                    //計算總價
                    lblPrice.Text = calSum().ToString();
                }
                else if (r == DialogResult.Cancel)
                {
                }
            }
            else
            {
                //MessageBox.Show("This meal don't have any side.");
                GlobalVar.listOrderInfo.Add(GlobalVar.order);
                GlobalVar.order = new Order();
                for (int i = dgvOrderList.Rows.Count; i < GlobalVar.listOrderInfo.Count; i++)
                {
                    dgvOrderList.Rows.Add(GlobalVar.listOrderInfo[i].Order_name, GlobalVar.listOrderInfo[i].Qty, GlobalVar.listOrderInfo[i].Total_price);
                }
                lblPrice.Text = calSum().ToString();
                //以下直接把該項加入 dgv 就是單點功能
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            GlobalVar.listOrderInfo.Clear();
            dgvOrderList.Rows.Clear();
            lblPrice.Text = calSum().ToString();
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            GlobalVar.listOrderInfo.RemoveAt(e.RowIndex);
            dgvOrderList.Rows.RemoveAt(e.RowIndex);
            lblPrice.Text = calSum().ToString();

            //這方法也行
            //foreach (DataGridViewRow row in dgvOrderList.SelectedRows)
            //{
            //    if (row.Index >= 0)
            //    {
            //        GlobalVar.listOrderInfo.RemoveAt(row.Index);
            //        dgvOrderList.Rows.RemoveAt(row.Index);
            //    }
            //}
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string cart_id = GlobalVar.CUS_ID + DateTime.Now.ToString(("_yyyyMMddHHmmss"));
            int sum = calSum();

            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True; MultipleActiveResultSets = true") ;
            con.Open();
            string strSQL = "insert cus_history_order (user_id, sel_shop_id, cart_id, cart_price) values (@user_id, @sel_shop_id, @cart_id, @cart_price)";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue(@"user_id", GlobalVar.CUS_ID);
            cmd.Parameters.AddWithValue(@"sel_shop_id", GlobalVar.SEL_SHOP_ID);
            cmd.Parameters.AddWithValue(@"cart_id", cart_id);
            cmd.Parameters.AddWithValue(@"cart_price", sum);
            cmd.ExecuteNonQuery();

            for (int i = 0;i < GlobalVar.listOrderInfo.Count;i++)
            {
                strSQL = "insert cus_order_dtl (cart_id, order_id, order_name, meal_id, meal_num, total_price) values (@cart_id, 'BB" + i + "',@order_name, @meal_id, @meal_num, @total_price)";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue(@"cart_id", cart_id);
                cmd.Parameters.AddWithValue(@"order_name", GlobalVar.listOrderInfo[i].Order_name);
                cmd.Parameters.AddWithValue(@"meal_id", GlobalVar.listOrderInfo[i].Meal_id);
                cmd.Parameters.AddWithValue(@"meal_num", GlobalVar.listOrderInfo[i].Qty);
                cmd.Parameters.AddWithValue(@"total_price", GlobalVar.listOrderInfo[i].Total_price);
                cmd.ExecuteNonQuery();
                for (int j = 0; j < GlobalVar.listOrderInfo[i].Side_id.Count; j++)
                {
                    strSQL = "insert cus_order_side (cart_id, order_id, side_id) values (@cart_id, 'BB" + i + "', @side_id)";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue(@"cart_id", cart_id);
                    cmd.Parameters.AddWithValue(@"side_id", GlobalVar.listOrderInfo[i].Side_id[j]);
                    cmd.ExecuteNonQuery();
                }
            }

            strSQL = "select pick_up_num from cus_history_order where cart_id = '" + cart_id+"'";
            cmd.CommandText = strSQL;
            var reader = cmd.ExecuteReader();
            int pick_up_num = 0;
            while (reader.Read())
            {
                 pick_up_num = reader.GetInt32(0);
            }
            reader.Close();
            con.Close();

            MessageBox.Show("Success order your meal ~~");
            dgvOrderList.Rows.Clear();
            GlobalVar.listOrderInfo.Clear();
            lblPrice.Text = "-";

            FormPay formAdd = new FormPay(pick_up_num);
            DialogResult r = formAdd.ShowDialog();
            if (r == DialogResult.OK)
            {
            }
        }

        int calSum()
        {
            int sum = GlobalVar.listOrderInfo.Sum(e => e.Total_price);
            return sum;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            GlobalVar.usercontrolLogin.txtUsername.Text = "";
            GlobalVar.usercontrolLogin.txtPassword.Text = "";
            GlobalVar.formLogin.Show();
            this.Hide();
        }

        private void dgvOrderList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            GlobalVar.listOrderInfo[e.RowIndex].Qty = int.Parse(dgvOrderList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            lblPrice.Text = calSum().ToString();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Hide();
            panel2.Hide();
        }
    }
}
