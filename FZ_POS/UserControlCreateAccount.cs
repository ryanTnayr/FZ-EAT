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
    /* 未完成功能：
     * 動態檢視是否有帳號重複：分為 小於3、不OK、OK、大於16
     * 密碼至少3個
     * 
    */
    public partial class UserControlCreateAccount : UserControl
    {
        int is_who = 0;
        public UserControlCreateAccount()
        {
            InitializeComponent();
        }

        private void UserControlCreateAccount_Load(object sender, EventArgs e)
        {
        }


        private void btnBeCus_Click(object sender, EventArgs e)
        {
            is_who = 0;
            新建會員資料();
        }

        private void btnBeStore_Click(object sender, EventArgs e)
        {
            is_who = 1;
            新建會員資料();
        }

        void 新建會員資料()
        {
            bool isUsernameOK = false;
            //檢查此帳號是否存在
            if (txtUsername.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
                con.Open();
                string strSQL = "select * from accounts where user_name = @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", txtUsername.Text);  
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblOK.Text = "This username have been used.Please change~";
                }
                else
                {
                    isUsernameOK = true;
                    lblOK.Text = "OK";
                }
            }
            //若沒有重複帳號且有輸入數字，就創建帳號
            if (txtUsername.Text != "" && txtPassword.Text != "" && isUsernameOK == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
                con.Open();
                string strSQL = "insert accounts values (@newUsername ,@newPassword,@newIs_who)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@newUsername", txtUsername.Text);
                cmd.Parameters.AddWithValue("@newPassword", txtPassword.Text);
                cmd.Parameters.AddWithValue("@newIs_who", is_who);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Welcome "+txtUsername.Text+" ~Success create an account.");
            }
            else
            {
                MessageBox.Show("Please enter username and password.");
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
                con.Open();
                string strSQL = "select * from accounts where user_name = @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", txtUsername.Text);  
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblOK.Visible = true;
                    lblOK.ForeColor = Color.Red;
                    lblOK.Text = "This username have been used.Please change~";
                }
                else
                {
                    lblOK.Visible = true;
                    lblOK.ForeColor = Color.Blue;
                    lblOK.Text = "OK";
                }
            }
        }

        private void txtUsername_MouseDown(object sender, MouseEventArgs e)
        {
            txtUsername.ForeColor = Color.Black;
            txtUsername.Text = "";
            lblOK.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalVar.usercontrolLogin.txtUsername.Show();
            GlobalVar.usercontrolLogin.txtPassword.Show();
            GlobalVar.usercontrolLogin.label2.Show();
            GlobalVar.usercontrolLogin.label3.Show();
            GlobalVar.usercontrolLogin.button3.Show();
            GlobalVar.usercontrolLogin.btnCreateAccount.Show();
            GlobalVar.usercontrolLogin.btnLogin.Show();
        }
    }
}
