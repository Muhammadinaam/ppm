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
            this.label1 = new System.Windows.Forms.Label();
            this.txb_supply_rate = new System.Windows.Forms.TextBox();
            this.btn_changeSupplyRate = new System.Windows.Forms.Button();
            this.btn_change_factor = new System.Windows.Forms.Button();
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
            this.dgv_prices.Location = new System.Drawing.Point(12, 32);
            this.dgv_prices.Name = "dgv_prices";
            this.dgv_prices.ReadOnly = true;
            this.dgv_prices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_prices.Size = new System.Drawing.Size(685, 376);
            this.dgv_prices.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supply Rate";
            // 
            // txb_supply_rate
            // 
            this.txb_supply_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_supply_rate.Location = new System.Drawing.Point(83, 6);
            this.txb_supply_rate.Name = "txb_supply_rate";
            this.txb_supply_rate.ReadOnly = true;
            this.txb_supply_rate.Size = new System.Drawing.Size(75, 20);
            this.txb_supply_rate.TabIndex = 2;
            this.txb_supply_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_changeSupplyRate
            // 
            this.btn_changeSupplyRate.Location = new System.Drawing.Point(164, 4);
            this.btn_changeSupplyRate.Name = "btn_changeSupplyRate";
            this.btn_changeSupplyRate.Size = new System.Drawing.Size(123, 23);
            this.btn_changeSupplyRate.TabIndex = 3;
            this.btn_changeSupplyRate.Text = "Change Supply Rate";
            this.btn_changeSupplyRate.UseVisualStyleBackColor = true;
            this.btn_changeSupplyRate.Click += new System.EventHandler(this.btn_changeSupplyRate_Click);
            // 
            // btn_change_factor
            // 
            this.btn_change_factor.Location = new System.Drawing.Point(498, 3);
            this.btn_change_factor.Name = "btn_change_factor";
            this.btn_change_factor.Size = new System.Drawing.Size(199, 23);
            this.btn_change_factor.TabIndex = 4;
            this.btn_change_factor.Text = "Change Factor of Selected Items";
            this.btn_change_factor.UseVisualStyleBackColor = true;
            this.btn_change_factor.Click += new System.EventHandler(this.btn_change_factor_Click);
            // 
            // FrmPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 420);
            this.Controls.Add(this.btn_change_factor);
            this.Controls.Add(this.btn_changeSupplyRate);
            this.Controls.Add(this.txb_supply_rate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_prices);
            this.Name = "FrmPrices";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Prices";
            this.Load += new System.EventHandler(this.FrmPricesLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.DataGridView dgv_prices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_supply_rate;
        private System.Windows.Forms.Button btn_changeSupplyRate;
        private System.Windows.Forms.Button btn_change_factor;
    }
}
