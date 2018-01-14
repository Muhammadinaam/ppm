/*
 * Created by SharpDevelop.
 * User: Inaam
 * Date: 1/30/2017
 * Time: 3:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Module
{
	partial class FrmUsersList
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgv_users = new System.Windows.Forms.DataGridView();
			this.btn_NewUser = new System.Windows.Forms.Button();
			this.btn_edit_selectedUser = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_users)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_users
			// 
			this.dgv_users.AllowUserToAddRows = false;
			this.dgv_users.AllowUserToDeleteRows = false;
			this.dgv_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_users.Location = new System.Drawing.Point(12, 12);
			this.dgv_users.MultiSelect = false;
			this.dgv_users.Name = "dgv_users";
			this.dgv_users.ReadOnly = true;
			this.dgv_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_users.Size = new System.Drawing.Size(617, 364);
			this.dgv_users.TabIndex = 0;
			// 
			// btn_NewUser
			// 
			this.btn_NewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_NewUser.Location = new System.Drawing.Point(554, 382);
			this.btn_NewUser.Name = "btn_NewUser";
			this.btn_NewUser.Size = new System.Drawing.Size(75, 23);
			this.btn_NewUser.TabIndex = 1;
			this.btn_NewUser.Text = "New User";
			this.btn_NewUser.UseVisualStyleBackColor = true;
			this.btn_NewUser.Click += new System.EventHandler(this.Btn_NewUserClick);
			// 
			// btn_edit_selectedUser
			// 
			this.btn_edit_selectedUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_edit_selectedUser.Location = new System.Drawing.Point(432, 382);
			this.btn_edit_selectedUser.Name = "btn_edit_selectedUser";
			this.btn_edit_selectedUser.Size = new System.Drawing.Size(116, 23);
			this.btn_edit_selectedUser.TabIndex = 2;
			this.btn_edit_selectedUser.Text = "Edit Selected User";
			this.btn_edit_selectedUser.UseVisualStyleBackColor = true;
			this.btn_edit_selectedUser.Click += new System.EventHandler(this.Btn_edit_selectedUserClick);
			// 
			// FrmUsersList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(641, 414);
			this.Controls.Add(this.btn_edit_selectedUser);
			this.Controls.Add(this.btn_NewUser);
			this.Controls.Add(this.dgv_users);
			this.Name = "FrmUsersList";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Users";
			this.Load += new System.EventHandler(this.FrmUsersLoad);
			((System.ComponentModel.ISupportInitialize)(this.dgv_users)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_edit_selectedUser;
		private System.Windows.Forms.Button btn_NewUser;
		private System.Windows.Forms.DataGridView dgv_users;
	}
}
