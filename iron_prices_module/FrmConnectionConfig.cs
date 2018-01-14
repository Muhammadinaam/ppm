/*
 * Created by SharpDevelop.
 * User: Inam Munir
 * Date: 14-01-2014
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Module
{
    /// <summary>
    /// Description of FrmConnectionConfig.
    /// </summary>
    public partial class FrmConnectionConfig : Form
    {
        DataTable dt = new DataTable();



        public FrmConnectionConfig()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //


        }


        void Btn_CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        void Btn_SaveClick(object sender, EventArgs e)
        {
            try
            {
                btn_Save.Enabled = false;

                dt = new DataTable();
                dt.Columns.Add("Server");
                dt.Columns.Add("Port");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");
                dt.Columns.Add("Database");

                DataRow r = dt.NewRow();

                r["Server"] = txb_Server.Text;
                r["Port"] = txb_Port.Text;
                r["Username"] = txb_UserName.Text;
                r["Password"] = txb_Password.Text;
                r["Database"] = txb_Database.Text;

                dt.Rows.Add(r);

                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                FileStream fs = new FileStream(path + @"\Config.dat", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dt);
                fs.Close();

                MessageBox.Show("Changes saved successfully");

                Program.Server = txb_Server.Text;
                Program.Port = txb_Port.Text;
                Program.SqlUser = txb_UserName.Text;
                Program.Password = txb_Password.Text;


                if (txb_Database.Text != "")
                {
                    Program.currentDB = txb_Database.Text;
                    Program.IsDefaultDBset = true;
                }
                else
                {
                    Program.currentDB = "";
                    Program.IsDefaultDBset = false;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
            }
            finally
            {
                btn_Save.Enabled = true;
            }
        }

        void FrmConnectionConfigLoad(object sender, EventArgs e)
        {
            try
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                FileStream fs = new FileStream(path + @"\Config.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                dt = (DataTable)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
            }

            if (dt.Rows.Count > 0)
            {
                txb_Server.Text = dt.Rows[0]["Server"].ToString();
                txb_Port.Text = dt.Rows[0]["Port"].ToString();
                txb_UserName.Text = dt.Rows[0]["Username"].ToString();
                txb_Password.Text = dt.Rows[0]["Password"].ToString();
                txb_Database.Text = dt.Rows[0]["Database"].ToString(); ;
            }
            else
            {
                dt.Columns.Clear();
                dt.Columns.Add("Server");
                dt.Columns.Add("Port");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");
                dt.Columns.Add("Database");
            }
        }
    }
}
