/*
 * Created by SharpDevelop.
 * User: Inaam Munir
 * Date: 06/02/2017
 * Time: 01:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Module
{
	/// <summary>
	/// Description of FrmAmountInput.
	/// </summary>
	public partial class FrmAmountInput : Form
	{
		public FrmAmountInput()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Txb_inputKeyPress(object sender, KeyPressEventArgs e)
		{
			Functions.NumericKeyPressOnly(sender, e);
		}
		
		void Btn_okClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
