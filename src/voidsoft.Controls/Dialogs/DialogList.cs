/*

	   file: DialogList.cs
description: dialog which allows the user to select 
			 a item from a list. 
     author: Marius Gheorghe.
			 

*/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// DialogList
	/// </summary>
	public class DialogList : Form
	{
		private IList list;
		private IDictionary idict;
		private StringDictionary stringDict;

		/// <summary>
		/// holds the selected string from the list
		/// </summary>
		protected string selectedString;

		protected int selectedIndex = -1;

		public Button buttonOK;
		public Label labelSearch;
		public TextBox textSearch;
		public ListBox listBox;
		private Button buttonCancel;
		private Container components = null;

		public DialogList(IList list)
		{
			this.list = list;
			InitializeComponent();
		}

		public DialogList(IDictionary idictionary)
		{
			idict = idictionary;
			InitializeComponent();
		}

		public DialogList(StringDictionary stringDict)
		{
			InitializeComponent();
			this.stringDict = stringDict;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (DialogList));
			this.listBox = new System.Windows.Forms.ListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelSearch = new System.Windows.Forms.Label();
			this.textSearch = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox.Location = new System.Drawing.Point(0, 32);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(328, 290);
			this.listBox.TabIndex = 0;
			this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonOK.Location = new System.Drawing.Point(176, 343);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 32);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// labelSearch
			// 
			this.labelSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelSearch.Location = new System.Drawing.Point(8, 8);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(72, 16);
			this.labelSearch.TabIndex = 2;
			this.labelSearch.Text = "Search";
			this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textSearch
			// 
			this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.textSearch.Location = new System.Drawing.Point(88, 8);
			this.textSearch.Name = "textSearch";
			this.textSearch.Size = new System.Drawing.Size(240, 20);
			this.textSearch.TabIndex = 3;
			this.textSearch.Text = "";
			this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
			this.textSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyUp);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonCancel.Location = new System.Drawing.Point(256, 343);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 32);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			// 
			// DialogList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(330, 383);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textSearch);
			this.Controls.Add(this.labelSearch);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.listBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DialogList";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.DialogList_Load);
			this.ResumeLayout(false);
		}

		public string SelectedText
		{
			get
			{
				return selectedString;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return selectedIndex;
			}
		}

		private void textSearch_TextChanged(object sender, EventArgs e)
		{
			//autosearch in list box
			try
			{
				if (textSearch.Text != "")
				{
					for (int i = 0; i < listBox.Items.Count; i++)
					{
						if (listBox.Items[i].ToString().ToLower().StartsWith(textSearch.Text.ToLower()))
						{
							listBox.SelectedIndex = i;
						}
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void DialogList_Load(object sender, EventArgs e)
		{
			try
			{
				if (list != null)
				{
					//bind to IList.
					listBox.DataSource = list;
				}
				else if (idict != null)
				{
					//bind to IDictionary.
					IDictionaryEnumerator ienum = idict.GetEnumerator();

					while (ienum.MoveNext())
					{
						listBox.Items.Add(ienum.Value.ToString());
					}
				}
				else
				{
					IEnumerator ienum = stringDict.GetEnumerator();

					foreach (DictionaryEntry de in stringDict)
					{
						listBox.Items.Add(de.Value.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void listBox_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (listBox.SelectedItems.Count > 0)
				{
					selectedString = listBox.SelectedItem.ToString();
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			try
			{
				//don't force the user to select something
				if (listBox.SelectedItems.Count > 0)
				{
					selectedString = listBox.SelectedItem.ToString();
					selectedIndex = listBox.SelectedIndex;
					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void textSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				if (listBox.SelectedItems.Count > 0)
				{
					selectedString = listBox.SelectedItem.ToString();
					//this.selectedIndex = this.listBox.SelectedIndex;
					DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void listBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedIndex = listBox.SelectedIndex;
		}
	}
}