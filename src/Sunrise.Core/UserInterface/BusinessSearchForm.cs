/*

      file : BusinessSearchForm.cs
description: This is the business search UI form. It's purpose is to allow the user to search for
             an item. The search can be made in the same thread as the UI thread or in a thread
             from the thread pool.
                
             To search in the same thread as the UI you need to override Search method.
             To search in the thread from the thread pool you need to override the  
             StartThreadPool method.       
  
             
  
 
 NOTES - you need to call base on the overridable methods after the implementation.
  
  
  
    author : Marius Gheorghe




*/

using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	internal delegate void AfterSearchEventHandler(object dataSource);

	/// <summary>
	/// Business UI which allows the "Search for item" approach.
	/// </summary>
	public class BusinessSearchForm : BusinessForm
	{
		protected StatusBar statusBar;
		protected GroupBox groupBox;
		protected Button buttonSearch;
		protected TextBox textBoxSearch;
		protected Button buttonAdd;
		protected Button buttonDelete;
		protected Button buttonUpdate;
		protected Button buttonViewDetails;
		protected DataGridView dataGridView;
		private StatusBarPanel statusBarPanel;

		private Container components = null;

		/// <summary>
		/// flag used to know if we search from the thread pool.
		/// </summary>
		private bool useThreadPoolSearch;

		/// <summary>
		/// current user rights
		/// </summary>
		protected UserRights userRights = null;

		protected string entityName = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public BusinessSearchForm(UserRights userRights, string entityName)
		{
			InitializeComponent();

			this.userRights = userRights;
			this.entityName = entityName;
		}

		public BusinessSearchForm()
		{
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
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarPanel = new System.Windows.Forms.StatusBarPanel();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonViewDetails = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize) (this.statusBarPanel)).BeginInit();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.AutoSize = true;
			this.statusBar.Location = new System.Drawing.Point(0, 368);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {this.statusBarPanel});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(583, 16);
			this.statusBar.TabIndex = 1;
			// 
			// statusBarPanel
			// 
			this.statusBarPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.statusBarPanel.Name = "statusBarPanel";
			this.statusBarPanel.Width = 566;
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.buttonSearch);
			this.groupBox.Controls.Add(this.textBoxSearch);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(583, 56);
			this.groupBox.TabIndex = 2;
			this.groupBox.TabStop = false;
			// 
			// buttonSearch
			// 
			this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSearch.Location = new System.Drawing.Point(487, 24);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(88, 24);
			this.buttonSearch.TabIndex = 1;
			this.buttonSearch.Text = "&Search";
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSearch.Location = new System.Drawing.Point(8, 24);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(471, 20);
			this.textBoxSearch.TabIndex = 0;
			this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAdd.Location = new System.Drawing.Point(319, 337);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(80, 24);
			this.buttonAdd.TabIndex = 6;
			this.buttonAdd.Text = "&Insert";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonDelete.Location = new System.Drawing.Point(407, 337);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(80, 24);
			this.buttonDelete.TabIndex = 7;
			this.buttonDelete.Text = "&Delete";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonUpdate.Location = new System.Drawing.Point(495, 337);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(80, 24);
			this.buttonUpdate.TabIndex = 8;
			this.buttonUpdate.Text = "&Update";
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// buttonViewDetails
			// 
			this.buttonViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonViewDetails.Location = new System.Drawing.Point(8, 337);
			this.buttonViewDetails.Name = "buttonViewDetails";
			this.buttonViewDetails.Size = new System.Drawing.Size(86, 24);
			this.buttonViewDetails.TabIndex = 9;
			this.buttonViewDetails.Text = "&View";
			this.buttonViewDetails.Click += new System.EventHandler(this.buttonViewDetails_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToOrderColumns = true;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.Location = new System.Drawing.Point(8, 63);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(572, 266);
			this.dataGridView.TabIndex = 10;
			// 
			// BusinessSearchForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(583, 384);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.buttonViewDetails);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.statusBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "BusinessSearchForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BusinessSearchForm";
			this.Load += new System.EventHandler(this.BusinessSearchForm_Load);
			((System.ComponentModel.ISupportInitialize) (this.statusBarPanel)).EndInit();
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonSearch_Click(null, null);
			}
		}

		private void BusinessSearchForm_Load(object sender, EventArgs e)
		{
			SetUserRights();
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				OnUpdate(dataGridView.SelectedRows[0].Index);
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				OnDelete(dataGridView.SelectedRows[0].Index);
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			OnInsert();
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			StartSearch();
		}

		private void buttonViewDetails_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				OnViewDetails(dataGridView.SelectedRows[0].Index);
			}
		}

		/// <summary>
		/// Starts the searching.
		/// </summary>
		private void StartSearch()
		{
			//do NOT check for an empty string here. Instead allow the 
			//extender to make the check and search for all items.

			statusBar.Text = "Searching........";

			EnableControls(false);

			if (useThreadPoolSearch)
			{
				ThreadPool.QueueUserWorkItem(StartThreadPoolSearch, textBoxSearch.Text);
			}
			else
			{
				Search(textBoxSearch.Text.Trim());
			}
		}

		/// <summary>
		/// Sets the user rights for this entity
		/// </summary>
		protected void SetUserRights()
		{
			try
			{
				if (userRights == null)
				{
					return;
				}

				buttonAdd.Enabled = userRights.AllowAdd;
				buttonDelete.Enabled = userRights.AllowDelete;
				buttonUpdate.Enabled = userRights.AllowEdit;

				//override and parse the rest of the rights
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Get or set if the search operation occures in a thread from the thread pool
		/// </summary>
		public bool UseThreadPoolSearch
		{
			get
			{
				return useThreadPoolSearch;
			}
			set
			{
				useThreadPoolSearch = value;
			}
		}

		/// <summary>
		///  Enable or disable the controls. This is used to disable the controls when the search operation begins and re-enable them at the end.
		/// </summary>
		/// <param name="enabled">Flag used to know if we disable or enable the controls.</param>
		public virtual void EnableControls(bool enabled)
		{
			buttonAdd.Enabled = enabled;
			buttonDelete.Enabled = enabled;
			buttonSearch.Enabled = enabled;
			buttonUpdate.Enabled = enabled;
			buttonViewDetails.Enabled = enabled;
			dataGridView.Enabled = enabled;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="searchItem"></param>
		private void StartThreadPoolSearch(object searchItem)
		{
			object source = null;
			SearchOnThreadPool(searchItem.ToString(), ref source);
		}

		/// <summary>
		/// The search opration 
		/// </summary>
		/// <param name="searchItem"></param>
		/// <param name="dataSource"></param>
		public virtual void SearchOnThreadPool(string searchItem, ref object dataSource)

		{
			//override to search
			AfterSearchEventHandler after = OnAfterSearchOnThreadPool;

			Invoke(after, dataSource);
		}

		protected virtual void OnAfterSearchOnThreadPool(object dataSource)
		{
			dataGridView.DataSource = dataSource;
			EnableControls(true);

			statusBar.Panels[0].Text = dataGridView.Rows.Count + "  items found";
		}

		public virtual void Search(string searchItem)
		{
			EnableControls(true);
			statusBar.Panels[0].Text = dataGridView.Rows.Count + "  items found";
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void FormatDataGridStyles()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void OnUpdate(int index)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void OnDelete(int index)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void OnInsert()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void OnViewDetails(int index)
		{
		}

		/// <summary>
		/// Receives a message.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="args"></param>
		public override void ReceiveMessage(EntityMessage msg, params object[] args)
		{
		}
	}
}