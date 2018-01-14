/*
 * Created by SharpDevelop.
 * User: Inaam Munir
 * Date: 30/01/2017
 * Time: 12:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Module
{
	/// <summary>
	/// Description of FrmChangePassword.
	/// </summary>
	public partial class FrmChangePassword : Form
	{
		public FrmChangePassword()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_okClick(object sender, EventArgs e)
		{
			DataTable dt = Functions.GetTable("select name, password from " 
                            +Program.ModName_lcns+ "_users where name = '"+Program.currentUSER+"'");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Old password did not match.");
				return;
            }
            else
            {
                string decryptedPassword = StringCipher.Decrypt(dt.Rows[0]["password"].ToString(), Program.EncryptionKey);
                if ( string.Compare(decryptedPassword, txb_old_password.Text) != 0 )
                {
                    MessageBox.Show("Old password did not match.");
				return;
                }
                
            }
            
            if(txb_new_password.Text == "")
            {
            	MessageBox.Show("Please enter new password");
            	return;
            }
			
			
			if( txb_new_password.Text != txb_confirmPassword.Text )
			{
				MessageBox.Show("Password and Confirm Password did not match.");
				return;
			}
			
			Functions.SqlNonQuery( "update " +
			                      Program.ModName_lcns + "_users set password = '"+
			                      StringCipher.Encrypt(txb_new_password.Text,Program.EncryptionKey)+"' " );
		}
	}
}
