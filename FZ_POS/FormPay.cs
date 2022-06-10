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
    public partial class FormPay : Form
    {
        int pick_up_num;
        public FormPay(int num)
        {
            InitializeComponent();
            pick_up_num = num;

        }

        private void FormPay_Load(object sender, EventArgs e)
        {
            cbtnPickUpNumber.Text = pick_up_num.ToString();
        }
    }
}
