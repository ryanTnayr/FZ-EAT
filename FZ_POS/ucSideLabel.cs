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
    public partial class ucSideLabel : UserControl
    {
        bool isEnterBtn = false;
        bool isEnterPnl = false;
        bool isEnterLbl = false;
        public ucSideLabel()
        {
            InitializeComponent();
        }

        private void lblSide_MouseEnter(object sender, EventArgs e)
        {
            cbtnCancel.Visible = true;
            isEnterLbl = true;
        }

        private void lblSide_MouseLeave(object sender, EventArgs e)
        {
            cbtnCancel.Visible = false;
            //isEnterLbl = false;
            //if (isEnterPnl == false && isEnterBtn == false && isEnterLbl == false)
            //{
            //    cbtnCancel.Visible = false;
            //}

        }

        private void cbtnCancel_MouseEnter(object sender, EventArgs e)
        {
            cbtnCancel.Visible = true;
            isEnterBtn = true;
        }

        private void cbtnCancel_MouseLeave(object sender, EventArgs e)
        {
            cbtnCancel.Visible = false;
            isEnterBtn = false;
            //if (isEnterPnl == false && isEnterBtn == false && isEnterLbl == false)
            //{
            //    cbtnCancel.Visible = false;
            //}
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //cbtnCancel.Visible = true;
            //isEnterPnl = true;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            cbtnCancel.Visible = true;
            isEnterPnl = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (isEnterBtn == false)
            {
                isEnterPnl = false;
            }

            if (isEnterPnl == false && isEnterBtn == false && isEnterLbl == false)
            {
                cbtnCancel.Visible = false;
            }
        }
    }
}
