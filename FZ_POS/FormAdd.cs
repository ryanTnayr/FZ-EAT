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
    public partial class FormAdd : Form
    {
        Dictionary<string, UserControlMealMenu> dicucMM = new Dictionary<string, UserControlMealMenu>();
        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {//建立Add form 讓+可以呼叫他
            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Top;     
            table.RowCount = GlobalVar.listMealSideInfo.Count;
            table.ColumnCount = 1;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.Height = table.RowCount * 185;

            panel1.Controls.Add(table);

            for (int i = 0; i <GlobalVar.listMealSideInfo.Count;i++)
            {
                SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
                con.Open();
                string strSQL = "select * from shop_side_dtl where side_group_id = @newSGID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue(@"newSGID", GlobalVar.listMealSideInfo[i]);
                SqlDataReader reader = cmd.ExecuteReader();

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 190));

                FlowLayoutPanel fpnl = new FlowLayoutPanel();
                fpnl.Size = new Size(453, 190);
                fpnl.Location = new Point(0, 0 + 190 * i);
                fpnl.AutoScroll = true;
                fpnl.BackColor = Color.FromArgb(237, 203, 154+10*i);
                fpnl.Anchor = (AnchorStyles.Right | AnchorStyles.Left);
                fpnl.FlowDirection = FlowDirection.TopDown;

                int j = 0;
                while (reader.Read())
                {//動態生成side物件
                    if (j == 0)
                    {
                        Label lbl = new Label();
                        lbl.AutoSize = false;
                        lbl.Size = new Size(30, 160);
                        lbl.Font = new Font("Gill Sans Ultra Bold", 16.0f, FontStyle.Regular);
                        lbl.BackColor = Color.AntiqueWhite;
                        lbl.Text = (string)reader["side_group_name"];
                        lbl.Text =lbl.Text.ToUpper();

                        fpnl.Controls.Add(lbl);
                        table.Controls.Add(fpnl, 0, i);
                    }
                    
                    UserControlMealMenu ucMM = new UserControlMealMenu();
                    ucMM.Tag = String.Format("{0}_{1}", reader["side_group_name"], j);
                    ucMM.gboxMeal.Text = (string)reader["side_name"];
                    ucMM.gboxMeal.BackColor = Color.AntiqueWhite;
                    ucMM.lblPrice.Text = (string)reader["price"].ToString();
                    ucMM.btnAdd.Click += BtnAdd_Click;
                    ucMM.gboxMeal.Tag = reader["side_group_id"];

                    fpnl.Controls.Add(ucMM);
                    dicucMM.Add(String.Format("{0}_{1}", reader["side_group_id"], j), ucMM);

                    j++;
                }
                reader.Close();
                con.Close();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {//顏色 AntiqueWhite = 未選擇， 顏色 (237, 158, 34) = 選擇
            Button btnPick = (Button)sender;
            Control control = btnPick.Parent; //groupbox

            if (control.BackColor == Color.AntiqueWhite)
            {//選中
                control.BackColor = Color.FromArgb(237, 158, 34);

            }
            else
            {//取消
                control.BackColor = Color.AntiqueWhite;
            }
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            //儲存所選項目及金額
            for (int i = 0; i < GlobalVar.listMealSideInfo.Count; i++)
            {
                for (int j = 0; j < dicucMM.Count; j++)
                {
                    if (  dicucMM.ElementAt(j).Key.ToString().Split('_')[0] == GlobalVar.listMealSideInfo[i] &&
                        dicucMM.ElementAt(j).Value.gboxMeal.BackColor == Color.FromArgb(237, 158, 34))
                        
                        //ex : 配料 = fries // 且顏色 = 選中
                    {
                        GlobalVar.order.Order_name += "。" + dicucMM.ElementAt(j).Value.gboxMeal.Text;
                        int p = 0;
                        Int32.TryParse(dicucMM.ElementAt(j).Value.lblPrice.Text, out p);
                        GlobalVar.order.Unit_price += p;
                        GlobalVar.order.Side_id.Add((string)dicucMM.ElementAt(j).Value.gboxMeal.Tag);
                    }
                }
            }
            GlobalVar.listOrderInfo.Add(GlobalVar.order);

            //清空此筆訂單所用變數
            GlobalVar.order = new Order();
            GlobalVar.listMealSideInfo.Clear();
            dicucMM.Clear();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //清空此筆訂單所用變數
            this.Close();
            dicucMM.Clear();
            GlobalVar.order = new Order();
            GlobalVar.listMealSideInfo.Clear();
        }

        private void FormAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清空此筆訂單所用變數
            dicucMM.Clear();
            GlobalVar.order = new Order();
            GlobalVar.listMealSideInfo.Clear();
        }
    }
}
