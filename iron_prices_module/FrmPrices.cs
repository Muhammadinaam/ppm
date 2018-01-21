/*
 * Created by SharpDevelop.
 * User: Inaam
 * Date: 2/2/2017
 * Time: 4:06 PM
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
	/// Description of FrmPrices.
	/// </summary>
	public partial class FrmPrices : Form
	{
        string factor_table = Program.ModName_lcns + "_factor";

        public FrmPrices()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FrmPricesLoad(object sender, EventArgs e)
		{
			refreshDGV();
		}
		
		void refreshDGV()
		{

            decimal supply_rate = Functions.ParseDecimal( Functions.GetOptionValuesFromDB("ppm_supply_rate")[0] );

            txb_supply_rate.Text = supply_rate.ToString();


            

            DataTable dt = Functions.GetTable("select coa.name as Item, coa.UOM, " + factor_table + ".Factor from coa " +
                "left join " + factor_table + " on coa.name = " + factor_table + ".coa_name " +
                "where coa.type in ('Raw Material', 'WIP-Material', 'Finished goods')");

            dt.Columns.Add("Sale Rate", typeof(decimal));

            foreach (DataRow r in dt.Rows)
            {
                r["Sale Rate"] = Functions.ParseDecimal( r["Factor"].ToString() ) * Functions.ParseDecimal( txb_supply_rate.Text );
            }

            dgv_prices.DataSource = dt;

            dgv_prices.Columns["Factor"].DefaultCellStyle.Format = "#,0.00;(0,0.00)";
            dgv_prices.Columns["Sale Rate"].DefaultCellStyle.Format = "#,0.00;(0,0.00)";
        }

        private void btn_changeSupplyRate_Click(object sender, EventArgs e)
        {
            FrmAmountInput f = new FrmAmountInput();
            f.lbl_inputLabel.Text = "Enter Supply Rate";

            if (f.ShowDialog() == DialogResult.OK)
            {
                txb_supply_rate.Text = f.txb_input.Text;
                Functions.SetOptionValues("ppm_supply_rate", new string[] { txb_supply_rate.Text, "", "", "", "", "" });
                refreshDGV();
            }
        }

        private void btn_change_factor_Click(object sender, EventArgs e)
        {
            if (dgv_prices.SelectedRows.Count == 0)
            {
                MessageBox.Show( "Please select atleast one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }

            FrmAmountInput f = new FrmAmountInput();
            f.lbl_inputLabel.Text = "Enter Factor";

            if (f.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow r in dgv_prices.SelectedRows)
                {
                    
                    
                    
                    Functions.SqlNonQuery( string.Format( "replace into {0} (coa_name, factor) values ('{1}','{2}')", factor_table, r.Cells["Item"].Value, f.txb_input.Text  ) );
                    
                    r.Cells["Factor"].Value = f.txb_input.Text;

                    
                }

                refreshDGV();
            }
        }
    }
}
