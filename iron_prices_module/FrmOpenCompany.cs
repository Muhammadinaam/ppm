using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data.MySqlClient;

namespace Module
{
    public partial class FrmOpenCompany : Form
    {
        public FrmOpenCompany()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var textboxes = Controls.OfType<TextBox>();

            bool hasErrors = false;
            foreach (var box in textboxes)
            {
                
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    errorProvider1.SetError(box, "Please fill the required field!");
                    hasErrors = true;
                }

                
            }

            if (lb_databases.SelectedItems.Count == 0)
            {
                errorProvider1.SetError(lb_databases, "Please select one database");
                hasErrors = true;
            }
            else
            {
                errorProvider1.Dispose();
            }

            if (hasErrors == false)
            {
                errorProvider1.Dispose();
            }


            openCompany();
        }

        public void openCompany()
        {
            if (lb_databases.SelectedIndex >= 0 || Program.IsDefaultDBset == true)
            {
                MySqlConnection conn = new MySqlConnection();

                try
                {
                    string database = Program.IsDefaultDBset == true ? Program.currentDB : "GBC_" + lb_databases.SelectedItem.ToString().Replace(' ', '_');
                    string connStr = string.Format("server={0};database={1};user={2};port={3};password={4};", Program.Server, database, Program.SqlUser, Program.Port, Program.Password);

                    Program.GlobalConn = new MySqlConnection(connStr);
                    Program.GlobalConn.Open();

                    DataTable dt = Functions.GetTable("show tables like '" +
                        Program.ModName_lcns + "_users'");

                    if (dt.Rows.Count == 0)
                    {
                        var dialogResult = MessageBox.Show("[" + Program.ThisModuleName + "] Module has not been configured with selected database. "
                            + "Do you want to configure now?\n\nIt is recommended to open Accounting Module and save backup before configuring modules.", "Module Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // module configuration code
                            ConfigureModule();

                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        // code to open the company i.e. check userid and password

                        dt = Functions.GetTable("select name, password from " 
                            +Program.ModName_lcns+ "_users where name = '"+txb_userid.Text+"'");

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("User ID or Password not correct");
                        }
                        else
                        {
                            string decryptedPassword = StringCipher.Decrypt(dt.Rows[0]["password"].ToString(), Program.EncryptionKey);
                            if ( string.Compare(decryptedPassword, txb_password.Text) == 0 )
                            {
                                //userid and password are correct
                                Program.currentUSER = txb_userid.Text;
                                Program.MainWindow.EnableMenues(true);
                                
                                Program.MainWindow.Text += " - [User: "+this.txb_userid.Text+"] ";

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("User ID or Password not correct");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    ExceptionMB emb = new ExceptionMB();
                    emb.ShowMB(ex);
                }
            }
        }

        private void ConfigureModule()
        {
            try
            {
                string userID = "";
                string password = "";

                FrmNewAdminUser fna = new FrmNewAdminUser();
                if (fna.ShowDialog() == DialogResult.OK)
                {

                    userID = fna.userid;
                    password =  StringCipher.Encrypt( fna.password, Program.EncryptionKey );
                }
                else
                {
                    return;
                }

                Functions.SqlNonQueryWithoutExHandled("CREATE TABLE if not exists `" + Program.ModName_lcns + "_users` ( " +
                      "`id` INT NOT NULL AUTO_INCREMENT COMMENT '', " +
                      "`name` VARCHAR(255) NULL COMMENT '', " +
                      "`password` VARCHAR(255) NULL COMMENT '', " +
                      "`is_admin` TINYINT NULL COMMENT '', " +
                      "PRIMARY KEY(`id`)  COMMENT '', " +
                      "UNIQUE INDEX `name_UNIQUE` (`name` ASC)  COMMENT '') engine = innodb; ",
                      Program.GlobalConn);

                Functions.SqlNonQueryWithoutExHandled("CREATE TABLE if not exists `" + Program.ModName_lcns+"_user_permissions` ( " +
                      "`id` INT NOT NULL AUTO_INCREMENT COMMENT '', " +
                      "`user_id` INT NOT NULL COMMENT '', " +
                      "`permission` VARCHAR(255) NOT NULL COMMENT '', " +
                      "PRIMARY KEY(`id`)  COMMENT '', " +
                      "INDEX `fk_"+Program.ModName_lcns+"_permissions_userid_idx` (`user_id` ASC)  COMMENT '', " +
                      "CONSTRAINT `fk_"+Program.ModName_lcns+"_permissions_userid` " +
                        "FOREIGN KEY (`user_id`) " +
                        "REFERENCES `"+Program.ModName_lcns+"_users` (`id`) " +
                        "ON DELETE CASCADE " +
                        "ON UPDATE CASCADE) engine = innodb; ",
                      Program.GlobalConn);
                
                Functions.SqlNonQueryWithoutExHandled("ALTER TABLE `"+Program.ModName_lcns+"_user_permissions` " + 
					"ADD COLUMN `permission_group` VARCHAR(255) NULL AFTER `user_id`;", Program.GlobalConn);

                Functions.SqlNonQueryWithoutExHandled("INSERT INTO `"+ Program.ModName_lcns + "_users` (`name`, `password`, `is_admin`) VALUES ('"+userID+"', '"+password+"', '1')", Program.GlobalConn);

                // MODULE RELATED TABLES - START

                //Functions.SqlNonQueryWithoutExHandled("", Program.GlobalConn);
                
                Functions.SqlNonQueryWithoutExHandled("CREATE TABLE `"+Program.ModName_lcns+"_standard_prices` ( " +
							  "`id` INT NOT NULL AUTO_INCREMENT COMMENT '', " +
							  "`coa_name` VARCHAR(1000) NOT NULL COMMENT '', " +
							  "`standard_price` DECIMAL(40,5) NOT NULL COMMENT '', " +
							  "PRIMARY KEY (`id`)  COMMENT '', " +
							  "INDEX `fk_coa_name_idx` (`coa_name` ASC)  COMMENT '', " +
							  "CONSTRAINT `fk_coa_name` " +
							    "FOREIGN KEY (`coa_name`) " +
							    "REFERENCES `coa` (`Name`) " +
							    "ON DELETE CASCADE " +
							    "ON UPDATE CASCADE) engine = innodb;", Program.GlobalConn);

                

                // ENTRIES AND RECIPE TABLES SHOULD BE SAME
                
                Functions.SqlNonQueryWithoutExHandled("ALTER TABLE `entries` " +
										"ADD COLUMN `standard_price` DECIMAL(40,5) NULL DEFAULT NULL AFTER `Qty`, " +
										"ADD COLUMN `margin_percent_above_standardprice` DECIMAL(20,5) NULL DEFAULT NULL AFTER `standard_price`;", Program.GlobalConn);
                
                Functions.SqlNonQueryWithoutExHandled("ALTER TABLE `recipes` " +
										"ADD COLUMN `standard_price` DECIMAL(40,5) NULL DEFAULT NULL AFTER `Qty`, " +
										"ADD COLUMN `margin_percent_above_standardprice` DECIMAL(20,5) NULL DEFAULT NULL AFTER `standard_price`;", Program.GlobalConn);
                
                // ENTRIES AND RECIPE TABLES SHOULD BE SAME


                MessageBox.Show("Module configured successfully.", "Module Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MODULE RELATED TABLES - END

            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB();
                emb.ShowMB(ex);
            }
            finally
            {

            }
        }

        private void FrmUserAuth_Load(object sender, EventArgs e)
        {
            DataTable ConnConfigDT = new DataTable();
            try
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                FileStream fs = new FileStream(path + @"\Config.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                ConnConfigDT = (DataTable)bf.Deserialize(fs);
                fs.Close();

                if (ConnConfigDT.Rows[0]["Database"].ToString() != "")
                {
                    Program.currentDB = ConnConfigDT.Rows[0]["Database"].ToString();
                    Program.IsDefaultDBset = true;
                }
                else
                {
                    Program.currentDB = "";
                    Program.IsDefaultDBset = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
            }



            if (Program.IsDefaultDBset)
            {
                label3.Text = "Current Database: " + Program.currentDB;
                lb_databases.Hide();

                this.Height = 164;

            }

            

            if (Program.IsDefaultDBset)
                return; //dont get list of databases

            lb_databases.Items.Clear();
            string connStr = string.Format("server={0};user={1};port={2};password={3};", Program.Server, Program.SqlUser, Program.Port, Program.Password);
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            string s0;

            try
            {
                // show list of databases
                conn.Open();
                s0 = "SHOW DATABASES;";
                cmd = new MySqlCommand(s0, conn);
                MySqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        row = Reader.GetValue(i).ToString();
                        if (row.Length > 4)
                            if (row.Substring(0, 4) == "gbc_")
                            {
                                lb_databases.Items.Add(row.Substring(4).Replace('_', ' ').ToUpper());
                            }
                    }
                }

                if (lb_databases.Items.Count == 0)
                {
                    MessageBox.Show("No database exists. Please create new database through accounting system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                conn.Close(); conn.ClearPoolAsync(conn);
                conn.Dispose();
            }
            catch (Exception ex)
            {
                ExceptionMB emb = new ExceptionMB(); emb.ShowMB(ex);
                MessageBox.Show("Not able to connect to MySQL Server. Please Enter MySQL Server Information.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmConnectionConfig FCC = new FrmConnectionConfig();
                FCC.ShowDialog();

                this.Close();

                conn.Close(); conn.ClearPoolAsync(conn);
                conn.Dispose();
            }

            if (lb_databases.Items.Count > 0)
            {
                lb_databases.SetSelected(0, true);
                txb_userid.Focus();
            }
        }
    }
}
