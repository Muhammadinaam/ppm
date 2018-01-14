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
    public partial class FrmNewAdminUser : Form
    {
        public string userid = "";
        public string password = "";

        public FrmNewAdminUser()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txb_userID.Text == "")
            {
                MessageBox.Show("Please enter User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txb_password.Text == "" || txb_confirmPassword.Text == "")
            {
                MessageBox.Show("Please enter password and confirm password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txb_password.Text !=  txb_confirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txb_password.Text == txb_confirmPassword.Text && txb_userID.Text != "")
            {
                userid = txb_userID.Text;
                password = txb_password.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            
        }

        private void FrmNewAdminUser_Load(object sender, EventArgs e)
        {

        }

        private void txb_userID_Leave(object sender, EventArgs e)
        {
            string oldText = txb_userID.Text;
            if (oldText != Functions.RemoveSpecial(txb_userID.Text))
            {
                MessageBox.Show("User ID cannot contain special characters");
                txb_userID.Text = Functions.RemoveSpecial(txb_userID.Text);
                txb_userID.Focus();
            }
        }
    }
}
