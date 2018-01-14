/*
 * Created by SharpDevelop.
 * User: Inaam Munir
 * Date: 31/01/2017
 * Time: 01:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Module
{
	partial class FrmUser
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
			this.txb_confirmPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txb_password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txb_userID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgv_rights = new System.Windows.Forms.DataGridView();
			this.btn_Save = new System.Windows.Forms.Button();
			this.ckb_adminUser = new System.Windows.Forms.CheckBox();
			this.lbl_leavePasswordBlank = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv_rights)).BeginInit();
			this.SuspendLayout();
			// 
			// txb_confirmPassword
			// 
			this.txb_confirmPassword.Location = new System.Drawing.Point(12, 125);
			this.txb_confirmPassword.Name = "txb_confirmPassword";
			this.txb_confirmPassword.Size = new System.Drawing.Size(215, 20);
			this.txb_confirmPassword.TabIndex = 12;
			this.txb_confirmPassword.UseSystemPasswordChar = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Confirm Password";
			// 
			// txb_password
			// 
			this.txb_password.Location = new System.Drawing.Point(12, 80);
			this.txb_password.Name = "txb_password";
			this.txb_password.Size = new System.Drawing.Size(215, 20);
			this.txb_password.TabIndex = 10;
			this.txb_password.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Password";
			// 
			// txb_userID
			// 
			this.txb_userID.Location = new System.Drawing.Point(12, 35);
			this.txb_userID.Name = "txb_userID";
			this.txb_userID.Size = new System.Drawing.Size(215, 20);
			this.txb_userID.TabIndex = 8;
			this.txb_userID.Leave += new System.EventHandler(this.Txb_userIDLeave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "User ID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 161);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Rights";
			// 
			// dgv_rights
			// 
			this.dgv_rights.AllowUserToAddRows = false;
			this.dgv_rights.AllowUserToDeleteRows = false;
			this.dgv_rights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_rights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_rights.Location = new System.Drawing.Point(12, 177);
			this.dgv_rights.Name = "dgv_rights";
			this.dgv_rights.Size = new System.Drawing.Size(732, 214);
			this.dgv_rights.TabIndex = 14;
			// 
			// btn_Save
			// 
			this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Save.Location = new System.Drawing.Point(669, 407);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(75, 23);
			this.btn_Save.TabIndex = 15;
			this.btn_Save.Text = "Save";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.Btn_SaveClick);
			// 
			// ckb_adminUser
			// 
			this.ckb_adminUser.Location = new System.Drawing.Point(243, 33);
			this.ckb_adminUser.Name = "ckb_adminUser";
			this.ckb_adminUser.Size = new System.Drawing.Size(150, 24);
			this.ckb_adminUser.TabIndex = 16;
			this.ckb_adminUser.Text = "Admin User (has all rights)";
			this.ckb_adminUser.UseVisualStyleBackColor = true;
			this.ckb_adminUser.CheckedChanged += new System.EventHandler(this.Ckb_adminUserCheckedChanged);
			// 
			// lbl_leavePasswordBlank
			// 
			this.lbl_leavePasswordBlank.AutoSize = true;
			this.lbl_leavePasswordBlank.Location = new System.Drawing.Point(233, 83);
			this.lbl_leavePasswordBlank.Name = "lbl_leavePasswordBlank";
			this.lbl_leavePasswordBlank.Size = new System.Drawing.Size(176, 13);
			this.lbl_leavePasswordBlank.TabIndex = 17;
			this.lbl_leavePasswordBlank.Text = "(Leave blank to keep old password)";
			// 
			// FrmUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(756, 442);
			this.Controls.Add(this.lbl_leavePasswordBlank);
			this.Controls.Add(this.ckb_adminUser);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.dgv_rights);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txb_confirmPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txb_password);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txb_userID);
			this.Controls.Add(this.label2);
			this.Name = "FrmUser";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "User";
			this.Load += new System.EventHandler(this.FrmUserLoad);
			((System.ComponentModel.ISupportInitialize)(this.dgv_rights)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lbl_leavePasswordBlank;
		private System.Windows.Forms.CheckBox ckb_adminUser;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.DataGridView dgv_rights;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txb_userID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txb_password;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txb_confirmPassword;
		private System.Windows.Forms.Label label1;
	}
}
