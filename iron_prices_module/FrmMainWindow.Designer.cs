namespace Module
{
    partial class FrmMainWindow
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainWindow));
        	this.MainMenu = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.connectionConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.priceManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.usersAndSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.tabForms = new System.Windows.Forms.TabControl();
        	this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        	this.MainMenu.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// MainMenu
        	// 
        	this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.priceManagementToolStripMenuItem,
        	        	        	this.usersAndSecurityToolStripMenuItem});
        	this.MainMenu.Location = new System.Drawing.Point(0, 0);
        	this.MainMenu.Name = "MainMenu";
        	this.MainMenu.Size = new System.Drawing.Size(744, 24);
        	this.MainMenu.TabIndex = 1;
        	this.MainMenu.Text = "menuStrip1";
        	// 
        	// fileToolStripMenuItem
        	// 
        	this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.openToolStripMenuItem,
        	        	        	this.connectionConfigurationToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem.Text = "File";
        	// 
        	// openToolStripMenuItem
        	// 
        	this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        	this.openToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
        	this.openToolStripMenuItem.Text = "Open";
        	this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
        	// 
        	// connectionConfigurationToolStripMenuItem
        	// 
        	this.connectionConfigurationToolStripMenuItem.Name = "connectionConfigurationToolStripMenuItem";
        	this.connectionConfigurationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
        	this.connectionConfigurationToolStripMenuItem.Text = "Connection Configuration";
        	this.connectionConfigurationToolStripMenuItem.Click += new System.EventHandler(this.connectionConfigurationToolStripMenuItem_Click);
        	// 
        	// priceManagementToolStripMenuItem
        	// 
        	this.priceManagementToolStripMenuItem.Name = "priceManagementToolStripMenuItem";
        	this.priceManagementToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
        	this.priceManagementToolStripMenuItem.Text = "Prices Management";
        	this.priceManagementToolStripMenuItem.Click += new System.EventHandler(this.PriceManagementToolStripMenuItemClick);
        	// 
        	// usersAndSecurityToolStripMenuItem
        	// 
        	this.usersAndSecurityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.usersToolStripMenuItem,
        	        	        	this.changePasswordToolStripMenuItem});
        	this.usersAndSecurityToolStripMenuItem.Name = "usersAndSecurityToolStripMenuItem";
        	this.usersAndSecurityToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
        	this.usersAndSecurityToolStripMenuItem.Text = "Users and Security";
        	// 
        	// usersToolStripMenuItem
        	// 
        	this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
        	this.usersToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        	this.usersToolStripMenuItem.Text = "Users";
        	this.usersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItemClick);
        	// 
        	// changePasswordToolStripMenuItem
        	// 
        	this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
        	this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
        	this.changePasswordToolStripMenuItem.Text = "Change Password";
        	this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordToolStripMenuItemClick);
        	// 
        	// tabForms
        	// 
        	this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
        	this.tabForms.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
        	this.tabForms.ItemSize = new System.Drawing.Size(150, 40);
        	this.tabForms.Location = new System.Drawing.Point(0, 24);
        	this.tabForms.Name = "tabForms";
        	this.tabForms.SelectedIndex = 0;
        	this.tabForms.Size = new System.Drawing.Size(744, 33);
        	this.tabForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        	this.tabForms.TabIndex = 3;
        	this.tabForms.Visible = false;
        	this.tabForms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabForms_DrawItem);
        	this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
        	this.tabForms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDown);
        	this.tabForms.MouseLeave += new System.EventHandler(this.tabForms_MouseLeave);
        	this.tabForms.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseMove);
        	// 
        	// imageList1
        	// 
        	this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
        	this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        	this.imageList1.Images.SetKeyName(0, "cb1.png");
        	this.imageList1.Images.SetKeyName(1, "cb2.png");
        	// 
        	// FrmMainWindow
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(744, 345);
        	this.Controls.Add(this.tabForms);
        	this.Controls.Add(this.MainMenu);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.IsMdiContainer = true;
        	this.MainMenuStrip = this.MainMenu;
        	this.Name = "FrmMainWindow";
        	this.Text = "Empty Module";
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this.Load += new System.EventHandler(this.FrmMainWindow_Load);
        	this.MdiChildActivate += new System.EventHandler(this.FrmMainWindow_MdiChildActivate);
        	this.MainMenu.ResumeLayout(false);
        	this.MainMenu.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem priceManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersAndSecurityToolStripMenuItem;

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionConfigurationToolStripMenuItem;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.ImageList imageList1;
    }
}

