/*

	   file: UserRightsDialog.cs
description: dialog which displays user's data
	 author: Gheorghe MARius

*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;
using voidsoft.Sunrise.DataSystem;

namespace voidsoft.Sunrise.Main.Dialogs
{
	/// <summary>
	///
	/// </summary>
	public class UserRightsDialog : Form
	{
		private Panel panel1;
		private TabControl tabControl;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Label label1;
		private Label label2;
		private TreeView twUserRights;
		private Button buttonCancel;
		private Label labelUsers;
		private CheckBox checkBoxIsAdministrator;
		private TextBox textUserName;
		private TextBox textPassword;
		private Button buttonOK;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private UsersTableMetadata currentUser;

		private SortedList slEntities;
		private PictureBox pictureBox;
		private SortedList slUserRights;

		private DataSet dsEntityUserRights;

		/// <summary>
		/// 
		/// </summary>
		public UserRightsDialog()
		{
			InitializeComponent();

			slEntities = new SortedList();
			slUserRights = new SortedList();
			dsEntityUserRights = new DataSet();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentUser"></param>
		public UserRightsDialog(UsersTableMetadata currentUser)
		{
			slEntities = new SortedList();
			slUserRights = new SortedList();
			this.currentUser = currentUser;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (UserRightsDialog));
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelUsers = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxIsAdministrator = new System.Windows.Forms.CheckBox();
			this.textUserName = new System.Windows.Forms.TextBox();
			this.textPassword = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.twUserRights = new System.Windows.Forms.TreeView();
			this.panel1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AccessibleDescription = resources.GetString("panel1.AccessibleDescription");
			this.panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("panel1.Anchor")));
			this.panel1.AutoScroll = ((bool) (resources.GetObject("panel1.AutoScroll")));
			this.panel1.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("panel1.AutoScrollMargin")));
			this.panel1.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("panel1.AutoScrollMinSize")));
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Controls.Add(this.labelUsers);
			this.panel1.Controls.Add(this.pictureBox);
			this.panel1.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("panel1.Dock")));
			this.panel1.Enabled = ((bool) (resources.GetObject("panel1.Enabled")));
			this.panel1.Font = ((System.Drawing.Font) (resources.GetObject("panel1.Font")));
			this.panel1.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("panel1.ImeMode")));
			this.panel1.Location = ((System.Drawing.Point) (resources.GetObject("panel1.Location")));
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("panel1.RightToLeft")));
			this.panel1.Size = ((System.Drawing.Size) (resources.GetObject("panel1.Size")));
			this.panel1.TabIndex = ((int) (resources.GetObject("panel1.TabIndex")));
			this.panel1.Text = resources.GetString("panel1.Text");
			this.panel1.Visible = ((bool) (resources.GetObject("panel1.Visible")));
			// 
			// labelUsers
			// 
			this.labelUsers.AccessibleDescription = resources.GetString("labelUsers.AccessibleDescription");
			this.labelUsers.AccessibleName = resources.GetString("labelUsers.AccessibleName");
			this.labelUsers.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelUsers.Anchor")));
			this.labelUsers.AutoSize = ((bool) (resources.GetObject("labelUsers.AutoSize")));
			this.labelUsers.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelUsers.Dock")));
			this.labelUsers.Enabled = ((bool) (resources.GetObject("labelUsers.Enabled")));
			this.labelUsers.Font = ((System.Drawing.Font) (resources.GetObject("labelUsers.Font")));
			this.labelUsers.Image = ((System.Drawing.Image) (resources.GetObject("labelUsers.Image")));
			this.labelUsers.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelUsers.ImageAlign")));
			this.labelUsers.ImageIndex = ((int) (resources.GetObject("labelUsers.ImageIndex")));
			this.labelUsers.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelUsers.ImeMode")));
			this.labelUsers.Location = ((System.Drawing.Point) (resources.GetObject("labelUsers.Location")));
			this.labelUsers.Name = "labelUsers";
			this.labelUsers.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelUsers.RightToLeft")));
			this.labelUsers.Size = ((System.Drawing.Size) (resources.GetObject("labelUsers.Size")));
			this.labelUsers.TabIndex = ((int) (resources.GetObject("labelUsers.TabIndex")));
			this.labelUsers.Text = resources.GetString("labelUsers.Text");
			this.labelUsers.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelUsers.TextAlign")));
			this.labelUsers.Visible = ((bool) (resources.GetObject("labelUsers.Visible")));
			// 
			// pictureBox
			// 
			this.pictureBox.AccessibleDescription = resources.GetString("pictureBox.AccessibleDescription");
			this.pictureBox.AccessibleName = resources.GetString("pictureBox.AccessibleName");
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBox.Anchor")));
			this.pictureBox.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBox.BackgroundImage")));
			this.pictureBox.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBox.Dock")));
			this.pictureBox.Enabled = ((bool) (resources.GetObject("pictureBox.Enabled")));
			this.pictureBox.Font = ((System.Drawing.Font) (resources.GetObject("pictureBox.Font")));
			this.pictureBox.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox.Image")));
			this.pictureBox.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBox.ImeMode")));
			this.pictureBox.Location = ((System.Drawing.Point) (resources.GetObject("pictureBox.Location")));
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBox.RightToLeft")));
			this.pictureBox.Size = ((System.Drawing.Size) (resources.GetObject("pictureBox.Size")));
			this.pictureBox.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBox.SizeMode")));
			this.pictureBox.TabIndex = ((int) (resources.GetObject("pictureBox.TabIndex")));
			this.pictureBox.TabStop = false;
			this.pictureBox.Text = resources.GetString("pictureBox.Text");
			this.pictureBox.Visible = ((bool) (resources.GetObject("pictureBox.Visible")));
			// 
			// buttonOK
			// 
			this.buttonOK.AccessibleDescription = resources.GetString("buttonOK.AccessibleDescription");
			this.buttonOK.AccessibleName = resources.GetString("buttonOK.AccessibleName");
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("buttonOK.Anchor")));
			this.buttonOK.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonOK.BackgroundImage")));
			this.buttonOK.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("buttonOK.Dock")));
			this.buttonOK.Enabled = ((bool) (resources.GetObject("buttonOK.Enabled")));
			this.buttonOK.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("buttonOK.FlatStyle")));
			this.buttonOK.Font = ((System.Drawing.Font) (resources.GetObject("buttonOK.Font")));
			this.buttonOK.Image = ((System.Drawing.Image) (resources.GetObject("buttonOK.Image")));
			this.buttonOK.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonOK.ImageAlign")));
			this.buttonOK.ImageIndex = ((int) (resources.GetObject("buttonOK.ImageIndex")));
			this.buttonOK.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("buttonOK.ImeMode")));
			this.buttonOK.Location = ((System.Drawing.Point) (resources.GetObject("buttonOK.Location")));
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("buttonOK.RightToLeft")));
			this.buttonOK.Size = ((System.Drawing.Size) (resources.GetObject("buttonOK.Size")));
			this.buttonOK.TabIndex = ((int) (resources.GetObject("buttonOK.TabIndex")));
			this.buttonOK.Text = resources.GetString("buttonOK.Text");
			this.buttonOK.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonOK.TextAlign")));
			this.buttonOK.Visible = ((bool) (resources.GetObject("buttonOK.Visible")));
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AccessibleDescription = resources.GetString("buttonCancel.AccessibleDescription");
			this.buttonCancel.AccessibleName = resources.GetString("buttonCancel.AccessibleName");
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("buttonCancel.Anchor")));
			this.buttonCancel.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonCancel.BackgroundImage")));
			this.buttonCancel.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("buttonCancel.Dock")));
			this.buttonCancel.Enabled = ((bool) (resources.GetObject("buttonCancel.Enabled")));
			this.buttonCancel.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("buttonCancel.FlatStyle")));
			this.buttonCancel.Font = ((System.Drawing.Font) (resources.GetObject("buttonCancel.Font")));
			this.buttonCancel.Image = ((System.Drawing.Image) (resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonCancel.ImageAlign")));
			this.buttonCancel.ImageIndex = ((int) (resources.GetObject("buttonCancel.ImageIndex")));
			this.buttonCancel.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("buttonCancel.ImeMode")));
			this.buttonCancel.Location = ((System.Drawing.Point) (resources.GetObject("buttonCancel.Location")));
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("buttonCancel.RightToLeft")));
			this.buttonCancel.Size = ((System.Drawing.Size) (resources.GetObject("buttonCancel.Size")));
			this.buttonCancel.TabIndex = ((int) (resources.GetObject("buttonCancel.TabIndex")));
			this.buttonCancel.Text = resources.GetString("buttonCancel.Text");
			this.buttonCancel.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonCancel.TextAlign")));
			this.buttonCancel.Visible = ((bool) (resources.GetObject("buttonCancel.Visible")));
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tabControl
			// 
			this.tabControl.AccessibleDescription = resources.GetString("tabControl.AccessibleDescription");
			this.tabControl.AccessibleName = resources.GetString("tabControl.AccessibleName");
			this.tabControl.Alignment = ((System.Windows.Forms.TabAlignment) (resources.GetObject("tabControl.Alignment")));
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("tabControl.Anchor")));
			this.tabControl.Appearance = ((System.Windows.Forms.TabAppearance) (resources.GetObject("tabControl.Appearance")));
			this.tabControl.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("tabControl.BackgroundImage")));
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("tabControl.Dock")));
			this.tabControl.Enabled = ((bool) (resources.GetObject("tabControl.Enabled")));
			this.tabControl.Font = ((System.Drawing.Font) (resources.GetObject("tabControl.Font")));
			this.tabControl.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("tabControl.ImeMode")));
			this.tabControl.ItemSize = ((System.Drawing.Size) (resources.GetObject("tabControl.ItemSize")));
			this.tabControl.Location = ((System.Drawing.Point) (resources.GetObject("tabControl.Location")));
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = ((System.Drawing.Point) (resources.GetObject("tabControl.Padding")));
			this.tabControl.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("tabControl.RightToLeft")));
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = ((bool) (resources.GetObject("tabControl.ShowToolTips")));
			this.tabControl.Size = ((System.Drawing.Size) (resources.GetObject("tabControl.Size")));
			this.tabControl.TabIndex = ((int) (resources.GetObject("tabControl.TabIndex")));
			this.tabControl.Text = resources.GetString("tabControl.Text");
			this.tabControl.Visible = ((bool) (resources.GetObject("tabControl.Visible")));
			// 
			// tabPage1
			// 
			this.tabPage1.AccessibleDescription = resources.GetString("tabPage1.AccessibleDescription");
			this.tabPage1.AccessibleName = resources.GetString("tabPage1.AccessibleName");
			this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("tabPage1.Anchor")));
			this.tabPage1.AutoScroll = ((bool) (resources.GetObject("tabPage1.AutoScroll")));
			this.tabPage1.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("tabPage1.AutoScrollMargin")));
			this.tabPage1.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("tabPage1.AutoScrollMinSize")));
			this.tabPage1.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("tabPage1.BackgroundImage")));
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.checkBoxIsAdministrator);
			this.tabPage1.Controls.Add(this.textUserName);
			this.tabPage1.Controls.Add(this.textPassword);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("tabPage1.Dock")));
			this.tabPage1.Enabled = ((bool) (resources.GetObject("tabPage1.Enabled")));
			this.tabPage1.Font = ((System.Drawing.Font) (resources.GetObject("tabPage1.Font")));
			this.tabPage1.ImageIndex = ((int) (resources.GetObject("tabPage1.ImageIndex")));
			this.tabPage1.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("tabPage1.ImeMode")));
			this.tabPage1.Location = ((System.Drawing.Point) (resources.GetObject("tabPage1.Location")));
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("tabPage1.RightToLeft")));
			this.tabPage1.Size = ((System.Drawing.Size) (resources.GetObject("tabPage1.Size")));
			this.tabPage1.TabIndex = ((int) (resources.GetObject("tabPage1.TabIndex")));
			this.tabPage1.Text = resources.GetString("tabPage1.Text");
			this.tabPage1.ToolTipText = resources.GetString("tabPage1.ToolTipText");
			this.tabPage1.Visible = ((bool) (resources.GetObject("tabPage1.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool) (resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool) (resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font) (resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image) (resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int) (resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point) (resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size) (resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int) (resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool) (resources.GetObject("label2.Visible")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool) (resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool) (resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font) (resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image) (resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int) (resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point) (resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size) (resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int) (resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool) (resources.GetObject("label1.Visible")));
			// 
			// checkBoxIsAdministrator
			// 
			this.checkBoxIsAdministrator.AccessibleDescription = resources.GetString("checkBoxIsAdministrator.AccessibleDescription");
			this.checkBoxIsAdministrator.AccessibleName = resources.GetString("checkBoxIsAdministrator.AccessibleName");
			this.checkBoxIsAdministrator.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("checkBoxIsAdministrator.Anchor")));
			this.checkBoxIsAdministrator.Appearance = ((System.Windows.Forms.Appearance) (resources.GetObject("checkBoxIsAdministrator.Appearance")));
			this.checkBoxIsAdministrator.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("checkBoxIsAdministrator.BackgroundImage")));
			this.checkBoxIsAdministrator.CheckAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("checkBoxIsAdministrator.CheckAlign")));
			this.checkBoxIsAdministrator.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("checkBoxIsAdministrator.Dock")));
			this.checkBoxIsAdministrator.Enabled = ((bool) (resources.GetObject("checkBoxIsAdministrator.Enabled")));
			this.checkBoxIsAdministrator.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("checkBoxIsAdministrator.FlatStyle")));
			this.checkBoxIsAdministrator.Font = ((System.Drawing.Font) (resources.GetObject("checkBoxIsAdministrator.Font")));
			this.checkBoxIsAdministrator.Image = ((System.Drawing.Image) (resources.GetObject("checkBoxIsAdministrator.Image")));
			this.checkBoxIsAdministrator.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("checkBoxIsAdministrator.ImageAlign")));
			this.checkBoxIsAdministrator.ImageIndex = ((int) (resources.GetObject("checkBoxIsAdministrator.ImageIndex")));
			this.checkBoxIsAdministrator.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("checkBoxIsAdministrator.ImeMode")));
			this.checkBoxIsAdministrator.Location = ((System.Drawing.Point) (resources.GetObject("checkBoxIsAdministrator.Location")));
			this.checkBoxIsAdministrator.Name = "checkBoxIsAdministrator";
			this.checkBoxIsAdministrator.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("checkBoxIsAdministrator.RightToLeft")));
			this.checkBoxIsAdministrator.Size = ((System.Drawing.Size) (resources.GetObject("checkBoxIsAdministrator.Size")));
			this.checkBoxIsAdministrator.TabIndex = ((int) (resources.GetObject("checkBoxIsAdministrator.TabIndex")));
			this.checkBoxIsAdministrator.Text = resources.GetString("checkBoxIsAdministrator.Text");
			this.checkBoxIsAdministrator.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("checkBoxIsAdministrator.TextAlign")));
			this.checkBoxIsAdministrator.Visible = ((bool) (resources.GetObject("checkBoxIsAdministrator.Visible")));
			// 
			// textUserName
			// 
			this.textUserName.AccessibleDescription = resources.GetString("textUserName.AccessibleDescription");
			this.textUserName.AccessibleName = resources.GetString("textUserName.AccessibleName");
			this.textUserName.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("textUserName.Anchor")));
			this.textUserName.AutoSize = ((bool) (resources.GetObject("textUserName.AutoSize")));
			this.textUserName.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("textUserName.BackgroundImage")));
			this.textUserName.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("textUserName.Dock")));
			this.textUserName.Enabled = ((bool) (resources.GetObject("textUserName.Enabled")));
			this.textUserName.Font = ((System.Drawing.Font) (resources.GetObject("textUserName.Font")));
			this.textUserName.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("textUserName.ImeMode")));
			this.textUserName.Location = ((System.Drawing.Point) (resources.GetObject("textUserName.Location")));
			this.textUserName.MaxLength = ((int) (resources.GetObject("textUserName.MaxLength")));
			this.textUserName.Multiline = ((bool) (resources.GetObject("textUserName.Multiline")));
			this.textUserName.Name = "textUserName";
			this.textUserName.PasswordChar = ((char) (resources.GetObject("textUserName.PasswordChar")));
			this.textUserName.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("textUserName.RightToLeft")));
			this.textUserName.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject("textUserName.ScrollBars")));
			this.textUserName.Size = ((System.Drawing.Size) (resources.GetObject("textUserName.Size")));
			this.textUserName.TabIndex = ((int) (resources.GetObject("textUserName.TabIndex")));
			this.textUserName.Text = resources.GetString("textUserName.Text");
			this.textUserName.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject("textUserName.TextAlign")));
			this.textUserName.Visible = ((bool) (resources.GetObject("textUserName.Visible")));
			this.textUserName.WordWrap = ((bool) (resources.GetObject("textUserName.WordWrap")));
			// 
			// textPassword
			// 
			this.textPassword.AccessibleDescription = resources.GetString("textPassword.AccessibleDescription");
			this.textPassword.AccessibleName = resources.GetString("textPassword.AccessibleName");
			this.textPassword.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("textPassword.Anchor")));
			this.textPassword.AutoSize = ((bool) (resources.GetObject("textPassword.AutoSize")));
			this.textPassword.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("textPassword.BackgroundImage")));
			this.textPassword.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("textPassword.Dock")));
			this.textPassword.Enabled = ((bool) (resources.GetObject("textPassword.Enabled")));
			this.textPassword.Font = ((System.Drawing.Font) (resources.GetObject("textPassword.Font")));
			this.textPassword.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("textPassword.ImeMode")));
			this.textPassword.Location = ((System.Drawing.Point) (resources.GetObject("textPassword.Location")));
			this.textPassword.MaxLength = ((int) (resources.GetObject("textPassword.MaxLength")));
			this.textPassword.Multiline = ((bool) (resources.GetObject("textPassword.Multiline")));
			this.textPassword.Name = "textPassword";
			this.textPassword.PasswordChar = ((char) (resources.GetObject("textPassword.PasswordChar")));
			this.textPassword.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("textPassword.RightToLeft")));
			this.textPassword.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject("textPassword.ScrollBars")));
			this.textPassword.Size = ((System.Drawing.Size) (resources.GetObject("textPassword.Size")));
			this.textPassword.TabIndex = ((int) (resources.GetObject("textPassword.TabIndex")));
			this.textPassword.Text = resources.GetString("textPassword.Text");
			this.textPassword.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject("textPassword.TextAlign")));
			this.textPassword.Visible = ((bool) (resources.GetObject("textPassword.Visible")));
			this.textPassword.WordWrap = ((bool) (resources.GetObject("textPassword.WordWrap")));
			// 
			// tabPage2
			// 
			this.tabPage2.AccessibleDescription = resources.GetString("tabPage2.AccessibleDescription");
			this.tabPage2.AccessibleName = resources.GetString("tabPage2.AccessibleName");
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("tabPage2.Anchor")));
			this.tabPage2.AutoScroll = ((bool) (resources.GetObject("tabPage2.AutoScroll")));
			this.tabPage2.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("tabPage2.AutoScrollMargin")));
			this.tabPage2.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("tabPage2.AutoScrollMinSize")));
			this.tabPage2.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("tabPage2.BackgroundImage")));
			this.tabPage2.Controls.Add(this.twUserRights);
			this.tabPage2.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("tabPage2.Dock")));
			this.tabPage2.Enabled = ((bool) (resources.GetObject("tabPage2.Enabled")));
			this.tabPage2.Font = ((System.Drawing.Font) (resources.GetObject("tabPage2.Font")));
			this.tabPage2.ImageIndex = ((int) (resources.GetObject("tabPage2.ImageIndex")));
			this.tabPage2.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("tabPage2.ImeMode")));
			this.tabPage2.Location = ((System.Drawing.Point) (resources.GetObject("tabPage2.Location")));
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("tabPage2.RightToLeft")));
			this.tabPage2.Size = ((System.Drawing.Size) (resources.GetObject("tabPage2.Size")));
			this.tabPage2.TabIndex = ((int) (resources.GetObject("tabPage2.TabIndex")));
			this.tabPage2.Text = resources.GetString("tabPage2.Text");
			this.tabPage2.ToolTipText = resources.GetString("tabPage2.ToolTipText");
			this.tabPage2.Visible = ((bool) (resources.GetObject("tabPage2.Visible")));
			// 
			// twUserRights
			// 
			this.twUserRights.AccessibleDescription = resources.GetString("twUserRights.AccessibleDescription");
			this.twUserRights.AccessibleName = resources.GetString("twUserRights.AccessibleName");
			this.twUserRights.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("twUserRights.Anchor")));
			this.twUserRights.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("twUserRights.BackgroundImage")));
			this.twUserRights.CheckBoxes = true;
			this.twUserRights.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("twUserRights.Dock")));
			this.twUserRights.Enabled = ((bool) (resources.GetObject("twUserRights.Enabled")));
			this.twUserRights.Font = ((System.Drawing.Font) (resources.GetObject("twUserRights.Font")));
			this.twUserRights.ImageIndex = ((int) (resources.GetObject("twUserRights.ImageIndex")));
			this.twUserRights.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("twUserRights.ImeMode")));
			this.twUserRights.Indent = ((int) (resources.GetObject("twUserRights.Indent")));
			this.twUserRights.ItemHeight = ((int) (resources.GetObject("twUserRights.ItemHeight")));
			this.twUserRights.Location = ((System.Drawing.Point) (resources.GetObject("twUserRights.Location")));
			this.twUserRights.Name = "twUserRights";
			this.twUserRights.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("twUserRights.RightToLeft")));
			this.twUserRights.Scrollable = false;
			this.twUserRights.SelectedImageIndex = ((int) (resources.GetObject("twUserRights.SelectedImageIndex")));
			this.twUserRights.Size = ((System.Drawing.Size) (resources.GetObject("twUserRights.Size")));
			this.twUserRights.TabIndex = ((int) (resources.GetObject("twUserRights.TabIndex")));
			this.twUserRights.Text = resources.GetString("twUserRights.Text");
			this.twUserRights.Visible = ((bool) (resources.GetObject("twUserRights.Visible")));
			this.twUserRights.Click += new System.EventHandler(this.UserRightsDialog_Click);
			// 
			// UserRightsDialog
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool) (resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size) (resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Enabled = ((bool) (resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font) (resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point) (resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size) (resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size) (resources.GetObject("$this.MinimumSize")));
			this.Name = "UserRightsDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition) (resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Click += new System.EventHandler(this.UserRightsDialog_Click);
			this.Load += new System.EventHandler(this.UserRightsDialog_Load);
			this.panel1.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private void UserRightsDialog_Load(object sender, EventArgs e)
		{
			try
			{
				LoadEntities();

				//update mode so load user data;
				if (currentUser != null)
				{
					LoadUserRights(currentUser.Id);

					//SystemServices.GetUsersData(this.userID, out password, out isAdministrator);

					textPassword.Text = currentUser.Password;
					textUserName.Text = currentUser.Name;
					checkBoxIsAdministrator.Checked = currentUser.IsAdmin;
				}
			}
			catch (Exception ex)
			{
				Log.LogError("UserRightsDialog_Load " + ex.StackTrace);
				MessageBox.Show("Failed to load user data");
				Close();
			}
		}

		/// <summary>
		/// Loads the entities list and user rights
		/// </summary>
		private void LoadEntities()
		{
			try
			{
				//load the list of entities
				slEntities = EntityServices.GetEntities();

				//load the supported rights 
				dsEntityUserRights = EntityServices.GetEntitySupportedRights();

				//load the user rights
				slUserRights = EntityServices.GetUserRights();

				//loads the list of entities into the treeview

				IDictionaryEnumerator ienum = slEntities.GetEnumerator();

				while (ienum.MoveNext())
				{
					twUserRights.Nodes.Add(ienum.Value.ToString());
					twUserRights.Nodes[twUserRights.Nodes.Count - 1].Tag = ienum.Key.ToString();
				}

				//for each entity load the supported user rights

				for (int i = 0; i < twUserRights.Nodes.Count; i++)
				{
					//get the key of the current entity
					object key = twUserRights.Nodes[i].Tag;

					//get the supported rights;

					DataRow[] drow = dsEntityUserRights.Tables[0].Select("EntityId = " + key);

					for (int j = 0; j < drow.Length; j++)
					{
						int index = slUserRights.IndexOfKey(drow[j][1]);
						string userRightName = slUserRights.GetByIndex(index).ToString();

						twUserRights.Nodes[i].Nodes.Add(userRightName);
						twUserRights.Nodes[i].Nodes[twUserRights.Nodes[i].Nodes.Count - 1].Tag = drow[j][1];
					}

					//
					//					IDictionaryEnumerator ie = (IDictionaryEnumerator) slUserRights.GetEnumerator();
					//
					//					while(ie.MoveNext())
					//					{
					//						this.twUserRights.Nodes[i].Nodes.Add(ie.Value.ToString());
					//						this.twUserRights.Nodes[i].Nodes[this.twUserRights.Nodes[i].Nodes.Count - 1].Tag = ie.Key.ToString();
					//
					//					}
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

		/// <summary>
		/// Loads user rights.
		/// </summary>
		private void LoadUserRights(int userID)
		{
			DataSet dsUserRights = null;

			try
			{
				dsUserRights = EntityServices.GetEntityUserRights(userID);

				for (int i = 0; i < twUserRights.Nodes.Count; i++)
				{
					object id = twUserRights.Nodes[i].Tag;

					DataRow[] rows = dsUserRights.Tables[0].Select("EntityId=" + id);

					for (int j = 0; j < rows.Length; j++)
					{
						for (int x = 0; x < twUserRights.Nodes[i].Nodes.Count; x++)
						{
							if (rows[j]["UserRightsId"].ToString() == twUserRights.Nodes[i].Nodes[x].Tag.ToString())
							{
								twUserRights.Nodes[i].Nodes[x].Checked = Convert.ToBoolean(rows[j]["Flag"]);
								twUserRights.Nodes[i].Nodes[x].Tag = rows[j]["UserRightsID"];
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.LogError("LoadUserRights " + ex.StackTrace);
				throw ex;
			}
			finally
			{
				if (dsUserRights != null)
				{
					dsUserRights.Dispose();
				}
			}
		}

		private void CreateUser()
		{
			try
			{
				ArrayList alTemp = new ArrayList();

				UsersTableMetadata user = new UsersTableMetadata();
				user.IsAdmin = checkBoxIsAdministrator.Checked;
				user.Name = textUserName.Text.Trim();
				user.Password = textPassword.Text.Trim();

				for (int i = 0; i < twUserRights.Nodes.Count; i++)
				{
					for (int j = 0; j < twUserRights.Nodes[i].Nodes.Count; j++)
					{
						EntityUserRightsTableMetadata usr = new EntityUserRightsTableMetadata();
						usr.EntityId = Convert.ToInt32(twUserRights.Nodes[i].Tag);
						usr.Flag = twUserRights.Nodes[i].Nodes[j].Checked;
						usr.UserId = -1;
						usr.UserRightsId = Convert.ToInt32(twUserRights.Nodes[i].Nodes[j].Tag);

						alTemp.Add(usr);
					}
				}

				//copy 
				EntityUserRightsTableMetadata[] userData = new EntityUserRightsTableMetadata[alTemp.Count];
				alTemp.CopyTo(userData);

				UserServices.CreateUser(user, userData);
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
		}

		private void UpdateUser()
		{
			try
			{
				//use a temporary array list instead of fixed initialized array
				//because in the future each entity can support a different number
				//of user rights.

				ArrayList alTemp = new ArrayList();

				currentUser.IsAdmin = checkBoxIsAdministrator.Checked;
				currentUser.Name = textUserName.Text.Trim();
				currentUser.Password = textPassword.Text.Trim();

				for (int i = 0; i < twUserRights.Nodes.Count; i++)
				{
					for (int j = 0; j < twUserRights.Nodes[i].Nodes.Count; j++)
					{
						EntityUserRightsTableMetadata usr = new EntityUserRightsTableMetadata();
						usr.EntityId = Convert.ToInt32(twUserRights.Nodes[i].Tag);
						usr.Flag = twUserRights.Nodes[i].Nodes[j].Checked;
						usr.UserId = currentUser.Id;
						usr.UserRightsId = Convert.ToInt32(twUserRights.Nodes[i].Nodes[j].Tag);

						alTemp.Add(usr);
					}
				}

				//copy 
				EntityUserRightsTableMetadata[] userData = new EntityUserRightsTableMetadata[alTemp.Count];
				alTemp.CopyTo(userData);

				UserServices.UpdateUser(currentUser, userData);
			}
			catch (Exception ex)
			{
				Log.LogError("UpdateUser " + ex.Message);
			}
		}

		private bool ValidateUserData()
		{
			if (textUserName.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter user name");
				return false;
			}

			if (textPassword.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter user password");
				return false;
			}

			//if it's a new user check his name
			if (currentUser == null)
			{
				if (UserServices.IsUserName(textUserName.Text.Trim()))
				{
					MessageBox.Show("Invalid user name. The name already exists. Please choose another one");
					return true;
				}
			}

			return true;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UserRightsDialog_Click(object sender, EventArgs e)
		{
			//			if(this.twUserRights.SelectedNode.Parent == null)
			//			{
			//				for(int i = 0 ; i < this.twUserRights.SelectedNode.Nodes.Count; i++)
			//				{
			//					this.twUserRights.SelectedNode.Nodes[i].Checked = this.twUserRights.SelectedNode.Checked;
			//				}
			//			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (ValidateUserData())
			{
				try
				{
					if (currentUser != null)
					{
						UpdateUser();
					}
					else
					{
						CreateUser();
					}

					Close();
				}
				catch (Exception ex)
				{
				}
			}
		}
	}
}