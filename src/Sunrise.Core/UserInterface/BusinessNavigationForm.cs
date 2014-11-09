/*

	   file : BusinessForm.cs
description : Business UserInterface base class.  
	 author : Marius Gheorghe.
	 


	Virtual methods which need to be overriden:
	
		- InitializeBusinessObject();
			Initialize here the business objects (the mapping object && the persistent object)
			
		- LoadData();
			Loads the data from database.

		

		 In Form_Load is called:
			
	



*/

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

//using voidsoft.ObjectWire.Controls;
//using voidsoft.DataBlock;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Base class for common business UI
	/// </summary>
	public class BusinessNavigationForm : BusinessForm // voidsoft.ObjectWire.Shared
	{
		protected ToolBar toolBar;
		protected TabControl tabControl;
		protected TabPage tabDetails;
		private MainMenu mainMenu;
		private MenuItem menuRoot;
		private MenuItem menuFirst;
		private MenuItem menuBack;
		private MenuItem menuNext;
		private MenuItem menuLast;
		private MenuItem menuInsert;
		private MenuItem menuDelete;
		private MenuItem menuUpdate;
		private MenuItem menuPrint;
		private IContainer components;

		private SearchCallback searchCallback;
		protected SearchForm searchForm = null;

		/// <summary>
		/// Holds the number of loaded items.
		/// </summary>
		protected int recordCount;

		/// <summary>
		/// Struct which holds the logged user rights for this module.
		/// </summary>
		protected UserRights userRights;

		/// <summary>
		/// 
		/// The current record index within the DataTable.
		/// </summary>
		protected int currentIndex = 0;

		/// <summary>
		/// User action status.
		/// </summary>
		protected ActionStatus actionStatus = ActionStatus.Navigate;

		/// <summary>
		/// DataSet whihc holds the data for the current business object
		/// </summary>
		protected DataSet dsData = null;

		protected ErrorProvider errorProvider;
		private MenuItem menuItemOk;
		private MenuItem menuItemCancel;
		private ToolBarButton tbMoveFirst;
		private ToolBarButton tbMoveBack;
		private ToolBarButton tbMoveNext;
		private ToolBarButton tbMoveLast;
		private ToolBarButton toolBarButton5;
		private ToolBarButton tbInsert;
		private ToolBarButton tbDelete;
		private ToolBarButton tbUpdate;
		private ToolBarButton toolBarButton9;
		private ToolBarButton tbOK;
		private ToolBarButton tbCancel;
		private TabPage tabList;
		protected Button buttonPreview;
		private ToolBarButton tbPrint;
		protected Button buttonSearch;
		private ImageList imageList;
		private DataGridView dataGrid;

		/// <summary>
		/// Name of the current entity
		/// </summary>
		protected string entityName;

		/// <summary>
		/// 
		/// </summary>
		public BusinessNavigationForm()
		{
			InitializeComponent();
			//this.searchCallback = new SearchCallback(OnSearchCallback);

			userRights = new UserRights(true, true, true, true, string.Empty);
			LocalizeUserInterface();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		/// <param name="entityName"></param>
		public BusinessNavigationForm(UserRights user, string entityName)
		{
			userRights = user;
			InitializeComponent();
			this.entityName = entityName;
			searchCallback = OnSearchCallback;

			LocalizeUserInterface();
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (BusinessNavigationForm));
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tbMoveFirst = new System.Windows.Forms.ToolBarButton();
			this.tbMoveBack = new System.Windows.Forms.ToolBarButton();
			this.tbMoveNext = new System.Windows.Forms.ToolBarButton();
			this.tbMoveLast = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.tbInsert = new System.Windows.Forms.ToolBarButton();
			this.tbDelete = new System.Windows.Forms.ToolBarButton();
			this.tbUpdate = new System.Windows.Forms.ToolBarButton();
			this.tbPrint = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
			this.tbOK = new System.Windows.Forms.ToolBarButton();
			this.tbCancel = new System.Windows.Forms.ToolBarButton();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabDetails = new System.Windows.Forms.TabPage();
			this.tabList = new System.Windows.Forms.TabPage();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.buttonPreview = new System.Windows.Forms.Button();
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuRoot = new System.Windows.Forms.MenuItem();
			this.menuFirst = new System.Windows.Forms.MenuItem();
			this.menuBack = new System.Windows.Forms.MenuItem();
			this.menuNext = new System.Windows.Forms.MenuItem();
			this.menuLast = new System.Windows.Forms.MenuItem();
			this.menuInsert = new System.Windows.Forms.MenuItem();
			this.menuDelete = new System.Windows.Forms.MenuItem();
			this.menuUpdate = new System.Windows.Forms.MenuItem();
			this.menuPrint = new System.Windows.Forms.MenuItem();
			this.menuItemOk = new System.Windows.Forms.MenuItem();
			this.menuItemCancel = new System.Windows.Forms.MenuItem();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.tabControl.SuspendLayout();
			this.tabList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.dataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.AutoSize = false;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {this.tbMoveFirst, this.tbMoveBack, this.tbMoveNext, this.tbMoveLast, this.toolBarButton5, this.tbInsert, this.tbDelete, this.tbUpdate, this.tbPrint, this.toolBarButton9, this.tbOK, this.tbCancel});
			this.toolBar.ButtonSize = new System.Drawing.Size(32, 32);
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList;
			this.toolBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(626, 56);
			this.toolBar.TabIndex = 0;
			this.toolBar.Wrappable = false;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// tbMoveFirst
			// 
			this.tbMoveFirst.ImageIndex = 0;
			this.tbMoveFirst.Name = "tbMoveFirst";
			this.tbMoveFirst.Text = "First ";
			// 
			// tbMoveBack
			// 
			this.tbMoveBack.ImageIndex = 1;
			this.tbMoveBack.Name = "tbMoveBack";
			this.tbMoveBack.Text = "Back ";
			// 
			// tbMoveNext
			// 
			this.tbMoveNext.ImageIndex = 3;
			this.tbMoveNext.Name = "tbMoveNext";
			this.tbMoveNext.Text = "Next ";
			// 
			// tbMoveLast
			// 
			this.tbMoveLast.ImageIndex = 2;
			this.tbMoveLast.Name = "tbMoveLast";
			this.tbMoveLast.Text = "Last ";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.Name = "toolBarButton5";
			this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbInsert
			// 
			this.tbInsert.ImageIndex = 6;
			this.tbInsert.Name = "tbInsert";
			this.tbInsert.Text = "Insert ";
			// 
			// tbDelete
			// 
			this.tbDelete.ImageIndex = 9;
			this.tbDelete.Name = "tbDelete";
			this.tbDelete.Text = "Delete ";
			// 
			// tbUpdate
			// 
			this.tbUpdate.ImageIndex = 4;
			this.tbUpdate.Name = "tbUpdate";
			this.tbUpdate.Text = "Update ";
			// 
			// tbPrint
			// 
			this.tbPrint.ImageIndex = 5;
			this.tbPrint.Name = "tbPrint";
			this.tbPrint.Text = "Print";
			// 
			// toolBarButton9
			// 
			this.toolBarButton9.Name = "toolBarButton9";
			this.toolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbOK
			// 
			this.tbOK.ImageIndex = 8;
			this.tbOK.Name = "tbOK";
			this.tbOK.Text = "OK  ";
			// 
			// tbCancel
			// 
			this.tbCancel.ImageIndex = 7;
			this.tbCancel.Name = "tbCancel";
			this.tbCancel.Text = "Cancel  ";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
			this.imageList.Images.SetKeyName(0, "");
			this.imageList.Images.SetKeyName(1, "");
			this.imageList.Images.SetKeyName(2, "");
			this.imageList.Images.SetKeyName(3, "");
			this.imageList.Images.SetKeyName(4, "");
			this.imageList.Images.SetKeyName(5, "");
			this.imageList.Images.SetKeyName(6, "");
			this.imageList.Images.SetKeyName(7, "");
			this.imageList.Images.SetKeyName(8, "");
			this.imageList.Images.SetKeyName(9, "");
			this.imageList.Images.SetKeyName(10, "");
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabDetails);
			this.tabControl.Controls.Add(this.tabList);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.HotTrack = true;
			this.errorProvider.SetIconAlignment(this.tabControl, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tabControl.ItemSize = new System.Drawing.Size(53, 18);
			this.tabControl.Location = new System.Drawing.Point(0, 56);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new System.Drawing.Size(626, 312);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// tabDetails
			// 
			this.tabDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.errorProvider.SetIconAlignment(this.tabDetails, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.tabDetails.ImageIndex = 0;
			this.tabDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tabDetails.Location = new System.Drawing.Point(4, 22);
			this.tabDetails.Name = "tabDetails";
			this.tabDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabDetails.Size = new System.Drawing.Size(618, 286);
			this.tabDetails.TabIndex = 0;
			this.tabDetails.Text = "Details   ";
			this.tabDetails.Visible = false;
			// 
			// tabList
			// 
			this.tabList.Controls.Add(this.dataGrid);
			this.tabList.Controls.Add(this.buttonSearch);
			this.tabList.Controls.Add(this.buttonPreview);
			this.tabList.Location = new System.Drawing.Point(4, 22);
			this.tabList.Name = "tabList";
			this.tabList.Size = new System.Drawing.Size(618, 286);
			this.tabList.TabIndex = 1;
			this.tabList.Text = "List  ";
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.AllowUserToOrderColumns = true;
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataGrid.Location = new System.Drawing.Point(0, 59);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.Size = new System.Drawing.Size(618, 227);
			this.dataGrid.TabIndex = 8;
			this.dataGrid.Text = "dataGridView1";
			// 
			// buttonSearch
			// 
			this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.errorProvider.SetIconAlignment(this.buttonSearch, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.buttonSearch.Image = ((System.Drawing.Image) (resources.GetObject("buttonSearch.Image")));
			this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonSearch.Location = new System.Drawing.Point(16, 12);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.buttonSearch.Size = new System.Drawing.Size(128, 40);
			this.buttonSearch.TabIndex = 7;
			this.buttonSearch.Text = "&Search";
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// buttonPreview
			// 
			this.buttonPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.errorProvider.SetIconAlignment(this.buttonPreview, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.buttonPreview.Image = ((System.Drawing.Image) (resources.GetObject("buttonPreview.Image")));
			this.buttonPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonPreview.Location = new System.Drawing.Point(472, 12);
			this.buttonPreview.Name = "buttonPreview";
			this.buttonPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.buttonPreview.Size = new System.Drawing.Size(136, 40);
			this.buttonPreview.TabIndex = 5;
			this.buttonPreview.Text = "&Preview";
			this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuRoot});
			this.mainMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// menuRoot
			// 
			this.menuRoot.Enabled = false;
			this.menuRoot.Index = 0;
			this.menuRoot.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuFirst, this.menuBack, this.menuNext, this.menuLast, this.menuInsert, this.menuDelete, this.menuUpdate, this.menuPrint, this.menuItemOk, this.menuItemCancel});
			this.menuRoot.ShowShortcut = false;
			this.menuRoot.Text = "";
			this.menuRoot.Visible = false;
			// 
			// menuFirst
			// 
			this.menuFirst.Index = 0;
			this.menuFirst.ShowShortcut = false;
			this.menuFirst.Text = "&First";
			this.menuFirst.Visible = false;
			this.menuFirst.Click += new System.EventHandler(this.menuFirst_Click);
			// 
			// menuBack
			// 
			this.menuBack.Enabled = false;
			this.menuBack.Index = 1;
			this.menuBack.ShowShortcut = false;
			this.menuBack.Text = "";
			this.menuBack.Visible = false;
			this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
			// 
			// menuNext
			// 
			this.menuNext.Enabled = false;
			this.menuNext.Index = 2;
			this.menuNext.ShowShortcut = false;
			this.menuNext.Text = "";
			this.menuNext.Visible = false;
			this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
			// 
			// menuLast
			// 
			this.menuLast.Enabled = false;
			this.menuLast.Index = 3;
			this.menuLast.ShowShortcut = false;
			this.menuLast.Text = "";
			this.menuLast.Visible = false;
			this.menuLast.Click += new System.EventHandler(this.menuLast_Click);
			// 
			// menuInsert
			// 
			this.menuInsert.Enabled = false;
			this.menuInsert.Index = 4;
			this.menuInsert.ShowShortcut = false;
			this.menuInsert.Text = "";
			this.menuInsert.Visible = false;
			this.menuInsert.Click += new System.EventHandler(this.menuInsert_Click);
			// 
			// menuDelete
			// 
			this.menuDelete.Enabled = false;
			this.menuDelete.Index = 5;
			this.menuDelete.ShowShortcut = false;
			this.menuDelete.Text = "";
			this.menuDelete.Visible = false;
			this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
			// 
			// menuUpdate
			// 
			this.menuUpdate.Enabled = false;
			this.menuUpdate.Index = 6;
			this.menuUpdate.ShowShortcut = false;
			this.menuUpdate.Text = "";
			this.menuUpdate.Visible = false;
			this.menuUpdate.Click += new System.EventHandler(this.menuUpdate_Click);
			// 
			// menuPrint
			// 
			this.menuPrint.Enabled = false;
			this.menuPrint.Index = 7;
			this.menuPrint.ShowShortcut = false;
			this.menuPrint.Text = "";
			this.menuPrint.Visible = false;
			this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
			// 
			// menuItemOk
			// 
			this.menuItemOk.Enabled = false;
			this.menuItemOk.Index = 8;
			this.menuItemOk.ShowShortcut = false;
			this.menuItemOk.Text = "";
			this.menuItemOk.Visible = false;
			this.menuItemOk.Click += new System.EventHandler(this.menuItemOk_Click);
			// 
			// menuItemCancel
			// 
			this.menuItemCancel.Enabled = false;
			this.menuItemCancel.Index = 9;
			this.menuItemCancel.ShowShortcut = false;
			this.menuItemCancel.Text = "";
			this.menuItemCancel.Visible = false;
			this.menuItemCancel.Click += new System.EventHandler(this.menuItemCancel_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			this.errorProvider.Icon = ((System.Drawing.Icon) (resources.GetObject("errorProvider.Icon")));
			// 
			// BusinessNavigationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(626, 368);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.toolBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu;
			this.MinimizeBox = false;
			this.Name = "BusinessNavigationForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.BusinessForm_Load);
			this.tabControl.ResumeLayout(false);
			this.tabList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.dataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}

		/// <summary>
		/// Initialize the business object (persistentObject) 
		/// </summary>
		public virtual void InitializeBusinessObject()
		{
			//initialize and load the data
		}

		public virtual StringCollection GetSearchItems()
		{
			return new StringCollection();
		}

		/// <summary>
		/// Load data from database and sets up the binding
		/// </summary>
		public virtual void LoadData()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool InsertData()
		{
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool UpdateData()
		{
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void DeleteData()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual bool ValidateData()
		{
			///this should be overriden in the 
			return false;
		}

		/// <summary>
		/// Prints 
		/// </summary>
		private void PrintData()
		{
			Thread thPrint = new Thread(OnPrintData);
			thPrint.Priority = ThreadPriority.Highest;
			thPrint.Name = "reporting thread";
			thPrint.Start();
		}

		public virtual void OnPrintData()
		{
			//init report and set data source here.
		}

		/// <summary>
		/// 
		/// </summary>
		private void PrintSingleRow()
		{
			Thread thPrint = new Thread(OnPrintSingleRow);
			thPrint.Priority = ThreadPriority.Highest;
			thPrint.Name = "reporting thread";
			thPrint.Start();
		}

		public virtual void OnPrintSingleRow()
		{
			//init report and set data source here.
		}

		/// <summary>
		/// Bind the grid's datasource and
		/// set it's styles.
		/// </summary>
		public virtual void BindDataToGrid()
		{
			//bind it to a dataview
			DataView dw = new DataView(dsData.Tables[0]);
			dw.AllowDelete = false;
			dw.AllowEdit = false;
			dw.AllowNew = false;
			//dw.RowStateFilter = DataRowState.Modified | DataRowState.Added | DataRowState.Unchanged;
			dataGrid.DataSource = dw;
		}

		/// <summary>
		/// Set the user rights.
		/// </summary>
		protected virtual void SetUserRights()
		{
			try
			{
				if (userRights == null)
				{
					return;
				}

				if (userRights.AllowAdd)
				{
					menuInsert.Enabled = true;
					toolBar.Buttons[5].Enabled = true;
				}
				else
				{
					menuInsert.Enabled = false;
					toolBar.Buttons[5].Enabled = false;
				}

				if (userRights.AllowEdit)
				{
					menuUpdate.Enabled = true;
					toolBar.Buttons[7].Enabled = true;
				}
				else
				{
					menuUpdate.Enabled = false;
					toolBar.Buttons[7].Enabled = false;
				}

				if (userRights.AllowDelete)
				{
					menuDelete.Enabled = true;
					toolBar.Buttons[6].Enabled = true;
				}
				else
				{
					menuDelete.Enabled = false;
					toolBar.Buttons[6].Enabled = false;
				}

				//process custom user rights.

				//print
				toolBar.Buttons[8].Enabled = true;

				//disable ok and cancel
				toolBar.Buttons[10].Enabled = false;
				toolBar.Buttons[11].Enabled = false;
				menuItemCancel.Enabled = false;
				menuItemOk.Enabled = false;
			}
			catch (Exception ex)
			{
				Log.LogError(ex.Message);
			}
		}

		/// <summary>
		/// Clear data from controls
		/// </summary>
		public virtual void ClearControls()
		{
			foreach (Control ctl in tabDetails.Controls)
			{
				if (ctl is TextBox)
				{
					ctl.Text = "";
				}
			}
		}

		/// <summary>
		/// Lock/unlock the controls to prevent editing.
		/// </summary>
		/// <param name="locked"></param>
		public virtual void LockControls(bool locked)
		{
			dataGrid.Enabled = locked;
			buttonPreview.Enabled = locked;
			buttonSearch.Enabled = locked;
		}

		/// <summary>
		/// Enters in "Add" mode
		/// </summary>
		public virtual void EnterAddMode()
		{
			actionStatus = ActionStatus.Add;
			LockControls(false);
			ClearControls();

			menuFirst.Enabled = false;
			menuBack.Enabled = false;
			menuNext.Enabled = false;
			menuLast.Enabled = false;

			menuInsert.Enabled = false;
			menuUpdate.Enabled = false;
			menuPrint.Enabled = false;

			menuItemCancel.Enabled = true;
			menuItemOk.Enabled = true;

			toolBar.Buttons[0].Enabled = false;
			toolBar.Buttons[1].Enabled = false;
			toolBar.Buttons[2].Enabled = false;
			toolBar.Buttons[3].Enabled = false;
			toolBar.Buttons[5].Enabled = false;
			toolBar.Buttons[6].Enabled = false;
			toolBar.Buttons[7].Enabled = false;
			toolBar.Buttons[8].Enabled = false;
			toolBar.Buttons[10].Enabled = true;
			toolBar.Buttons[11].Enabled = true;
		}

		/// <summary>
		/// Enters the "Edit" mode
		/// </summary>
		public virtual void EnterEditMode()
		{
			actionStatus = ActionStatus.Edit;
			LockControls(false);

			menuFirst.Enabled = false;
			menuBack.Enabled = false;
			menuNext.Enabled = false;
			menuLast.Enabled = false;

			menuInsert.Enabled = false;
			menuUpdate.Enabled = false;
			menuPrint.Enabled = false;

			menuItemCancel.Enabled = true;
			menuItemOk.Enabled = true;

			toolBar.Buttons[0].Enabled = false;
			toolBar.Buttons[1].Enabled = false;
			toolBar.Buttons[2].Enabled = false;
			toolBar.Buttons[3].Enabled = false;
			toolBar.Buttons[5].Enabled = false;
			toolBar.Buttons[6].Enabled = false;
			toolBar.Buttons[7].Enabled = false;
			toolBar.Buttons[8].Enabled = false;
			toolBar.Buttons[10].Enabled = true;
			toolBar.Buttons[11].Enabled = true;
		}

		/// <summary>
		/// Deletes the  
		/// </summary>
		public virtual void EnterDeleteMode()
		{
		}

		/// <summary>
		/// Gets the data from business layer and displays it into controls.
		/// </summary>
		public virtual void DisplayData()
		{
			ClearControls();
		}

		/// <summary>
		/// Moves to the first record.
		/// </summary>
		public virtual void MoveFirst()
		{
			if (recordCount == 0)
			{
				toolBar.Buttons[0].Enabled = false;
				toolBar.Buttons[1].Enabled = false;
				toolBar.Buttons[2].Enabled = false;
				toolBar.Buttons[3].Enabled = false;
				menuBack.Enabled = false;
				menuFirst.Enabled = false;
				menuNext.Enabled = false;
				menuLast.Enabled = false;

				toolBar.Buttons[6].Enabled = false;
				toolBar.Buttons[7].Enabled = false;
				toolBar.Buttons[8].Enabled = false;

				menuUpdate.Enabled = false;
				menuDelete.Enabled = false;
			}
			if (recordCount == 1)
			{
				toolBar.Buttons[0].Enabled = false;
				toolBar.Buttons[1].Enabled = false;
				toolBar.Buttons[2].Enabled = false;
				toolBar.Buttons[3].Enabled = false;
				menuBack.Enabled = false;
				menuFirst.Enabled = false;
				menuNext.Enabled = false;
				menuLast.Enabled = false;

				currentIndex = 0;
				DisplayData();
			}
			else
			{
				currentIndex = 0;
				DisplayData();

				toolBar.Buttons[0].Enabled = false;
				toolBar.Buttons[1].Enabled = false;
				toolBar.Buttons[2].Enabled = true;
				toolBar.Buttons[3].Enabled = true;
			}
		}

		/// <summary>
		/// Moves back
		/// </summary>
		public virtual void MoveBack()
		{
			if (currentIndex - 1 == 0)
			{
				MoveFirst();
				return;
			}

			--currentIndex;

			DisplayData();

			if (currentIndex == 0)
			{
				toolBar.Buttons[0].Enabled = false;
				toolBar.Buttons[1].Enabled = false;
				toolBar.Buttons[2].Enabled = true;
				toolBar.Buttons[3].Enabled = true;
			}
			else
			{
				toolBar.Buttons[0].Enabled = true;

				toolBar.Buttons[2].Enabled = true;
				toolBar.Buttons[3].Enabled = true;
			}
		}

		/// <summary>
		/// Moves to the next record.
		/// </summary>
		public virtual void MoveNext()
		{
			++currentIndex;

			if (currentIndex + 1 == recordCount)
			{
				MoveLast();
				return;
			}

			DisplayData();

			if (currentIndex == recordCount)
			{
				toolBar.Buttons[0].Enabled = true;
				toolBar.Buttons[1].Enabled = true;
				toolBar.Buttons[2].Enabled = false;
				toolBar.Buttons[3].Enabled = false;
			}
			else
			{
				toolBar.Buttons[0].Enabled = true;
				toolBar.Buttons[1].Enabled = true;

				toolBar.Buttons[3].Enabled = true;
			}
		}

		/// <summary>
		/// Moves to the last record
		/// </summary>
		public virtual void MoveLast()
		{
			currentIndex = (recordCount - 1);
			DisplayData();

			toolBar.Buttons[0].Enabled = true;
			toolBar.Buttons[1].Enabled = true;
			toolBar.Buttons[2].Enabled = false;
			toolBar.Buttons[3].Enabled = false;
		}

		/// <summary>
		/// Moves to the specified record by index.
		/// </summary>
		/// <param name="index"></param>
		public virtual void MoveToIndex(int index)
		{
			if (recordCount == 0)
			{
				toolBar.Buttons[0].Enabled = false;
				toolBar.Buttons[1].Enabled = false;
				toolBar.Buttons[2].Enabled = false;
				toolBar.Buttons[3].Enabled = false;
				menuBack.Enabled = false;
				menuFirst.Enabled = false;
				menuNext.Enabled = false;
				menuLast.Enabled = false;

				toolBar.Buttons[6].Enabled = false;
				toolBar.Buttons[7].Enabled = false;
				toolBar.Buttons[8].Enabled = false;

				menuUpdate.Enabled = false;
				menuDelete.Enabled = false;
			}
			if (recordCount == 1)
			{
				toolBar.Buttons[0].Enabled = false;
				toolBar.Buttons[1].Enabled = false;
				toolBar.Buttons[2].Enabled = false;
				toolBar.Buttons[3].Enabled = false;
				menuBack.Enabled = false;
				menuFirst.Enabled = false;
				menuNext.Enabled = false;
				menuLast.Enabled = false;

				currentIndex = 0;
				DisplayData();
			}
			else if ((index + 1) == recordCount)
			{
				//
				currentIndex = (recordCount - 1);
				DisplayData();

				toolBar.Buttons[0].Enabled = true;
				toolBar.Buttons[1].Enabled = true;
				toolBar.Buttons[2].Enabled = false;
				toolBar.Buttons[3].Enabled = false;
			}
			else
			{
				currentIndex = index;
				DisplayData();

				//check if it's the first
				if (index == 0)
				{
					toolBar.Buttons[0].Enabled = false;
					toolBar.Buttons[1].Enabled = false;
					toolBar.Buttons[2].Enabled = true;
					toolBar.Buttons[3].Enabled = true;
				}
				else if (index == recordCount)
				{
					toolBar.Buttons[0].Enabled = true;
					toolBar.Buttons[1].Enabled = true;
					toolBar.Buttons[2].Enabled = false;
					toolBar.Buttons[3].Enabled = false;
				}
				else
				{
					toolBar.Buttons[0].Enabled = true;
					toolBar.Buttons[1].Enabled = true;
					toolBar.Buttons[2].Enabled = true;
					toolBar.Buttons[3].Enabled = true;
				}
			}
		}

		public override void ReceiveMessage(EntityMessage msg, params object[] args)
		{
			switch (msg)
			{
				case EntityMessage.BringToFront:
					BringToFront();
					break;
				case EntityMessage.Close:
					Close();
					break;
				case EntityMessage.CustomMessage:
					break;
			}
		}

		public virtual void LocalizeUserInterface()
		{
			try
			{
				//translate only if it's not the default (english)
				if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() != "en")
				{
					toolBar.Buttons[0].Text = Localization.GetCultureInfoResource("First", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[1].Text = Localization.GetCultureInfoResource("Back", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[2].Text = Localization.GetCultureInfoResource("Next", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[3].Text = Localization.GetCultureInfoResource("Last", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();

					toolBar.Buttons[5].Text = Localization.GetCultureInfoResource("Insert", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[6].Text = Localization.GetCultureInfoResource("Delete", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[7].Text = Localization.GetCultureInfoResource("Update", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[8].Text = Localization.GetCultureInfoResource("Print", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();

					toolBar.Buttons[10].Text = Localization.GetCultureInfoResource("Ok", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					toolBar.Buttons[11].Text = Localization.GetCultureInfoResource("Cancel", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();

					tabDetails.Text = Localization.GetCultureInfoResource("Details", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					tabList.Text = Localization.GetCultureInfoResource("List", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					buttonSearch.Text = Localization.GetCultureInfoResource("Search", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
					buttonPreview.Text = Localization.GetCultureInfoResource("Preview", "ObjectWire.Shared.Resources.UI", Assembly.GetExecutingAssembly()).ToString();
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex);
				throw ex;
			}
		}

		private void menuFirst_Click(object sender, EventArgs e)
		{
			MoveFirst();
		}

		private void menuBack_Click(object sender, EventArgs e)
		{
			MoveBack();
		}

		private void menuNext_Click(object sender, EventArgs e)
		{
			MoveNext();
		}

		private void menuLast_Click(object sender, EventArgs e)
		{
			MoveLast();
		}

		private void menuInsert_Click(object sender, EventArgs e)
		{
			EnterAddMode();
		}

		private void menuDelete_Click(object sender, EventArgs e)
		{
			EnterDeleteMode();
		}

		private void menuUpdate_Click(object sender, EventArgs e)
		{
			EnterEditMode();
		}

		private void menuPrint_Click(object sender, EventArgs e)
		{
			PrintSingleRow();
		}

		private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			switch (toolBar.Buttons.IndexOf(e.Button))
			{
				case 0:
					MoveFirst();
					break;

				case 1:
					MoveBack();
					break;

				case 2:
					MoveNext();
					break;

				case 3:
					MoveLast();
					break;

				case 5:
					EnterAddMode();
					break;

				case 6:
					EnterDeleteMode();
					break;

				case 7:
					EnterEditMode();
					break;

				case 8:
					PrintSingleRow();
					break;

				case 10: //ok
					OnCommit();
					break;

				case 11: //cancel
					OnCancel();
					break;
			}
		}

		private void dataGrid_DoubleClick(object sender, EventArgs e)
		{
			MoveToIndex(dataGrid.SelectedRows[0].Index); // CurrentCell.RowNumber);
			tabControl.SelectedTab = tabControl.TabPages[0];
		}

		private void buttonPreview_Click(object sender, EventArgs e)
		{
			PrintData();
		}

		private void BusinessForm_Load(object sender, EventArgs e)
		{
			SetUserRights();

			LockControls(true);

			InitializeBusinessObject();

			LoadData();
		}

		private void menuItemCancel_Click(object sender, EventArgs e)
		{
			OnCancel();
		}

		private void menuItemOk_Click(object sender, EventArgs e)
		{
			OnCommit();
		}

		/// <summary>
		/// Search callback
		/// </summary>
		/// <param name="rowIndex"></param>
		/// <param name="columnIndex"></param>
		private void OnSearchCallback(int rowIndex, int columnIndex)
		{
			if (rowIndex == -1)
			{
				MessageBox.Show("No results found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				Focus();
				//this.dataGrid.CurrentRowIndex = rowIndex;
				//this.dataGrid.CurrentCell = new DataGridViewCell(rowIndex, columnIndex);
				dataGrid.Focus();
			}
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			try
			{
				if (searchForm == null)
				{
					searchForm = new SearchForm(dsData, GetSearchItems(), searchCallback);
					searchForm.Owner = this;
					searchForm.Show();
				}
				else
				{
					searchForm.Visible = true;
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex);
			}
			finally
			{
			}
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
#if DEBUG
			return;
#endif

			if (tabControl.SelectedIndex == 0)
			{
				searchForm.Visible = false;
			}
		}

		protected void OnCommit()
		{
			if (actionStatus == ActionStatus.Add)
			{
				if (InsertData())
				{
					SetUserRights();
					actionStatus = ActionStatus.Navigate;
					LockControls(true);
					//this.dataGrid.DataSource = this.persistant.Dataset.Tables[0];
					MoveLast();
				}
			}
			else if (actionStatus == ActionStatus.Edit)
			{
				if (UpdateData())
				{
					try
					{
						SetUserRights();
						BindDataToGrid();
						actionStatus = ActionStatus.Navigate;

						MoveToIndex(currentIndex);
					}
					catch (Exception ex)
					{
						Log.LogError(ex);
					}
					finally
					{
						LockControls(true);
					}
				}
			}
		}

		protected void OnCancel()
		{
			actionStatus = ActionStatus.Navigate;
			SetUserRights();
			ClearControls();
			MoveToIndex(currentIndex);
			LockControls(true);
		}
	}
}