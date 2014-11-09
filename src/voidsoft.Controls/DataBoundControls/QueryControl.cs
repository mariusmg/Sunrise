/*

	   file: QueryControls.cs
	   
description: QueryControl implementation. This control is used
			 to "browse" a result set and choose an item.
			 To display the item's list the control is using a
			 DialogList. The control allows you to get the selected text
			 using the .SelectedText property and the selected
			 index using the .SelectedIndex property.


*/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// QueryControl
	/// </summary>
	public class QueryControl : UserControl
	{
		private string browseDialogTitle = string.Empty;

		protected Button buttonSearch;
		protected TextBox textSearch;

		//data sources
		private IList list;
		private IDictionary idict;
		private StringDictionary stringDict;

		public delegate void BeforeBrowseEventHandler();

		public event BeforeBrowseEventHandler BeforeBrowse;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private string selectedValue = string.Empty;
		private string selectedKey = string.Empty;
		protected Button buttonDelete;
		private int selectedIndex = -1;

		/// <summary>
		/// Default ctor. Used when the control is in design view. 
		/// </summary>
		public QueryControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Ctor which sets the data source to an IList.
		/// </summary>
		/// <param name="list"></param>
		public QueryControl(IList list)
		{
			this.list = list;
			InitializeComponent();
		}

		/// <summary>
		/// Ctor which sets the data source to an IDictionary.
		/// </summary>
		/// <param name="idict"></param>
		public QueryControl(IDictionary idict)
		{
			this.idict = idict;
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (QueryControl));
			this.buttonSearch = new System.Windows.Forms.Button();
			this.textSearch = new System.Windows.Forms.TextBox();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonSearch
			// 
			this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSearch.Image = ((System.Drawing.Image) (resources.GetObject("buttonSearch.Image")));
			this.buttonSearch.Location = new System.Drawing.Point(320, 0);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(24, 22);
			this.buttonSearch.TabIndex = 1;
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// textSearch
			// 
			this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.textSearch.Location = new System.Drawing.Point(0, 0);
			this.textSearch.Multiline = true;
			this.textSearch.Name = "textSearch";
			this.textSearch.ReadOnly = true;
			this.textSearch.Size = new System.Drawing.Size(296, 22);
			this.textSearch.TabIndex = 3;
			this.textSearch.Text = "";
			this.textSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyUp);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
			this.buttonDelete.ForeColor = System.Drawing.Color.Red;
			this.buttonDelete.Location = new System.Drawing.Point(296, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(24, 22);
			this.buttonDelete.TabIndex = 4;
			this.buttonDelete.Text = "X";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// QueryControl
			// 
			this.Controls.Add(this.buttonSearch);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.textSearch);
			this.Name = "QueryControl";
			this.Size = new System.Drawing.Size(344, 22);
			this.Resize += new System.EventHandler(this.QueryControl_Resize);
			this.ResumeLayout(false);
		}

		public void Clear()
		{
			textSearch.Clear();
			selectedIndex = -1;
			selectedValue = string.Empty;
		}

		/// <summary>
		/// Set the current value of the query control
		/// passing the IDictionary key.
		/// </summary>
		/// <param name="key"></param>
		public void SetData(string key)
		{
			if (list != null)
			{
				int index = list.IndexOf(key);

				if (index > -1)
				{
					textSearch.Text = key;
					selectedValue = key;
				}
				else
				{
					throw new ArgumentException("Invalid item");
				}
			}
			else if (idict != null)
			{
				ICollection icol = idict.Keys;

				IDictionaryEnumerator ienum = (IDictionaryEnumerator) icol.GetEnumerator();

				int index = -1;

				while (ienum.MoveNext())
				{
					++index;

					if (ienum.Key.ToString() == key)
					{
						textSearch.Text = ienum.Value.ToString();
						selectedIndex = index;
						selectedValue = ienum.Value.ToString();

						return;
					}
				}

				throw new ArgumentException("Invalid key");
			}
			else if (stringDict != null)
			{
				int index = -1;

				foreach (DictionaryEntry de in stringDict)
				{
					++index;

					if (de.Key.ToString() == key)
					{
						textSearch.Text = de.Value.ToString();
						selectedIndex = index;
						selectedValue = de.Value.ToString();

						return;
					}
				}

				throw new ArgumentException("Invalid key");
			}
		}

		/// <summary>
		/// Sets the data from the specified index.
		/// </summary>
		/// <param name="index">The index</param>
		public void SetData(int index)
		{
			try
			{
				if (list != null)
				{
					if (index > list.Count || index < 0)
					{
						throw new ArgumentException("Invalid index");
					}

					textSearch.Text = list[index].ToString();
					selectedValue = list[index].ToString();
					selectedIndex = index;
				}
				else if (idict != null)
				{
					ICollection icol = idict.Values;

					if (index > icol.Count || index < 0)
					{
						throw new ArgumentException("Invalid index");
					}

					IEnumerator ienum = icol.GetEnumerator();

					int val = 0;

					while (ienum.MoveNext())
					{
						if (val == index)
						{
							textSearch.Text = ienum.Current.ToString();
							selectedIndex = val;
							selectedValue = ienum.Current.ToString();
							break;
						}

						++val;
					}
				}
				else if (stringDict != null)
				{
					int currentIndex = -1;

					if (index > stringDict.Count || index < 0)
					{
						throw new ArgumentException("Invalid index");
					}

					foreach (DictionaryEntry de in stringDict)
					{
						++index;

						if (currentIndex == index)
						{
							textSearch.Text = de.Value.ToString();
							selectedIndex = currentIndex;
							selectedValue = de.Value.ToString();
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw; // ex;
			}
		}

		/// <summary>
		/// Gets the selected text.
		/// </summary>
		public string SelectedValue
		{
			get
			{
				return selectedValue;
			}
		}

		/// <summary>
		/// Get the selected index.
		/// </summary>
		public int SelectedIndex
		{
			get
			{
				return selectedIndex;
			}
		}

		/// <summary>
		/// Returns the ID of the selected item. The data source
		/// must be a IDictionary. If the data source is a IList then
		/// the value -1 is returned
		/// </summary>
		public string SelectedKey
		{
			get
			{
				///
				if (list != null)
				{
					throw new InvalidOperationException("Cannot return key when the data source is IList");
				}

				if (selectedIndex > -1)
				{
					if (idict != null)
					{
						ICollection icol = idict.Keys;

						IEnumerator ienum = icol.GetEnumerator();

						int idx = -1;

						while (ienum.MoveNext())
						{
							++idx;

							if (idx == selectedIndex)
							{
								return ienum.Current.ToString();
							}
						}

						throw new InvalidOperationException("Invalid index");
					}
					int index = -1;

					foreach (DictionaryEntry de in stringDict)
					{
						++index;

						if (index == selectedIndex)
						{
							return de.Key.ToString();
						}
					}

					throw new InvalidOperationException("Invalid index");
				}
				return string.Empty;
			}
		}

		/// <summary>
		/// Gets/sets the data source.
		/// </summary>
		public object DataSource
		{
			get
			{
				//IList || IDictionary

				if (list != null)
				{
					return list;
				}
				return idict;
			}

			set
			{
				if (value == null)
				{
					return;
				}

				if (value is IList)
				{
					list = (IList) value;
					idict = null;
				}
				else if (value is IDictionary)
				{
					idict = (IDictionary) value;
					list = null;
				}
				else if (value is StringDictionary)
				{
					stringDict = (StringDictionary) value;
				}
				else
				{
					throw new InvalidOperationException("Invalid data source");
				}

				selectedIndex = -1;
				selectedValue = string.Empty;
			}
		}

		public string BrowseDialogTitle
		{
			get
			{
				return browseDialogTitle;
			}

			set
			{
				browseDialogTitle = value;
			}
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			//this.BeforeBrowse();

			DialogList dlist = null;

			try
			{
				//raise the event
				if (BeforeBrowse != null)
				{
					BeforeBrowse();
				}

				if (list != null)
				{
					dlist = new DialogList(list);
				}
				else if (idict != null)
				{
					dlist = new DialogList(idict);
				}
				else if (stringDict != null)
				{
					dlist = new DialogList(stringDict);
				}

				dlist.Text = browseDialogTitle;
				dlist.ShowInTaskbar = false;

				if (dlist.ShowDialog() == DialogResult.OK)
				{
					//write the selected text and the index.
					textSearch.Text = dlist.SelectedText;
					selectedValue = dlist.SelectedText;
					selectedIndex = dlist.SelectedIndex;
				}
			}
			catch (Exception ex)
			{
			}
			finally
			{
				if (dlist != null)
				{
					dlist.Dispose();
				}
			}
		}

		private void QueryControl_Resize(object sender, EventArgs e)
		{
			if (Height > 22)
			{
				Height = 22;
			}
		}

		private void textSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				selectedValue = string.Empty;
				textSearch.Text = "";
				selectedIndex = -1;
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			selectedValue = string.Empty;
			textSearch.Text = "";
			selectedIndex = -1;
		}
	}
}