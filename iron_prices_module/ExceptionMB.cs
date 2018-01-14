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
    public partial class ExceptionMB : Form
    {
        Exception EX = new Exception();

        public ExceptionMB()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Detail_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EX.ToString(), "Exception Detail");
        }

        public void ShowMB(Exception ex)
        {


            EX = ex;
            lbl_exceptionMSG.Text = EX.Message;
            if (this.Visible == false)
                this.ShowDialog();
        }
    }
}
