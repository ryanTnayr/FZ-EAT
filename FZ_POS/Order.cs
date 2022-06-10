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
using System.Collections;

namespace FZ_POS
{
    class Order
    {
        public string Order_id = "";
        public string Order_name = "";
        public string Meal_id = "";
        public int Qty = 0;
        public int Unit_price = 0;
        public int Total_price { get { return Unit_price * Qty; } }
        public List<string> Side_id = new List<string>();
    }
}
