/*
 * Created by SharpDevelop.
 * User: Inaam
 * Date: 1/30/2017
 * Time: 3:09 PM
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
	/// Description of FrmUsers.
	/// </summary>
	public partial class FrmUsersList : Form
	{
		public FrmUsersList()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FrmUsersLoad(object sender, EventArgs e)
		{
			RefreshList();
		}
		
		void RefreshList()
		{
			DataTable usersDT = Functions.GetTable("select id as 'System ID', Name as 'Name / User ID', " +
			                                       "is_admin as 'Is Admin' from "+Program.ModName_lcns+"_users ");
			
			dgv_users.DataSource = usersDT;
		}
		
		public new void Show()
		{
		    
		    if( Functions.hasPermission("Users Management", "View List") == false )
			{
				MessageBox.Show("You don't have rights to perform this action.");
				this.Close();
				this.Dispose();
			}
		    else
		    	base.Show();
		}
		
		
		void Btn_NewUserClick(object sender, EventArgs e)
		{
			if( Functions.hasPermission("Users Management", "New User") == false )
			{
				MessageBox.Show("You don't have rights to perform this action.");
				return;
			}
			FrmUser F = new FrmUser();
			F.ShowDialog();
			
			RefreshList();
		}
		
		void Btn_edit_selectedUserClick(object sender, EventArgs e)
		{
			if( Functions.hasPermission("Users Management", "Edit User") == false )
			{
				MessageBox.Show("You don't have rights to perform this action.");
				return;
			}
			
			if(dgv_users.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select user to edit!");
				return;
			}
			
			FrmUser F = new FrmUser();
			
			F.user_id = dgv_users.SelectedRows[0].Cells["System ID"].Value.ToString();
			
			F.ShowDialog();
			
			RefreshList();
		}
	}
}
