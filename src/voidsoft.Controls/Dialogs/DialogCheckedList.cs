/*





*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Summary description for DialogCheckedList.
	/// </summary>
	public class DialogCheckedList : Form
	{
		private CheckedListBox checkedListBox;
		private Button buttonOK;
		private Button buttonCancel;
		private Label labelSearch;

		private IList list;
		private IDictionary idict;
		private DataTable dtable;

		private int idIndex = -1;
		private int descriptionIndex = -1;
		private TextBox textSearch;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private DialogCheckedList()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new istance of the DialogCheckedList using
		/// and IList as a data source.
		/// </summary>
		/// <param name="list">Data source</param>
		public DialogCheckedList(IList list)
		{
			InitializeComponent();
			this.list = list;
		}

		/// <summary>
		/// Initializes a new istance of the DialogCheckedList using
		/// and IDictionary as a data source.
		/// </summary>
		/// <param name="dictionary">Data source </param>
		public DialogCheckedList(IDictionary dictionary)
		{
			InitializeComponent();
			idict = dictionary;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dtable"></param>
		/// <param name="idIndex"></param>
		/// <param name="descriptionIndex"></param>
		public DialogCheckedList(DataTable dtable, int idIndex, int descriptionIndex)
		{
			InitializeComponent();

			if (idIndex > dtable.Columns.Count || idIndex < 0 || descriptionIndex > dtable.Columns.Count || descriptionIndex < 0)
			{
				throw new ArgumentException("Invalid index");
			}

			this.dtable = dtable;
			this.idIndex = idIndex;
			this.descriptionIndex = descriptionIndex;
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
			this.labelSearch = new System.Windows.Forms.Label();
			this.textSearch = new System.Windows.Forms.TextBox();
			this.checkedListBox = new System.Windows.Forms.CheckedListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelSearch
			// 
			this.labelSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelSearch.Location = new System.Drawing.Point(8, 8);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(80, 16);
			this.labelSearch.TabIndex = 0;
			this.labelSearch.Text = "Search :";
			this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textSearch
			// 
			this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.textSearch.Location = new System.Drawing.Point(96, 8);
			this.textSearch.Name = "textSearch";
			this.textSearch.Size = new System.Drawing.Size(224, 20);
			this.textSearch.TabIndex = 1;
			this.textSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Generic_KeyUp);
			this.textSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
			// 
			// checkedListBox
			// 
			this.checkedListBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox.FormattingEnabled = true;
			this.checkedListBox.Location = new System.Drawing.Point(8, 40);
			this.checkedListBox.Name = "checkedListBox";
			this.checkedListBox.Size = new System.Drawing.Size(312, 259);
			this.checkedListBox.TabIndex = 2;
			this.checkedListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Generic_KeyUp);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonOK.Location = new System.Drawing.Point(160, 320);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 32);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "&OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.buttonOK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Generic_KeyUp);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonCancel.Location = new System.Drawing.Point(248, 320);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 32);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonCancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Generic_KeyUp);
			// 
			// DialogCheckedList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 360);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.checkedListBox);
			this.Controls.Add(this.textSearch);
			this.Controls.Add(this.labelSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DialogCheckedList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.DialogCheckedList_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Generic_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		/// <summary>
		/// Returns the selected items;
		/// </summary>
		public string[] SelectedText
		{
			get
			{
				string[] values = new string[checkedListBox.CheckedItems.Count];

				for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
				{
					values[i] = checkedListBox.CheckedItems[i].ToString();
				}

				return values;
			}
		}

		/// <summary>
		/// Returns the selected keys.
		/// </summary>
		public string[] SelectedKeys
		{
			get
			{
				if (list != null)
				{
					//IList doesn;t have keys so return null.
					return null;
				}
				if (idict != null)
				{
					string[] values = new string[checkedListBox.CheckedItems.Count];

					string[] intermediateValues = new string[idict.Count];

					IDictionaryEnumerator ienum = idict.GetEnumerator();

					int currentIndex = -1;

					while (ienum.MoveNext())
					{
						++currentIndex;
						intermediateValues[currentIndex] = ienum.Key.ToString();
					}

					int current = -1;

					for (int i = 0; i < checkedListBox.Items.Count; i++)
					{
						if (checkedListBox.GetItemChecked(i))
						{
							++current;
							values[current] = intermediateValues[i];
						}
					}

					return values;
				}
				else
				{
					string[] values = new string[checkedListBox.SelectedIndices.Count];

					for (int i = 0; i < checkedListBox.SelectedIndices.Count; i++)
					{
						values[i] = dtable.Rows[idIndex][checkedListBox.SelectedIndices[i]].ToString();
					}

					return values;
				}
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
			//autosearch in list box
			try
			{
				if (textSearch.Text.Trim().Length > 0)
				{
					for (int i = 0; i < checkedListBox.Items.Count; i++)
					{
						if (checkedListBox.Items[i].ToString().StartsWith(textSearch.Text))
						{
							checkedListBox.SelectedIndex = i;
							break;
						}
					}
				}
			}
			catch
			{
				//swallow all exceptions
			}
		}

		private void DialogCheckedList_Load(object sender, EventArgs e)
		{
			try
			{
				//bind data
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						checkedListBox.Items.Add(list[i].ToString());
					}
				}
				else if (idict != null)
				{
					IDictionaryEnumerator ienum = idict.GetEnumerator();

					while (ienum.MoveNext())
					{
						checkedListBox.Items.Add(ienum.Value.ToString());
					}
				}
				else
				{
					for (int i = 0; i < dtable.Rows.Count; i++)
					{
						checkedListBox.Items.Add(dtable.Rows[i][descriptionIndex].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void Generic_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}