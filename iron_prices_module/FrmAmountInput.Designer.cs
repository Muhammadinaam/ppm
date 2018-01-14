/*
 * Created by SharpDevelop.
 * User: Inaam Munir
 * Date: 06/02/2017
 * Time: 01:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Module
{
	partial class FrmAmountInput
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
			this.lbl_inputLabel = new System.Windows.Forms.Label();
			this.txb_input = new System.Windows.Forms.TextBox();
			this.btn_ok = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_inputLabel
			// 
			this.lbl_inputLabel.Location = new System.Drawing.Point(12, 9);
			this.lbl_inputLabel.Name = "lbl_inputLabel";
			this.lbl_inputLabel.Size = new System.Drawing.Size(173, 23);
			this.lbl_inputLabel.TabIndex = 0;
			this.lbl_inputLabel.Text = "...";
			// 
			// txb_input
			// 
			this.txb_input.Location = new System.Drawing.Point(12, 26);
			this.txb_input.Name = "txb_input";
			this.txb_input.Size = new System.Drawing.Size(166, 20);
			this.txb_input.TabIndex = 1;
			this.txb_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txb_inputKeyPress);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(12, 61);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(166, 23);
			this.btn_ok.TabIndex = 2;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// FrmAmountInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(197, 107);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.txb_input);
			this.Controls.Add(this.lbl_inputLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmAmountInput";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Input";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btn_ok;
		public System.Windows.Forms.TextBox txb_input;
		public System.Windows.Forms.Label lbl_inputLabel;
	}
}
