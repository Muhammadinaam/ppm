namespace Module
{
    partial class ExceptionMB
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
            this.lbl_exceptionMSG = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Detail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_exceptionMSG
            // 
            this.lbl_exceptionMSG.Location = new System.Drawing.Point(12, 9);
            this.lbl_exceptionMSG.Name = "lbl_exceptionMSG";
            this.lbl_exceptionMSG.Size = new System.Drawing.Size(548, 79);
            this.lbl_exceptionMSG.TabIndex = 0;
            this.lbl_exceptionMSG.Text = "...";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(485, 91);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Detail
            // 
            this.btn_Detail.Location = new System.Drawing.Point(404, 91);
            this.btn_Detail.Name = "btn_Detail";
            this.btn_Detail.Size = new System.Drawing.Size(75, 23);
            this.btn_Detail.TabIndex = 2;
            this.btn_Detail.Text = "Detail";
            this.btn_Detail.UseVisualStyleBackColor = true;
            this.btn_Detail.Click += new System.EventHandler(this.btn_Detail_Click);
            // 
            // ExceptionMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 126);
            this.Controls.Add(this.btn_Detail);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_exceptionMSG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionMB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_exceptionMSG;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Detail;
    }
}