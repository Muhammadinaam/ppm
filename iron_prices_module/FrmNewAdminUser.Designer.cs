namespace Module
{
    partial class FrmNewAdminUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_userID = new System.Windows.Forms.TextBox();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_confirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter information for the Admin User\r\n(Admin user will have all rights / permissi" +
    "ons)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Admin User ID";
            // 
            // txb_userID
            // 
            this.txb_userID.Location = new System.Drawing.Point(12, 72);
            this.txb_userID.Name = "txb_userID";
            this.txb_userID.Size = new System.Drawing.Size(215, 20);
            this.txb_userID.TabIndex = 2;
            this.txb_userID.Leave += new System.EventHandler(this.txb_userID_Leave);
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(12, 117);
            this.txb_password.Name = "txb_password";
            this.txb_password.Size = new System.Drawing.Size(215, 20);
            this.txb_password.TabIndex = 4;
            this.txb_password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // txb_confirmPassword
            // 
            this.txb_confirmPassword.Location = new System.Drawing.Point(12, 162);
            this.txb_confirmPassword.Name = "txb_confirmPassword";
            this.txb_confirmPassword.Size = new System.Drawing.Size(215, 20);
            this.txb_confirmPassword.TabIndex = 6;
            this.txb_confirmPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confirm Password";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 200);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(215, 36);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // FrmNewAdminUser
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 248);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_confirmPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_userID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewAdminUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Admin User";
            this.Load += new System.EventHandler(this.FrmNewAdminUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_userID;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_confirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ok;
    }
}