/*
 * Created by SharpDevelop.
 * User: Inaam
 * Date: 2/2/2017
 * Time: 4:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Module
{
	partial class FrmPrices
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
			this.dgv_prices = new System.Windows.Forms.DataGridView();
			this.btn_changeStandardPrice = new System.Windows.Forms.Button();
			this.btn_changeMarginPercent = new System.Windows.Forms.Button();
			this.btn_changePriceBeforeDisc = new System.Windows.Forms.Button();
			this.btn_changeDiscountPercent = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_prices)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_prices
			// 
			this.dgv_prices.AllowUserToAddRows = false;
			this.dgv_prices.AllowUserToDeleteRows = false;
			this.dgv_prices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_prices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_prices.Location = new System.Drawing.Point(12, 12);
			this.dgv_prices.Name = "dgv_prices";
			this.dgv_prices.ReadOnly = true;
			this.dgv_prices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_prices.Size = new System.Drawing.Size(685, 362);
			this.dgv_prices.TabIndex = 0;
			this.dgv_prices.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.Dgv_pricesColumnAdded);
			// 
			// btn_changeStandardPrice
			// 
			this.btn_changeStandardPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_changeStandardPrice.Location = new System.Drawing.Point(564, 385);
			this.btn_changeStandardPrice.Name = "btn_changeStandardPrice";
			this.btn_changeStandardPrice.Size = new System.Drawing.Size(133, 23);
			this.btn_changeStandardPrice.TabIndex = 1;
			this.btn_changeStandardPrice.Text = "Change Standard Price";
			this.btn_changeStandardPrice.UseVisualStyleBackColor = true;
			this.btn_changeStandardPrice.Click += new System.EventHandler(this.Btn_changeStandardPriceClick);
			// 
			// btn_changeMarginPercent
			// 
			this.btn_changeMarginPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_changeMarginPercent.Location = new System.Drawing.Point(425, 385);
			this.btn_changeMarginPercent.Name = "btn_changeMarginPercent";
			this.btn_changeMarginPercent.Size = new System.Drawing.Size(133, 23);
			this.btn_changeMarginPercent.TabIndex = 2;
			this.btn_changeMarginPercent.Text = "Change Margin (%)";
			this.btn_changeMarginPercent.UseVisualStyleBackColor = true;
			this.btn_changeMarginPercent.Click += new System.EventHandler(this.Btn_changeMarginPercentClick);
			// 
			// btn_changePriceBeforeDisc
			// 
			this.btn_changePriceBeforeDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_changePriceBeforeDisc.Location = new System.Drawing.Point(254, 385);
			this.btn_changePriceBeforeDisc.Name = "btn_changePriceBeforeDisc";
			this.btn_changePriceBeforeDisc.Size = new System.Drawing.Size(165, 23);
			this.btn_changePriceBeforeDisc.TabIndex = 3;
			this.btn_changePriceBeforeDisc.Text = "Change Price before Discount";
			this.btn_changePriceBeforeDisc.UseVisualStyleBackColor = true;
			this.btn_changePriceBeforeDisc.Click += new System.EventHandler(this.Btn_changePriceBeforeDiscClick);
			// 
			// btn_changeDiscountPercent
			// 
			this.btn_changeDiscountPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_changeDiscountPercent.Location = new System.Drawing.Point(130, 385);
			this.btn_changeDiscountPercent.Name = "btn_changeDiscountPercent";
			this.btn_changeDiscountPercent.Size = new System.Drawing.Size(118, 23);
			this.btn_changeDiscountPercent.TabIndex = 4;
			this.btn_changeDiscountPercent.Text = "Change Discount (%)";
			this.btn_changeDiscountPercent.UseVisualStyleBackColor = true;
			this.btn_changeDiscountPercent.Click += new System.EventHandler(this.Btn_changeDiscountPercentClick);
			// 
			// FrmPrices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(709, 420);
			this.Controls.Add(this.btn_changeDiscountPercent);
			this.Controls.Add(this.btn_changePriceBeforeDisc);
			this.Controls.Add(this.btn_changeMarginPercent);
			this.Controls.Add(this.btn_changeStandardPrice);
			this.Controls.Add(this.dgv_prices);
			this.Name = "FrmPrices";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Prices";
			this.Load += new System.EventHandler(this.FrmPricesLoad);
			((System.ComponentModel.ISupportInitialize)(this.dgv_prices)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btn_changeDiscountPercent;
		private System.Windows.Forms.Button btn_changePriceBeforeDisc;
		private System.Windows.Forms.Button btn_changeMarginPercent;
		private System.Windows.Forms.Button btn_changeStandardPrice;
		private System.Windows.Forms.DataGridView dgv_prices;
	}
}
