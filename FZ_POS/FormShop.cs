using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FZ_POS
{
    public partial class FormShop : Form
    {
        //field
        Button currentButton;

        public FormShop()
        {
            InitializeComponent();
        }

        //得以點 panel 來拖拉視窗
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg ,int wParam ,int lParam );

        private void FormShop_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            GlobalVar.formShopMenu.MdiParent = this;
            GlobalVar.formShopMenu.Location = new Point(0, 0);
            GlobalVar.formShopMenu.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            GlobalVar.formSideGroup.Hide();
            pnlHome.Hide();
            GlobalVar.formShopMenu.Show();
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            GlobalVar.formSideGroup.MdiParent = this;
            GlobalVar.formSideGroup.Location = new Point(0, 0);
            GlobalVar.formShopMenu.Hide();
            pnlHome.Hide();
            GlobalVar.formSideGroup.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            GlobalVar.usercontrolLogin.txtUsername.Text = "";
            GlobalVar.usercontrolLogin.txtPassword.Text = "";
            GlobalVar.formLogin.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            
            GlobalVar.formShopMenu.Hide();
            GlobalVar.formSideGroup.Hide();
            pnlHome.Show();
        }

        void ActivateButton( object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender )
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(20, 35, 40);
                    currentButton.ForeColor = Color.FromArgb(6, 193, 103);
                }
            }
        }

        void DisableButton()
        {
            foreach (Control previousButton in panel1.Controls)
            {
                if (previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.White;
                    previousButton.ForeColor = Color.FromArgb(20, 35, 40);

                }
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cbtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbtnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;  
            }
        }

        private void cbtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
