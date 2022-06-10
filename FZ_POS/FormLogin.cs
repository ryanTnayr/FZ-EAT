//用C#如何遍歷一個窗體中的某一種控制元件  https://www.796t.com/content/1546585934.html 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FZ_POS
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

            //GlobalVar.form1.Hide();
            GlobalVar.usercontrolLogin.Location = new Point(105, 60);
            this.Controls.Add(GlobalVar.usercontrolLogin);
        }
    }
}
