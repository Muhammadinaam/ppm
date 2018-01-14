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
			
			DataTable pricesTable = Functions.GetTable("select coa.Name as Item, coa.UOM as 'Unit', " +
			                                           " cast( coalesce(" + Program.ModName_lcns + "_standard_prices.standard_price,coa.price) as decimal(40,5) ) as 'Standard Price', " +

								"cast( (coa.price - coalesce(" + Program.ModName_lcns + "_standard_prices.standard_price,coa.price)) / " +
								"(coalesce(" + Program.ModName_lcns + "_standard_prices.standard_price,coa.price) ) * 100 as decimal(40,5) ) as 'Margin (%)', " +
								
								"cast( coa.price as decimal(40,5) ) as 'Price before Discount', coalesce(coa.disc_rate, 0 ) as 'Discount (%)',  " +
								"coa.price * (1-coalesce(coa.disc_rate,0)/100) as 'Price after Discount' " +
								
								"from coa " +
								
								"left join " + Program.ModName_lcns + "_standard_prices on " + Program.ModName_lcns + "_standard_prices.coa_name = coa.Name " +
								
								"where coa.type in ('Raw Material', 'WIP Material', 'Finished Goods') order by coa.name ;");
			dgv_prices.DataSource = pricesTable;
			
			for (int i = 2; i < dgv_prices.Columns.Count; i++)
			{
				dgv_prices.Columns[i].DefaultCellStyle.Format = "0,0.00;(0,0.00)";
				dgv_prices.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgv_prices.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}
		
		void Btn_changeStandardPriceClick(object sender, EventArgs e)
		{
			
			if(dgv_prices.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select atleast one item.");
				return;
			}
			
			
			FrmAmountInput F = new FrmAmountInput();
			
			F.lbl_inputLabel.Text = "Enter new Standard Price";
			
			if(F.ShowDialog() == DialogResult.OK)
			{
				foreach( DataGridViewRow r in dgv_prices.SelectedRows )
				{
					DataTable tempDT = Functions.GetTable( "select * from " + Program.ModName_lcns + "_standard_prices where coa_name = '"+r.Cells["item"].Value.ToString()+"' " );
					
					if(tempDT.Rows.Count == 0)
					{
						Functions.SqlNonQuery( "insert into " + Program.ModName_lcns + "_standard_prices (coa_name, standard_price) values " +
						                      "('"+r.Cells["item"].Value.ToString()+"','"+F.txb_input.Text+"')" );
					}
					else
					{
						Functions.SqlNonQuery("update " + Program.ModName_lcns + "_standard_prices set standard_price = '"+F.txb_input.Text+"' " +
						                      "where id = '"+tempDT.Rows[0]["id"].ToString()+"' ");
					}
				}
				
				MessageBox.Show("Changes saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			refreshDGV();
			}
			
			
		}
		
		void Btn_changeMarginPercentClick(object sender, EventArgs e)
		{
			if(dgv_prices.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select atleast one item.");
				return;
			}
			
			
			FrmAmountInput F = new FrmAmountInput();
			
			F.lbl_inputLabel.Text = "Enter new Margin Value";
			
			if(F.ShowDialog() == DialogResult.OK)
			{
				foreach( DataGridViewRow r in dgv_prices.SelectedRows )
				{
					DataTable tempDT = Functions.GetTable( "select * from " + Program.ModName_lcns + "_standard_prices where coa_name = '"+r.Cells["item"].Value.ToString()+"' " );
					
					if(tempDT.Rows.Count == 0)
					{
						Functions.SqlNonQuery( "insert into " + Program.ModName_lcns + "_standard_prices (coa_name, standard_price) values " +
						                      "('"+r.Cells["item"].Value.ToString()+"','"+r.Cells["Standard Price"].Value.ToString()+"')" );
						
						
					}
					
					
					decimal newPrice = Functions.ParseDecimal( r.Cells["Standard Price"].Value.ToString()) * 
						( 1 + ( Functions.ParseDecimal(F.txb_input.Text)/100 ) );
					
					Functions.SqlNonQuery("update coa set price = '"+newPrice.ToString()+"' " +
					                      "where name = '"+r.Cells["item"].Value.ToString()+"' ");
					
				}
				
				MessageBox.Show("Changes saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				refreshDGV();
			}
			
			
		}
		
		void Btn_changePriceBeforeDiscClick(object sender, EventArgs e)
		{
			if(dgv_prices.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select atleast one item.");
				return;
			}
			
			
			FrmAmountInput F = new FrmAmountInput();
			
			F.lbl_inputLabel.Text = "Enter new Price before discount";
			
			if(F.ShowDialog() == DialogResult.OK)
			{
				foreach( DataGridViewRow r in dgv_prices.SelectedRows )
				{
					DataTable tempDT = Functions.GetTable( "select * from " + Program.ModName_lcns + "_standard_prices where coa_name = '"+r.Cells["item"].Value.ToString()+"' " );
					
					if(tempDT.Rows.Count == 0)
					{
						Functions.SqlNonQuery( "insert into " + Program.ModName_lcns + "_standard_prices (coa_name, standard_price) values " +
						                      "('"+r.Cells["item"].Value.ToString()+"','"+r.Cells["Standard Price"].Value.ToString()+"')" );
						
						
					}
					
					
					decimal newPrice = Functions.ParseDecimal( F.txb_input.Text );
					
					Functions.SqlNonQuery("update coa set price = '"+newPrice.ToString()+"' " +
					                      "where name = '"+r.Cells["item"].Value.ToString()+"' ");
					
				}
				
				MessageBox.Show("Changes saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				refreshDGV();
			}
		}
		
		void Btn_changeDiscountPercentClick(object sender, EventArgs e)
		{
			if(dgv_prices.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select atleast one item.");
				return;
			}
			
			
			FrmAmountInput F = new FrmAmountInput();
			
			F.lbl_inputLabel.Text = "Enter new Discount";
			
			if(F.ShowDialog() == DialogResult.OK)
			{
				foreach( DataGridViewRow r in dgv_prices.SelectedRows )
				{
					DataTable tempDT = Functions.GetTable( "select * from " + Program.ModName_lcns + "_standard_prices where coa_name = '"+r.Cells["item"].Value.ToString()+"' " );
					
					if(tempDT.Rows.Count == 0)
					{
						Functions.SqlNonQuery( "insert into " + Program.ModName_lcns + "_standard_prices (coa_name, standard_price) values " +
						                      "('"+r.Cells["item"].Value.ToString()+"','"+r.Cells["Standard Price"].Value.ToString()+"')" );
						
						
					}
					
					
					
					
					Functions.SqlNonQuery("update coa set disc_rate = '"+ Functions.ParseDecimal( F.txb_input.Text ) +"' " +
					                      "where name = '"+r.Cells["item"].Value.ToString()+"' ");
					
				}
				
				MessageBox.Show("Changes saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				refreshDGV();
			}
		}
		
		void Dgv_pricesColumnAdded(object sender, DataGridViewColumnEventArgs e)
		{
			if(e.Column.ValueType == typeof(decimal))
			{
				e.Column.DefaultCellStyle.Format = "0,0.00;(0,0.00)";
				e.Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}
	}
}
