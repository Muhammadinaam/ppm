/*
 * Created by SharpDevelop.
 * User: Inaam Munir
 * Date: 30/01/2017
 * Time: 12:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Module
{
	partial class FrmChangePassword
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
			this.btn_ok = new System.Windows.Forms.Button();
			this.txb_confirmPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txb_new_password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txb_old_password = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(12, 153);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(215, 36);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// txb_confirmPassword
			// 
			this.txb_confirmPassword.Location = new System.Drawing.Point(12, 115);
			this.txb_confirmPassword.Name = "txb_confirmPassword";
			this.txb_confirmPassword.Size = new System.Drawing.Size(215, 20);
			this.txb_confirmPassword.TabIndex = 2;
			this.txb_confirmPassword.UseSystemPasswordChar = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 99);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Confirm Password";
			// 
			// txb_new_password
			// 
			this.txb_new_password.Location = new System.Drawing.Point(12, 70);
			this.txb_new_password.Name = "txb_new_password";
			this.txb_new_password.Size = new System.Drawing.Size(215, 20);
			this.txb_new_password.TabIndex = 1;
			this.txb_new_password.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "New Password";
			// 
			// txb_old_password
			// 
			this.txb_old_password.Location = new System.Drawing.Point(12, 25);
			this.txb_old_password.Name = "txb_old_password";
			this.txb_old_password.Size = new System.Drawing.Size(215, 20);
			this.txb_old_password.TabIndex = 0;
			this.txb_old_password.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Old Password";
			// 
			// FrmChangePassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(242, 219);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.txb_confirmPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txb_new_password);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txb_old_password);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmChangePassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change Password";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txb_old_password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txb_new_password;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txb_confirmPassword;
		private System.Windows.Forms.Button btn_ok;
	}
}
