using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module
{
    public partial class FrmMainWindow : Form
    {
        //variables for tabForms
        int Xwid = 10;
        int tab_margin = 3;

        public FrmMainWindow()
        {
            InitializeComponent();
        }

        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
        	if(Program.ThisModuleName == "" || Program.ModName_lcns == "")
            {
            	MessageBox.Show("Please set module name in program.cs file.");
            	this.Close();
            }
        	
        	this.Text = Program.ThisModuleName;
        	
            FrmOpenCompany F = new FrmOpenCompany();
            F.ShowDialog();
	
            
            
        }

        private void connectionConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConnectionConfig fc = new FrmConnectionConfig();
            fc.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOpenCompany f = new FrmOpenCompany();
            f.ShowDialog();
        }

        public void EnableMenues(bool enable)
        {
            priceManagementToolStripMenuItem.Visible = enable;
            usersAndSecurityToolStripMenuItem.Visible = enable;
        }

        private void FrmMainWindow_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            // If no any child form, hide tabControl 
            else
            {
                this.ActiveMdiChild.WindowState =
                FormWindowState.Maximized;
                // Child form always maximized 

                // If child form is new and no has tabPage, 
                // create new tabPage 
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage(this.ActiveMdiChild
                                             .Text);


                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                        new FormClosedEventHandler(
                                        ActiveMdiChild_FormClosed);
                    this.ActiveMdiChild.Disposed +=
                        new EventHandler(
                                        ActiveMdiChild_FormDisposed);

                }
                else
                {
                    //tabForms.TabPages[this.ActiveMdiChild.Tag].ShowIfHasRights();
                    tabForms.SelectedTab = this.ActiveMdiChild.Tag as TabPage;
                }

                if (!tabForms.Visible) tabForms.Visible = true;

            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void ActiveMdiChild_FormDisposed(object sender, EventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabForms.SelectedTab != null) && (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as Form).Select();
        }

        private void tabForms_DrawItem(object sender, DrawItemEventArgs e)
        {
            //tab backgrounds
            SolidBrush fillbrush = new SolidBrush(Color.LightGray);

            //draw horizontal line on unselected tabs
            Rectangle firsttabrect = tabForms.GetTabRect(0);
            Rectangle background = new Rectangle();
            background.Location = new Point(firsttabrect.Left - 1, 0);

            background.Size = new Size(tabForms.Right - background.Left, 3);
            e.Graphics.FillRectangle(fillbrush, background);

            //draw vertical line on left side of first unselected tab
            firsttabrect = tabForms.GetTabRect(0);
            background = new Rectangle();
            background.Location = new Point(0, 0);

            background.Size = new Size(0 + firsttabrect.Left, tabForms.Height + 1);
            e.Graphics.FillRectangle(fillbrush, background);

            //draw background from last tab
            Rectangle lasttabrect = tabForms.GetTabRect(tabForms.TabPages.Count - 1);
            background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);

            background.Size = new Size(tabForms.Right - lasttabrect.Right, tabForms.Height + 1);
            e.Graphics.FillRectangle(fillbrush, background);
            //tab backgrounds



            Brush txt_brush, box_brush;
            Pen box_pen;

            // We draw in the TabRect rather than on e.Bounds
            // so we can use TabRect later in MouseDown.
            Rectangle tab_rect = tabForms.GetTabRect(e.Index);

            // Draw the background.
            // Pick appropriate pens and brushes.
            if (e.State == DrawItemState.Selected)
            {
                Color bc = Color.LightGray;
                SolidBrush b = new SolidBrush(Color.FromArgb(bc.A / 2, bc.R, bc.G, bc.B));
                e.Graphics.FillRectangle(b, tab_rect);
                e.DrawFocusRectangle();

                txt_brush = new SolidBrush(Color.Black);
                box_brush = Brushes.Red;
                box_pen = new Pen(Color.LightGray);
            }
            else
            {
                SolidBrush b = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(b, tab_rect);

                txt_brush = new SolidBrush(Color.Black);
                box_brush = Brushes.Red;
                box_pen = new Pen(Color.LightGray);
            }

            // Allow room for margins.
            RectangleF layout_rect = new RectangleF(
                tab_rect.Left + tab_margin,
                tab_rect.Y + tab_margin,
                tab_rect.Width - 2 * tab_margin,
                tab_rect.Height - 2 * tab_margin);
            using (StringFormat string_format = new StringFormat())
            {
                // Draw the tab # in the upper left corner.
                using (Font small_font = new Font(this.Font.FontFamily,
                    6, FontStyle.Regular))
                {
                    string_format.Alignment = StringAlignment.Near;
                    string_format.LineAlignment = StringAlignment.Near;
                    e.Graphics.DrawString(
                        e.Index.ToString(),
                        small_font,
                        txt_brush,
                        layout_rect,
                        string_format);
                }

                // Draw the tab's text centered.
                using (Font big_font = new Font(this.Font, FontStyle.Regular))
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(
                        tabForms.TabPages[e.Index].Text,
                        big_font,
                        txt_brush,
                        layout_rect,
                        string_format);
                }

                // Draw an X in the upper right corner.
                Rectangle rect = tabForms.GetTabRect(e.Index);
                e.Graphics.DrawImage(imageList1.Images[0], layout_rect.Right - Xwid, layout_rect.Top, Xwid, Xwid);


                /*Rectangle rect = tabForms.GetTabRect(e.Index);
		        e.Graphics.FillRectangle(box_brush,
		            layout_rect.Right - Xwid,
		            layout_rect.Top,
		            Xwid,
		            Xwid);
		        e.Graphics.DrawRectangle(box_pen,
		            layout_rect.Right - Xwid,
		            layout_rect.Top,
		            Xwid,
		            Xwid);
		        e.Graphics.DrawLine(box_pen,
		            layout_rect.Right - Xwid,
		            layout_rect.Top,
		            layout_rect.Right,
		            layout_rect.Top + Xwid);
		        e.Graphics.DrawLine(box_pen,
		            layout_rect.Right - Xwid,
		            layout_rect.Top + Xwid,
		            layout_rect.Right,
		            layout_rect.Top);*/
            }
        }

        private void tabForms_MouseDown(object sender, MouseEventArgs e)
        {
            /*/Looping through the controls.
			for (int i = 0; i < this.tabForms.TabPages.Count; i++)
			{
			    Rectangle r = tabForms.GetTabRect(i);
			   //Getting the position of the "x" mark.
			    Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
			    if (closeButton.Contains(e.Location))
			    {
			        //if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			        //{
			        	(this.tabForms.TabPages[i].Tag as Form).Close();
			            //this.tabForms.TabPages.RemoveAt(i);
			            
			            break;
			        //}
			    }
			}//Looping through the controls.*/

            // See if this is over a tab.
            for (int i = 0; i < tabForms.TabPages.Count; i++)
            {
                // Get the TabRect plus room for margins.
                Rectangle tab_rect = tabForms.GetTabRect(i);
                RectangleF rect = new RectangleF(
                    tab_rect.Left + tab_margin,
                    tab_rect.Y + tab_margin,
                    tab_rect.Width - 2 * tab_margin,
                    tab_rect.Height - 2 * tab_margin);
                if (e.X >= rect.Right - Xwid &&
                    e.X <= rect.Right &&
                    e.Y >= rect.Top &&
                    e.Y <= rect.Top + Xwid)
                {
                    (this.tabForms.TabPages[i].Tag as Form).Close();
                    return;
                }
            }
        }

        private void tabForms_MouseMove(object sender, MouseEventArgs e)
        {
            // See if this is over a tab.
            for (int i = 0; i < tabForms.TabPages.Count; i++)
            {
                // Get the TabRect plus room for margins.
                Rectangle tab_rect = tabForms.GetTabRect(i);
                RectangleF rect = new RectangleF(
                    tab_rect.Left + tab_margin,
                    tab_rect.Y + tab_margin,
                    tab_rect.Width - 2 * tab_margin,
                    tab_rect.Height - 2 * tab_margin);
                if (e.X >= rect.Right - Xwid &&
                    e.X <= rect.Right &&
                    e.Y >= rect.Top &&
                    e.Y <= rect.Top + Xwid)
                {

                    Graphics g = tabForms.CreateGraphics();
                    g.DrawImage(imageList1.Images[1], rect.Right - Xwid, rect.Top, Xwid, Xwid);
                }
                else
                {
                    Graphics g = tabForms.CreateGraphics();
                    g.DrawImage(imageList1.Images[0], rect.Right - Xwid, rect.Top, Xwid, Xwid);
                }
            }
        }

        private void tabForms_MouseLeave(object sender, EventArgs e)
        {
            // See if this is over a tab.
            for (int i = 0; i < tabForms.TabPages.Count; i++)
            {
                // Get the TabRect plus room for margins.
                Rectangle tab_rect = tabForms.GetTabRect(i);
                RectangleF rect = new RectangleF(
                    tab_rect.Left + tab_margin,
                    tab_rect.Y + tab_margin,
                    tab_rect.Width - 2 * tab_margin,
                    tab_rect.Height - 2 * tab_margin);
                if (MousePosition.X >= rect.Right - Xwid &&
                    MousePosition.X <= rect.Right &&
                    MousePosition.Y >= rect.Top &&
                    MousePosition.Y <= rect.Top + Xwid)
                {

                    Graphics g = tabForms.CreateGraphics();
                    g.DrawImage(imageList1.Images[1], rect.Right - Xwid, rect.Top, Xwid, Xwid);
                }
                else
                {
                    Graphics g = tabForms.CreateGraphics();
                    g.DrawImage(imageList1.Images[0], rect.Right - Xwid, rect.Top, Xwid, Xwid);
                }
            }
        }

        
        
        void ChangePasswordToolStripMenuItemClick(object sender, EventArgs e)
        {
        	FrmChangePassword fcp = new FrmChangePassword();
        	fcp.ShowDialog();
        }
        
        void UsersToolStripMenuItemClick(object sender, EventArgs e)
        {
        	FrmUsersList FU = new FrmUsersList();
        	FU.MdiParent = this;
        	FU.Show();
        }
        
        void PriceManagementToolStripMenuItemClick(object sender, EventArgs e)
        {
        	if( Functions.hasPermission("Prices Management", "View List") == false )
        	{
        		MessageBox.Show("You do not have rights to perform this action.", "No Rights", MessageBoxButtons.OK, MessageBoxIcon.Error);
        		return;
        	}
        	
        	FrmPrices F = new FrmPrices();
        	
        	F.MdiParent = this;
        	F.Show();
        }
    }
}
