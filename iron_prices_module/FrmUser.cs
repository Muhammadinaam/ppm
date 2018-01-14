/*
 * Created by SharpDevelop.
 * User: Inaam Munir
 * Date: 31/01/2017
 * Time: 01:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Module
{
	/// <summary>
	/// Description of FrmUser.
	/// </summary>
	public partial class FrmUser : Form
	{
		
		public string user_id = "";
		
		public FrmUser()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void Btn_SaveClick(object sender, EventArgs e)
		{
			//check if user id already exists?
			DataTable tempDT = Functions.GetTable("select * from "+Program.ModName_lcns+"_users where name = '"+Functions.RemoveSpecial(txb_userID.Text)+"' " +
			                                      "and id <> '"+user_id+"'");
			if(tempDT.Rows.Count > 0)
			{
				MessageBox.Show("This User Name / ID already exists. Please change User ID / Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if(user_id == "" && txb_password.Text == "")
			{
				// Password should not be empty when creating new user
				
				MessageBox.Show("Please enter password for new user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if(txb_password.Text != txb_confirmPassword.Text)
			{
				MessageBox.Show("Password and Confirm Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if(txb_userID.Text == "")
			{
				MessageBox.Show("Please enter Name for new user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if(user_id == "")
			{
				//Enter new user in table
				Functions.SqlNonQuery( 
				                      
				                      string.Format("insert into  "+Program.ModName_lcns+"_users " +
				                      "(name, password, is_admin) values " +
				                      "('{0}', '{1}', '{2}')", 
				                      
				                      Functions.RemoveSpecial(txb_userID.Text), 
				                      StringCipher.Encrypt(txb_password.Text, Program.EncryptionKey), 
				                      ckb_adminUser.Checked ? "1" : "0"
			                     
			                     ) );
				
				string id = Functions.GetTable( "select last_insert_id() as 'id';" ).Rows[0]["id"].ToString();
				
				//Insert new permissions
				foreach( DataGridViewRow r in dgv_rights.Rows )
				{
					if( !DBNull.Value.Equals(r.Cells["Access"].Value) &&  (bool)r.Cells["Access"].Value == true )
					{
					
						Functions.SqlNonQuery( 
					                      
					                      string.Format("insert into  "+Program.ModName_lcns+"_user_permissions " +
					                      "(user_id, permission_group, permission) values " +
					                      "('{0}', '{1}', '{2}')", 
					                      
					                      id, 
					                      r.Cells["Permission Group"].Value.ToString(),
					                      r.Cells["Permission"].Value.ToString()
				                     
				                     ) );
					}
				}
			}
			else	//update existing user
			{
				
				Functions.SqlNonQuery( 
				                      
				                      string.Format("update "+Program.ModName_lcns+"_users " +
				                      "set name = '{0}', is_admin = '{1}' " +
				                      "where id = '{2}' ",
				                      
				                      Functions.RemoveSpecial(txb_userID.Text), 
				                      ckb_adminUser.Checked ? "1" : "0",
				                      user_id
			                     
			                     ) );
				
				if(txb_password.Text != "")
				{
					//password update query
					
					Functions.SqlNonQuery( 
					
										string.Format("update "+Program.ModName_lcns+"_users " +
				                      "set password = '{0}' " +
				                      "where id = '{1}' ",
				                      
				                      StringCipher.Encrypt(txb_password.Text, Program.EncryptionKey),
				                      user_id
				                      
				                     ) );
				}
				
				Functions.SqlNonQuery( " delete from  "+Program.ModName_lcns+"_user_permissions where user_id = '"+user_id+"' " );
				
				//Insert new permissions
				foreach( DataGridViewRow r in dgv_rights.Rows )
				{
					if( !DBNull.Value.Equals(r.Cells["Access"].Value) &&  (bool)r.Cells["Access"].Value == true )
					{
						Functions.SqlNonQuery( 
					                      
					                      string.Format("insert into  "+Program.ModName_lcns+"_user_permissions " +
					                      "(user_id, permission_group, permission) values " +
					                      "('{0}', '{1}', '{2}')", 
					                      
					                      user_id, 
					                      r.Cells["Permission Group"].Value.ToString(),
					                      r.Cells["Permission"].Value.ToString()
				                     
				                     ) );
					}
				}
			}
			
			MessageBox.Show("Saved Successfully");
			
			this.Close();
		}
		
		void FrmUserLoad(object sender, EventArgs e)
		{
			if(user_id == "")	//new user
			{
				lbl_leavePasswordBlank.Hide();
				// get list of module permissions
				
				DataTable rights_list = new DataTable();
				
				rights_list.Columns.Add("Permission Group");
        		rights_list.Columns.Add("Permission");
        		
        		rights_list.Columns.Add("Access", typeof(bool));
        		
        		foreach( DataRow r in Program.rights_list.Rows )
        		{
        			rights_list.Rows.Add(r["permission_group"], r["permission"]);
        		}
        		
        		dgv_rights.DataSource = rights_list;
        		
        		dgv_rights.Columns["Permission Group"].ReadOnly = true;
        		dgv_rights.Columns["Permission"].ReadOnly = true;
        	
			}
			else	// editing existing user
			{
				
				
				DataTable userTable = Functions.GetTable("select * from "+Program.ModName_lcns+"_users " +
				                                         "where id = '"+user_id+"'");
				
				DataTable PermissionsTable = Functions.GetTable("select * from "+Program.ModName_lcns+"_user_permissions " +
				                                         "where user_id = '"+user_id+"'");
				
				if(userTable == null || userTable.Rows.Count == 0)
				{
					MessageBox.Show("Unable to get data");
					this.Close();
					return;
				}
				
				txb_userID.Text = userTable.Rows[0]["name"].ToString();
				ckb_adminUser.Checked = Convert.ToBoolean( userTable.Rows[0]["is_admin"] );
				
				
				DataTable rights_list = new DataTable();
				
				rights_list.Columns.Add("Permission Group");
        		rights_list.Columns.Add("Permission");
        		
        		rights_list.Columns.Add("Access", typeof(bool));
        		
        		foreach( DataRow r in Program.rights_list.Rows )
        		{
        			DataRow[] permissionRows = PermissionsTable.Select("user_id = '"+user_id+"' and " +
        			                                             "permission_group = '"+r["permission_group"]+"' and " +
        			                                             "permission = '"+r["permission"]+"'");
        			bool permission = false;
        			if(permissionRows.Length > 0)
        			{
        				permission = true;
        			}
        			
        			rights_list.Rows.Add(r["permission_group"], r["permission"], permission);
        		}
        		
        		dgv_rights.DataSource = rights_list;
        		
        		dgv_rights.Columns["Permission Group"].ReadOnly = true;
        		dgv_rights.Columns["Permission"].ReadOnly = true;
			}
		}
		
		void Txb_userIDLeave(object sender, EventArgs e)
		{
			txb_userID.Text = Functions.RemoveSpecial(txb_userID.Text);
		}
		
		void Ckb_adminUserCheckedChanged(object sender, EventArgs e)
		{
			dgv_rights.Enabled = !ckb_adminUser.Checked;
			if(ckb_adminUser.Checked)
			{
				dgv_rights.DefaultCellStyle.BackColor = Color.LightGray;
				
			}
			else
			{
				dgv_rights.DefaultCellStyle.BackColor = Color.White;
			}
			
		}
	}
}
