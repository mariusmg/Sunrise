/*


	   file: MultiSelection.cs
description: user control which allows the selection of multiple items.
			 Can be bind to a IList or IDictionary.
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
	/// MultiSelection user control.
	/// </summary>
	public class MultiSelection : UserControl
	{
		public delegate void BeforeBrowseEventHandler();

		public event BeforeBrowseEventHandler BeforeBrowse;

		//private bool allowDuplicateItems = false;

		private Button buttonAdd;
		private Button buttonRemove;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private ListBox listBox;

		//data sources
		private IList ilist;
		private IDictionary idict;

		//collection which holds the selected indexes
		private StringCollection scKeys;

		/// <summary>
		/// Default ctor. Used at design time.
		/// </summary>
		public MultiSelection()
		{
			InitializeComponent();
			scKeys = new StringCollection();
			//this.allowDuplicateItems = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ilist"></param>
		public MultiSelection(IList ilist)
		{
			InitializeComponent();
			this.ilist = ilist;
			scKeys = new StringCollection();
			//this.allowDuplicateItems = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idict"></param>
		public MultiSelection(IDictionary idict)
		{
			InitializeComponent();
			this.idict = idict;
			scKeys = new StringCollection();
			//this.allowDuplicateItems = false;
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
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
			this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((System.Byte) (0)), ((System.Byte) (192)), ((System.Byte) (0)));
			this.buttonAdd.Location = new System.Drawing.Point(168, 214);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "+";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
			this.buttonRemove.ForeColor = System.Drawing.Color.Red;
			this.buttonRemove.Location = new System.Drawing.Point(143, 214);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(24, 24);
			this.buttonRemove.TabIndex = 2;
			this.buttonRemove.Text = "X";
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox.Location = new System.Drawing.Point(0, 0);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(192, 212);
			this.listBox.TabIndex = 3;
			// 
			// MultiSelection
			// 
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.buttonAdd);
			this.Name = "MultiSelection";
			this.Size = new System.Drawing.Size(192, 240);
			this.ResumeLayout(false);
		}

		//		/// <summary>
		//		/// 
		//		/// </summary>
		//        public bool AllowDuplicateItems
		//		{
		//			get
		//			{		
		//				return this.allowDuplicateItems;
		//			}
		//
		//			set
		//			{
		//				this.allowDuplicateItems = true;
		//			}
		//		}

		/// <summary>
		///Gets or sets the data source.
		/// </summary>
		public object DataSource
		{
			get
			{
				if (ilist != null)
				{
					return ilist;
				}
				return idict;
			}

			set
			{
				if (value is IList)
				{
					ilist = (IList) value;
				}
				else if (value is IDictionary)
				{
					idict = (IDictionary) value;
				}

				listBox.Items.Clear();
				scKeys.Clear();
			}
		}

		/// <summary>
		/// Returns an string array with the added values.
		/// </summary>
		public string[] SelectedValues
		{
			get
			{
				string[] values = new string[listBox.Items.Count];

				for (int i = 0; i < listBox.Items.Count; i++)
				{
					values[i] = listBox.Items[i].ToString();
				}

				return values;
			}
		}

		/// <summary>
		///Returns the keys.Is available ONLY when the data source
		///is a IDictionary. Returns null if the data source is IList.
		/// </summary>
		public string[] SelectedKeys
		{
			get
			{
				if (ilist != null)
				{
					return null;
				}
				string[] keys = new string[scKeys.Count];

				scKeys.CopyTo(keys, 0);

				return keys;
			}
		}

		/// <summary>
		/// Add a new item to the list.
		/// </summary>
		/// <param name="index">The datasource index.</param>
		public void AddItem(int index)
		{
			try
			{
				if (ilist != null)
				{
					listBox.Items.Add(ilist[index]);
				}
				else
				{
					if (index > idict.Count || index < 0)
					{
						throw new ArgumentException("Invalid index");
					}

					IDictionaryEnumerator ienum = idict.GetEnumerator();

					int counter = - 1;

					while (ienum.MoveNext())
					{
						++counter;

						if (counter == index)
						{
							listBox.Items.Add(ienum.Value);
							scKeys.Add(ienum.Key.ToString());
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void AddItem(string item)
		{
			try
			{
				int index = -1;

				if (ilist != null)
				{
					index = ilist.IndexOf(item);
				}
				else
				{
					int idx = -1;

					IDictionaryEnumerator ienum = idict.GetEnumerator();

					while (ienum.MoveNext())
					{
						++idx;

						if (ienum.Value.ToString() == item)
						{
							index = idx;
							scKeys.Add(ienum.Key.ToString());

							break;
						}
					}
				}

				if (index == -1)
				{
					throw new ArgumentException();
				}

				listBox.Items.Add(item);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Removes a item form the list.
		/// </summary>
		/// <param name="index">The item's index from the list.</param>
		public void RemoveItem(int index)
		{
			try
			{
				listBox.Items.RemoveAt(index);
			}
			catch (Exception ex)
			{
				//most likely a IndexOutOfRangeException.
				throw ex;
			}
		}

		/// <summary>
		/// Removes a item form the list.
		/// </summary>
		/// <param name="item">The item's name</param>
		public void RemoveItem(string item)
		{
			int index = listBox.Items.IndexOf(item);

			if (index == -1)
			{
				throw new ArgumentException();
			}
			listBox.Items.Remove(item);
		}

		/// <summary>
		/// Clears the items.
		/// </summary>
		public void Clear()
		{
			listBox.Items.Clear();
			scKeys.Clear();
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (listBox.SelectedItems.Count > 0)
				{
					//check the data source and remove the key
					if (idict != null)
					{
						scKeys.RemoveAt(listBox.SelectedIndex);
					}

					//remove the item
					listBox.Items.RemoveAt(listBox.SelectedIndex);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			DialogList dgList = null;

			try
			{
				if (ilist != null)
				{
					dgList = new DialogList(ilist);
				}
				else
				{
					dgList = new DialogList(idict);
				}

				//raise the event
				if (BeforeBrowse != null)
				{
					BeforeBrowse();
				}

				if (dgList.ShowDialog() == DialogResult.OK)
				{
					//					if(this.allowDuplicateItems)
					//					{
					//						this.listBox.Items.Add(dgList.SelectedText);
					//						this.scIndex.Add(dgList.SelectedIndex.ToString());
					//					}
					//					else
					//					{
					if (listBox.Items.Contains(dgList.SelectedText))
					{
					}
					else
					{
						listBox.Items.Add(dgList.SelectedText);

						//add the selected key

						if (idict != null)
						{
							int selectedIndex = dgList.SelectedIndex;

							int currentIndex = -1;

							IDictionaryEnumerator ienum = idict.GetEnumerator();

							while (ienum.MoveNext())
							{
								++currentIndex;

								if (selectedIndex == currentIndex)
								{
									scKeys.Add(ienum.Key.ToString());
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (dgList != null)
				{
					dgList.Dispose();
				}
			}
		}
	}
}