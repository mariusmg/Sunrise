using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	public delegate void SearchCallback(int rowIndex, int columnIndex);

	/// <summary>
	/// SearchForm
	/// </summary>
	public class SearchForm : Form
	{
		private DataSet ds;
		private SearchCallback callback;
		private StringCollection scDataItems;
		private Button buttonClose;
		private Label labelSearch;
		private Button buttonSearch;
		private ComboBox comboBoxData;
		private TextBox textSearch;
		private Label label1;
		private CheckBox checkBoxMatchCase;
		private CheckBox checkBoxMatchWholeWord;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public SearchForm(DataSet ds, StringCollection scDataItems, SearchCallback callback)
		{
			InitializeComponent();

			this.ds = ds;
			this.callback = callback;
			this.scDataItems = scDataItems;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textSearch = new System.Windows.Forms.TextBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelSearch = new System.Windows.Forms.Label();
			this.comboBoxData = new System.Windows.Forms.ComboBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
			this.checkBoxMatchWholeWord = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// textSearch
			// 
			this.textSearch.Location = new System.Drawing.Point(80, 8);
			this.textSearch.Name = "textSearch";
			this.textSearch.Size = new System.Drawing.Size(240, 20);
			this.textSearch.TabIndex = 0;
			this.textSearch.Text = "";
			this.textSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyUp);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(336, 72);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(96, 24);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "&Close";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// labelSearch
			// 
			this.labelSearch.Location = new System.Drawing.Point(8, 32);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(168, 16);
			this.labelSearch.TabIndex = 2;
			this.labelSearch.Text = "Search in";
			this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxData
			// 
			this.comboBoxData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxData.Location = new System.Drawing.Point(184, 32);
			this.comboBoxData.Name = "comboBoxData";
			this.comboBoxData.Size = new System.Drawing.Size(136, 21);
			this.comboBoxData.TabIndex = 3;
			this.comboBoxData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxData_KeyUp);
			// 
			// buttonSearch
			// 
			this.buttonSearch.Location = new System.Drawing.Point(336, 8);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(96, 24);
			this.buttonSearch.TabIndex = 4;
			this.buttonSearch.Text = "&Search";
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Find";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxMatchCase
			// 
			this.checkBoxMatchCase.Location = new System.Drawing.Point(8, 56);
			this.checkBoxMatchCase.Name = "checkBoxMatchCase";
			this.checkBoxMatchCase.Size = new System.Drawing.Size(208, 16);
			this.checkBoxMatchCase.TabIndex = 6;
			this.checkBoxMatchCase.Text = "Match case";
			// 
			// checkBoxMatchWholeWord
			// 
			this.checkBoxMatchWholeWord.Location = new System.Drawing.Point(8, 80);
			this.checkBoxMatchWholeWord.Name = "checkBoxMatchWholeWord";
			this.checkBoxMatchWholeWord.Size = new System.Drawing.Size(216, 16);
			this.checkBoxMatchWholeWord.TabIndex = 7;
			this.checkBoxMatchWholeWord.Text = "Match whole word";
			// 
			// SearchForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 109);
			this.Controls.Add(this.checkBoxMatchWholeWord);
			this.Controls.Add(this.checkBoxMatchCase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSearch);
			this.Controls.Add(this.comboBoxData);
			this.Controls.Add(this.labelSearch);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.textSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Search";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.SearchForm_Closing);
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyUp);
			this.ResumeLayout(false);
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Visible = false;
		}

		private void SearchForm_Load(object sender, EventArgs e)
		{
			comboBoxData.DataSource = scDataItems;
			comboBoxData.SelectedIndex = 0;
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			try
			{
				if (textSearch.Text.Trim().Length > 0)
				{
					if (checkBoxMatchWholeWord.Checked)
					{
						SearchWithMatchWholeWord(textSearch.Text.Trim(), checkBoxMatchCase.Checked);
					}
					else
					{
						Search(textSearch.Text.Trim(), checkBoxMatchCase.Checked);
					}
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex);
			}
		}

		/// <summary>
		/// Searches for the specified item.
		/// </summary>
		/// <param name="searchItem">Search item.</param>
		private void Search(string searchItem, bool matchCase)
		{
			try
			{
				string selectedColumnName = comboBoxData.SelectedItem.ToString();
				int selectedColumnIndex = comboBoxData.SelectedIndex;

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					if (matchCase)
					{
						if (ds.Tables[0].Rows[i][selectedColumnName].ToString().StartsWith(searchItem))
						{
							callback(i, selectedColumnIndex);
							return;
						}
					}
					else
					{
						if (ds.Tables[0].Rows[i][selectedColumnName].ToString().ToLower().StartsWith(searchItem.ToLower()))
						{
							callback(i, selectedColumnIndex);
							return;
						}
					}
				}

				callback(-1, -1);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//		/// <summary>
		//		/// Searches the with match whole word.
		//		/// </summary>
		//		/// <param name="searchItem">Search item.</param>
		private void SearchWithMatchWholeWord(string searchItem, bool matchCase)
		{
			try
			{
				string selectedColumn = comboBoxData.SelectedItem.ToString();
				int selectedColumnIndex = comboBoxData.SelectedIndex;

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					if (matchCase)
					{
						if (ds.Tables[0].Rows[i][selectedColumn].ToString() == searchItem)
						{
							callback(i, selectedColumnIndex);
							return;
						}
					}
					else
					{
						if (ds.Tables[0].Rows[i][selectedColumn].ToString().ToLower() == searchItem.ToLower())
						{
							callback(i, selectedColumnIndex);
							return;
						}
					}
				}

				callback(-1, -1);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void textSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Visible = false;
			}
		}

		private void SearchForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Visible = false;
			}
		}

		private void comboBoxData_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Visible = false;
			}
		}

		private void SearchForm_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			Visible = true;
		}
	}
}