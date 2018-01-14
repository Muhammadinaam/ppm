namespace Module
{
    partial class FrmOpenCompany
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
        	this.components = new System.ComponentModel.Container();
        	this.lb_databases = new System.Windows.Forms.ListBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.txb_userid = new System.Windows.Forms.TextBox();
        	this.txb_password = new System.Windows.Forms.TextBox();
        	this.btn_login = new System.Windows.Forms.Button();
        	this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
        	this.label3 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// lb_databases
        	// 
        	this.lb_databases.FormattingEnabled = true;
        	this.lb_databases.Location = new System.Drawing.Point(12, 12);
        	this.lb_databases.Name = "lb_databases";
        	this.lb_databases.Size = new System.Drawing.Size(362, 160);
        	this.lb_databases.TabIndex = 0;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 201);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(43, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "User ID";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 250);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(53, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Password";
        	// 
        	// txb_userid
        	// 
        	this.txb_userid.Location = new System.Drawing.Point(15, 217);
        	this.txb_userid.Name = "txb_userid";
        	this.txb_userid.Size = new System.Drawing.Size(184, 20);
        	this.txb_userid.TabIndex = 3;
        	// 
        	// txb_password
        	// 
        	this.txb_password.Location = new System.Drawing.Point(15, 266);
        	this.txb_password.Name = "txb_password";
        	this.txb_password.Size = new System.Drawing.Size(184, 20);
        	this.txb_password.TabIndex = 4;
        	this.txb_password.UseSystemPasswordChar = true;
        	// 
        	// btn_login
        	// 
        	this.btn_login.Location = new System.Drawing.Point(231, 215);
        	this.btn_login.Name = "btn_login";
        	this.btn_login.Size = new System.Drawing.Size(143, 71);
        	this.btn_login.TabIndex = 5;
        	this.btn_login.Text = "Login";
        	this.btn_login.UseVisualStyleBackColor = true;
        	this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
        	// 
        	// errorProvider1
        	// 
        	this.errorProvider1.ContainerControl = this;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 175);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(0, 13);
        	this.label3.TabIndex = 6;
        	// 
        	// FrmOpenCompany
        	// 
        	this.AcceptButton = this.btn_login;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(386, 306);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.btn_login);
        	this.Controls.Add(this.txb_password);
        	this.Controls.Add(this.txb_userid);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.lb_databases);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FrmOpenCompany";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Login";
        	this.Load += new System.EventHandler(this.FrmUserAuth_Load);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lb_databases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_userid;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
    }
}