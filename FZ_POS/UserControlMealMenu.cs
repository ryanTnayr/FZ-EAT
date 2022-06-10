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
    public partial class UserControlMealMenu : UserControl
    {
        SqlConnectionStringBuilder scsb;
        string fzDBConnectionString = "";
        public UserControlMealMenu()
        {
            InitializeComponent();
        }
    }
}
