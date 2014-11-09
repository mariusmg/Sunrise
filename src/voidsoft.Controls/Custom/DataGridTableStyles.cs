/*

	   file: DataGridTableStyles.cs
description: allows to set table styles to a data grid.
	 author: Marius Gheorghe.


*/

using System;
using System.Data;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Allows data grid styles customizations.
	/// </summary>
	public class DataGridStyles
	{
		private DataGridStyles()
		{
		}

		/// <summary>
		/// Allows to set default table styles to a data grid using the 
		/// column indexes.
		/// </summary>
		/// <param name="dg">DataGris to which we set the style</param>
		/// <param name="dtable">DataSource</param>
		/// <param name="indexes">DataColumn indexes from the data source which will be included</param>
		public static void SetGridStyle(DataGrid dg, DataTable dtable, params int[] indexes)
		{
			try
			{
				DataGridTableStyle dgtStyle = new DataGridTableStyle();
				dgtStyle.MappingName = dtable.TableName;
				dgtStyle.AllowSorting = false;
				dgtStyle.ReadOnly = true;

				if (indexes.Length == 0)
				{
				}
				else
				{
					for (int i = 0; i < indexes.Length; i++)
					{
						DataGridTextBoxColumn textCol = new DataGridTextBoxColumn();
						textCol.MappingName = dtable.Columns[indexes[i]].ColumnName;
						textCol.HeaderText = dtable.Columns[indexes[i]].ColumnName;
						textCol.Width = 200;
						textCol.NullText = " ";
						dgtStyle.GridColumnStyles.Add(textCol);
					}

					dg.TableStyles.Clear();
					dg.TableStyles.Add(dgtStyle);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
		}
	}
}