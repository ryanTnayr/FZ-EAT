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
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
        }

        private void UserControlLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" || txtPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = fzDB; Integrated Security = True");
                con.Open();
                string strSQL = "select * from accounts where user_name = @newUsername and pass_word = @newPassword";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@newUsername", txtUsername.Text);
                cmd.Parameters.AddWithValue("@newPassword", txtPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if ((int)reader["is_who"] == 0)
                    {//進顧客畫面
                        GlobalVar.CUS_ID = (int)reader["user_id"];
                        MessageBox.Show("Welcome Back  " + txtUsername.Text + "  ,come to get fat together~~~");
                        GlobalVar.formCustomer.Show();
                        GlobalVar.formLogin.Hide();
                        
                    }
                    else if ((int)reader["is_who"] == 1)
                    {//進店家畫面
                        GlobalVar.SHOP_ID = (int)reader["user_id"];
                        MessageBox.Show("Welcome Back  " + txtUsername.Text + "  ,come to get rich~~~");
                        GlobalVar.formShop.Show();
                        GlobalVar.formLogin.Hide();

                    }
                }
                else
                {
                    lblOK.Visible = true;
                    lblOK.Text = "Wrong Username or Password ~~";
                }
                reader.Close();
                con.Close();
                
            }
            else
            {
                MessageBox.Show("Please enter username or password.");
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
            GlobalVar.usercontrolCreateAccount.Location = new Point(70,50);
            this.Controls.Add(GlobalVar.usercontrolCreateAccount);

            GlobalVar.usercontrolCreateAccount.Show();
            this.txtUsername.Hide();
            this.txtPassword.Hide();
            this.lblOK.Visible = false;
            this.label2.Hide();
            this.label3.Hide();
            this.button3.Hide();
            this.btnCreateAccount.Hide();
            this.btnLogin.Hide();          
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            lblOK.Visible = false;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            lblOK.Visible = false;
        }
    }
}
