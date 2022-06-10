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
    class GlobalVar
    {
        //視窗
        public static Form1 form1; //初始視窗控制不了，故隱藏起來沒有要用
        public static FormLogin formLogin = new FormLogin();
        public static FormCustomer formCustomer = new FormCustomer();
        public static FormPay formPay;
        public static FormShop formShop = new FormShop();
        public static FormShopMenu formShopMenu = new FormShopMenu();
        public static FormSideGroup formSideGroup = new FormSideGroup();
        public static FormAdd formAdd;
        public static UserControlLogin usercontrolLogin = new UserControlLogin();
        public static UserControlMealMenu usercontrolMealMenu = new UserControlMealMenu();
        public static UserControlOrderList usercontrolOrderList = new UserControlOrderList();
        public static UserControlAdd usercontrolAdd = new UserControlAdd();
        public static UserControlCreateAccount usercontrolCreateAccount = new UserControlCreateAccount();
        
        //SQL
        //public static SqlConnectionStringBuilder scsb;
        //public static string fzDBConnectionString = "";
        
        //目前使用者
        public static int CUS_ID;
        public static int SHOP_ID;

        //目前顧客瀏覽店家(未實現)
        public static int SEL_SHOP_ID =4;

        //店家菜單內容
        public static List<Meal> listMealInfo = new List<Meal>();
        public static List<string> listMealSideInfo = new List<string>();  //此 meal 所擁有的 side
        public static List<Side> listSideInfo = new List<Side>();


        //訂單內容
        public static List<Order> listOrderInfo = new List<Order>();
        public static Order order = new Order();
        


    }
}
