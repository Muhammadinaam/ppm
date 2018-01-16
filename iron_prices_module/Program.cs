using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace Module
{
    static class Program
    {
        public static FrmMainWindow MainWindow;

        public static string currentDB = "";        //as stored in sql
        public static bool IsDefaultDBset = false;
        public static string currentUSER = "";		//software user, not sql user
        public static string SqlUser = "root";      //sql user, not software user
        public static string Server = "localhost";  //host
        public static string Port = "3306";         //sql port
        public static string Password = "";	//password

        public static string ThisModuleName = "Poultry Prices Management";     //here we will set the name of module
        public static string ModName_lcns = "poultry_pm";     //here we will set the name of module

        public static string EncryptionKey = "123aabcc";
        
        public static DataTable rights_list = new DataTable();
        
        
        
        public static MySql.Data.MySqlClient.MySqlConnection GlobalConn = new MySql.Data.MySqlClient.MySqlConnection();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        	rights_list.Columns.Add("permission_group");
        	rights_list.Columns.Add("permission");
        	
        	
        	rights_list.Rows.Add("Users Management", "View List");
        	rights_list.Rows.Add("Users Management", "New User");
        	rights_list.Rows.Add("Users Management", "Edit User");
        	
        	rights_list.Rows.Add("Prices Management", "View List");
        	rights_list.Rows.Add("Prices Management", "Edit Prices");
        	
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new FrmMainWindow();
            MainWindow.EnableMenues(false);
            Application.Run(MainWindow);
        }
    }
}
