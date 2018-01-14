using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Module
{
    class Functions
    {
        public Functions()
        {
        }

        public static MySqlConnection OpenSqlConnection(string server, string db, string u, string p, string port, bool dontShowErrors = false)
        {
            string connStr = string.Format("server={0};database={1};user={2};port={3};password={4};Allow User Variables=true;", server, db, u, port, p);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {

                conn.Open();

                return conn;

            }
            catch (Exception ex)
            {
                if (!dontShowErrors)
                {
                    ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
                }
                conn.Close(); conn.ClearPoolAsync(conn);
                conn.Dispose();

                return null;
            }
        }
        
        public static void NumericKeyPressOnly(object sender, KeyPressEventArgs e)
		{
			 // allows 0-9, backspace, and decimal
	        if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
	        {
	            e.Handled = true;
	            return;
	        }
	
	        // checks to make sure only 1 decimal is allowed
	        if (e.KeyChar == 46)
	        {
	        	if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
	                e.Handled = true;
	        }
		}

        public static DataTable GetTable(string query, bool setCommandTimeoutToZero = true, bool DontShowErrors = false)
        {
            if (Program.GlobalConn == null)
            {
                Program.GlobalConn = Functions.OpenSqlConnection(Program.Server, Program.currentDB, Program.SqlUser, Program.Password, Program.Port, DontShowErrors);
            }

            if (Program.GlobalConn == null)
            {
                if (!DontShowErrors)
                    MessageBox.Show("Unable to connect to MySQL server.", "Connectivity Error: GetTable()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); // empty datatable
            }

            if (Program.GlobalConn.State != ConnectionState.Open)
                Program.GlobalConn = Functions.OpenSqlConnection(Program.Server, Program.currentDB, Program.SqlUser, Program.Password, Program.Port, DontShowErrors);




            MySqlConnection conn = Program.GlobalConn;
            // MySqlCommand cmd;
            // string s0;

            DataTable dt = new DataTable();


            try
            {

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                if (setCommandTimeoutToZero)
                    da.SelectCommand.CommandTimeout = 300;
                //da.SelectCommand.CommandTimeout = 0;

                dt.Clear();
                da.Fill(dt);

                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                if (!DontShowErrors)
                {
                    ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
                }



                //return new DataTable(); // empty datatable
                return null;
            }
            finally
            {

            }
        }

        public static string RemoveSpecial(string str)
        {
            str = str.Replace("\\", "");
            str = str.Replace("'", "");
            str = str.Replace("`", "");
            str = str.Replace("\"", "");
            str = str.Replace("_", "");
            str = str.Replace("%", "pc");
            str = str.Replace("#", "");
            str = str.Replace("\"", "");

            str = MySql.Data.MySqlClient.MySqlHelper.EscapeString(str);

            return str;
        }

        public static bool SqlNonQuery(string query)
        {
            if (Program.GlobalConn == null)
            {
                Program.GlobalConn = Functions.OpenSqlConnection(Program.Server, Program.currentDB, Program.SqlUser, Program.Password, Program.Port);
            }

            if (Program.GlobalConn.State != ConnectionState.Open)
                Program.GlobalConn = Functions.OpenSqlConnection(Program.Server, Program.currentDB, Program.SqlUser, Program.Password, Program.Port);


            MySqlConnection conn = Program.GlobalConn;
            MySqlCommand cmd;
            string s0 = query;

            try
            {


                cmd = new MySqlCommand(s0, conn);

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
                return false;
            }
        }

        public static bool SqlNonQuery(string query, MySqlConnection conn)
        {
            MySqlCommand cmd;
            string s0 = query;

            try
            {


                cmd = new MySqlCommand(s0, conn);

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
                return false;
            }
        }

        public static void SqlNonQueryWithoutExHandled(string query, MySqlConnection conn)
        {
            MySqlCommand cmd;
            string s0 = query;



            cmd = new MySqlCommand(s0, conn);

            cmd.ExecuteNonQuery();


        }
        
        public static bool hasPermission(string perm_group, string permission )
        {
        	bool ret = false;
        	
        	DataTable userTable = Functions.GetTable("select id, is_admin from  "+Program.ModName_lcns+
        	                                      "_users where name = '"+Program.currentUSER+"' limit 1 ");
        	
        	if(userTable != null)
        	{
        		if(userTable.Rows.Count > 0)
        		{
        			if( Convert.ToBoolean(userTable.Rows[0]["is_admin"]) == true )
        			{
        				ret = true;
        			}
        			else
        			{
        				DataTable permTable = Functions.GetTable("select id from "+Program.ModName_lcns+
        				                                         "_user_permissions where user_id = '"+userTable.Rows[0]["id"].ToString()+
        				                                         "' and permission_group = '"+perm_group+"' and permission = '"+permission+"' " );
        				
        				if(permTable != null)
        				{
        					if(permTable.Rows.Count > 0)
        					{
        						ret = true;
        					}
        				}
        			}
        		}
        	}
        		
        		
        		
        		
        	return ret;
        }
        
        
        public static decimal ParseDecimal(string s)
		{
			if(s == "" || s == null)
			{
				return 0;
			}
			{
				try{
					return decimal.Parse(s);
				}catch{
					MessageBox.Show("Input value was not in correct format: "+s);
					return 0;
				}
			}
		}

        public static DataTable GetTable(string query, MySqlConnection conn, bool CloseConnAfter = true, bool dontshowerrors = false)
        {

            if (conn == null)
            {
                if (!dontshowerrors)
                    MessageBox.Show("Connection is Null", "Connectivity Error: GetTable()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); //empty datatable
            }

            if (conn.State != ConnectionState.Open)
            {
                if (!dontshowerrors)
                    MessageBox.Show("Connection is not open", "Connectivity Error: GetTable()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); //empty datatable
            }



            DataTable dt = new DataTable();

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                //da.SelectCommand.CommandTimeout = 0;
                dt.Clear();
                da.Fill(dt);

                if (CloseConnAfter)
                {
                    conn.Close(); conn.ClearPoolAsync(conn);
                    conn.Dispose();
                }

                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                if (!dontshowerrors)
                {
                    ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
                }
                return null;
            }
            finally
            {
                if (CloseConnAfter)
                {
                    conn.Close(); conn.ClearPoolAsync(conn);
                    conn.Dispose();
                }
            }
        }

    }


}
