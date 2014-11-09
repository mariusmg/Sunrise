/*

	   file: LogonUserDialog.cs
description: allows the user to logon.
	 author: Gheorghe MARius.


*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;
using voidsoft.Sunrise.DataSystem;

namespace voidsoft.Sunrise.Main.Dialogs
{
	/// <summary>
	/// Summary description for LogonUserDialog.
	/// </summary>
	public class LogonUserDialog : Form
	{
		private Button buttonOK;
		private Button buttonCancel;
		private TextBox textUserPassword;
		private TextBox textUserName;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private Label labelLogOn;
		private ComboBox comboBoxCompanies;
		private Label labelCompany;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private SortedList sdCompaniesList;
		private Label labelUser;
		private Label labelPassword;
		private int selectedCompanyID = -1;

		public LogonUserDialog()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (LogonUserDialog));
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textUserPassword = new System.Windows.Forms.TextBox();
			this.textUserName = new System.Windows.Forms.TextBox();
			this.labelUser = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.labelLogOn = new System.Windows.Forms.Label();
			this.comboBoxCompanies = new System.Windows.Forms.ComboBox();
			this.labelCompany = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
			// textUserPassword
			// 
			this.textUserPassword.AccessibleDescription = resources.GetString("textUserPassword.AccessibleDescription");
			this.textUserPassword.AccessibleName = resources.GetString("textUserPassword.AccessibleName");
			this.textUserPassword.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("textUserPassword.Anchor")));
			this.textUserPassword.AutoSize = ((bool) (resources.GetObject("textUserPassword.AutoSize")));
			this.textUserPassword.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("textUserPassword.BackgroundImage")));
			this.textUserPassword.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("textUserPassword.Dock")));
			this.textUserPassword.Enabled = ((bool) (resources.GetObject("textUserPassword.Enabled")));
			this.textUserPassword.Font = ((System.Drawing.Font) (resources.GetObject("textUserPassword.Font")));
			this.textUserPassword.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("textUserPassword.ImeMode")));
			this.textUserPassword.Location = ((System.Drawing.Point) (resources.GetObject("textUserPassword.Location")));
			this.textUserPassword.MaxLength = ((int) (resources.GetObject("textUserPassword.MaxLength")));
			this.textUserPassword.Multiline = ((bool) (resources.GetObject("textUserPassword.Multiline")));
			this.textUserPassword.Name = "textUserPassword";
			this.textUserPassword.PasswordChar = ((char) (resources.GetObject("textUserPassword.PasswordChar")));
			this.textUserPassword.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("textUserPassword.RightToLeft")));
			this.textUserPassword.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject("textUserPassword.ScrollBars")));
			this.textUserPassword.Size = ((System.Drawing.Size) (resources.GetObject("textUserPassword.Size")));
			this.textUserPassword.TabIndex = ((int) (resources.GetObject("textUserPassword.TabIndex")));
			this.textUserPassword.Text = resources.GetString("textUserPassword.Text");
			this.textUserPassword.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject("textUserPassword.TextAlign")));
			this.textUserPassword.Visible = ((bool) (resources.GetObject("textUserPassword.Visible")));
			this.textUserPassword.WordWrap = ((bool) (resources.GetObject("textUserPassword.WordWrap")));
			this.textUserPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textUserPassword_KeyUp);
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
			this.textUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textUserName_KeyUp);
			// 
			// labelUser
			// 
			this.labelUser.AccessibleDescription = resources.GetString("labelUser.AccessibleDescription");
			this.labelUser.AccessibleName = resources.GetString("labelUser.AccessibleName");
			this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelUser.Anchor")));
			this.labelUser.AutoSize = ((bool) (resources.GetObject("labelUser.AutoSize")));
			this.labelUser.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelUser.Dock")));
			this.labelUser.Enabled = ((bool) (resources.GetObject("labelUser.Enabled")));
			this.labelUser.Font = ((System.Drawing.Font) (resources.GetObject("labelUser.Font")));
			this.labelUser.Image = ((System.Drawing.Image) (resources.GetObject("labelUser.Image")));
			this.labelUser.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelUser.ImageAlign")));
			this.labelUser.ImageIndex = ((int) (resources.GetObject("labelUser.ImageIndex")));
			this.labelUser.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelUser.ImeMode")));
			this.labelUser.Location = ((System.Drawing.Point) (resources.GetObject("labelUser.Location")));
			this.labelUser.Name = "labelUser";
			this.labelUser.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelUser.RightToLeft")));
			this.labelUser.Size = ((System.Drawing.Size) (resources.GetObject("labelUser.Size")));
			this.labelUser.TabIndex = ((int) (resources.GetObject("labelUser.TabIndex")));
			this.labelUser.Text = resources.GetString("labelUser.Text");
			this.labelUser.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelUser.TextAlign")));
			this.labelUser.Visible = ((bool) (resources.GetObject("labelUser.Visible")));
			// 
			// labelPassowrd
			// 
			this.labelPassword.AccessibleDescription = resources.GetString("labelPassowrd.AccessibleDescription");
			this.labelPassword.AccessibleName = resources.GetString("labelPassowrd.AccessibleName");
			this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelPassowrd.Anchor")));
			this.labelPassword.AutoSize = ((bool) (resources.GetObject("labelPassowrd.AutoSize")));
			this.labelPassword.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelPassowrd.Dock")));
			this.labelPassword.Enabled = ((bool) (resources.GetObject("labelPassowrd.Enabled")));
			this.labelPassword.Font = ((System.Drawing.Font) (resources.GetObject("labelPassowrd.Font")));
			this.labelPassword.Image = ((System.Drawing.Image) (resources.GetObject("labelPassowrd.Image")));
			this.labelPassword.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelPassowrd.ImageAlign")));
			this.labelPassword.ImageIndex = ((int) (resources.GetObject("labelPassowrd.ImageIndex")));
			this.labelPassword.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelPassowrd.ImeMode")));
			this.labelPassword.Location = ((System.Drawing.Point) (resources.GetObject("labelPassowrd.Location")));
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelPassowrd.RightToLeft")));
			this.labelPassword.Size = ((System.Drawing.Size) (resources.GetObject("labelPassowrd.Size")));
			this.labelPassword.TabIndex = ((int) (resources.GetObject("labelPassowrd.TabIndex")));
			this.labelPassword.Text = resources.GetString("labelPassowrd.Text");
			this.labelPassword.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelPassowrd.TextAlign")));
			this.labelPassword.Visible = ((bool) (resources.GetObject("labelPassowrd.Visible")));
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = resources.GetString("pictureBox1.AccessibleDescription");
			this.pictureBox1.AccessibleName = resources.GetString("pictureBox1.AccessibleName");
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBox1.Anchor")));
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBox1.Dock")));
			this.pictureBox1.Enabled = ((bool) (resources.GetObject("pictureBox1.Enabled")));
			this.pictureBox1.Font = ((System.Drawing.Font) (resources.GetObject("pictureBox1.Font")));
			this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBox1.ImeMode")));
			this.pictureBox1.Location = ((System.Drawing.Point) (resources.GetObject("pictureBox1.Location")));
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBox1.RightToLeft")));
			this.pictureBox1.Size = ((System.Drawing.Size) (resources.GetObject("pictureBox1.Size")));
			this.pictureBox1.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBox1.SizeMode")));
			this.pictureBox1.TabIndex = ((int) (resources.GetObject("pictureBox1.TabIndex")));
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Text = resources.GetString("pictureBox1.Text");
			this.pictureBox1.Visible = ((bool) (resources.GetObject("pictureBox1.Visible")));
			// 
			// pictureBox2
			// 
			this.pictureBox2.AccessibleDescription = resources.GetString("pictureBox2.AccessibleDescription");
			this.pictureBox2.AccessibleName = resources.GetString("pictureBox2.AccessibleName");
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBox2.Anchor")));
			this.pictureBox2.BackColor = System.Drawing.Color.White;
			this.pictureBox2.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBox2.BackgroundImage")));
			this.pictureBox2.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBox2.Dock")));
			this.pictureBox2.Enabled = ((bool) (resources.GetObject("pictureBox2.Enabled")));
			this.pictureBox2.Font = ((System.Drawing.Font) (resources.GetObject("pictureBox2.Font")));
			this.pictureBox2.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBox2.ImeMode")));
			this.pictureBox2.Location = ((System.Drawing.Point) (resources.GetObject("pictureBox2.Location")));
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBox2.RightToLeft")));
			this.pictureBox2.Size = ((System.Drawing.Size) (resources.GetObject("pictureBox2.Size")));
			this.pictureBox2.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBox2.SizeMode")));
			this.pictureBox2.TabIndex = ((int) (resources.GetObject("pictureBox2.TabIndex")));
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Text = resources.GetString("pictureBox2.Text");
			this.pictureBox2.Visible = ((bool) (resources.GetObject("pictureBox2.Visible")));
			// 
			// labelLogOn
			// 
			this.labelLogOn.AccessibleDescription = resources.GetString("labelLogOn.AccessibleDescription");
			this.labelLogOn.AccessibleName = resources.GetString("labelLogOn.AccessibleName");
			this.labelLogOn.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelLogOn.Anchor")));
			this.labelLogOn.AutoSize = ((bool) (resources.GetObject("labelLogOn.AutoSize")));
			this.labelLogOn.BackColor = System.Drawing.Color.White;
			this.labelLogOn.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelLogOn.Dock")));
			this.labelLogOn.Enabled = ((bool) (resources.GetObject("labelLogOn.Enabled")));
			this.labelLogOn.Font = ((System.Drawing.Font) (resources.GetObject("labelLogOn.Font")));
			this.labelLogOn.Image = ((System.Drawing.Image) (resources.GetObject("labelLogOn.Image")));
			this.labelLogOn.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelLogOn.ImageAlign")));
			this.labelLogOn.ImageIndex = ((int) (resources.GetObject("labelLogOn.ImageIndex")));
			this.labelLogOn.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelLogOn.ImeMode")));
			this.labelLogOn.Location = ((System.Drawing.Point) (resources.GetObject("labelLogOn.Location")));
			this.labelLogOn.Name = "labelLogOn";
			this.labelLogOn.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelLogOn.RightToLeft")));
			this.labelLogOn.Size = ((System.Drawing.Size) (resources.GetObject("labelLogOn.Size")));
			this.labelLogOn.TabIndex = ((int) (resources.GetObject("labelLogOn.TabIndex")));
			this.labelLogOn.Text = resources.GetString("labelLogOn.Text");
			this.labelLogOn.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelLogOn.TextAlign")));
			this.labelLogOn.Visible = ((bool) (resources.GetObject("labelLogOn.Visible")));
			// 
			// comboBoxCompanies
			// 
			this.comboBoxCompanies.AccessibleDescription = resources.GetString("comboBoxCompanies.AccessibleDescription");
			this.comboBoxCompanies.AccessibleName = resources.GetString("comboBoxCompanies.AccessibleName");
			this.comboBoxCompanies.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("comboBoxCompanies.Anchor")));
			this.comboBoxCompanies.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("comboBoxCompanies.BackgroundImage")));
			this.comboBoxCompanies.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("comboBoxCompanies.Dock")));
			this.comboBoxCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCompanies.Enabled = ((bool) (resources.GetObject("comboBoxCompanies.Enabled")));
			this.comboBoxCompanies.Font = ((System.Drawing.Font) (resources.GetObject("comboBoxCompanies.Font")));
			this.comboBoxCompanies.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("comboBoxCompanies.ImeMode")));
			this.comboBoxCompanies.IntegralHeight = ((bool) (resources.GetObject("comboBoxCompanies.IntegralHeight")));
			this.comboBoxCompanies.ItemHeight = ((int) (resources.GetObject("comboBoxCompanies.ItemHeight")));
			this.comboBoxCompanies.Location = ((System.Drawing.Point) (resources.GetObject("comboBoxCompanies.Location")));
			this.comboBoxCompanies.MaxDropDownItems = ((int) (resources.GetObject("comboBoxCompanies.MaxDropDownItems")));
			this.comboBoxCompanies.MaxLength = ((int) (resources.GetObject("comboBoxCompanies.MaxLength")));
			this.comboBoxCompanies.Name = "comboBoxCompanies";
			this.comboBoxCompanies.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("comboBoxCompanies.RightToLeft")));
			this.comboBoxCompanies.Size = ((System.Drawing.Size) (resources.GetObject("comboBoxCompanies.Size")));
			this.comboBoxCompanies.TabIndex = ((int) (resources.GetObject("comboBoxCompanies.TabIndex")));
			this.comboBoxCompanies.Text = resources.GetString("comboBoxCompanies.Text");
			this.comboBoxCompanies.Visible = ((bool) (resources.GetObject("comboBoxCompanies.Visible")));
			// 
			// labelCompany
			// 
			this.labelCompany.AccessibleDescription = resources.GetString("labelCompany.AccessibleDescription");
			this.labelCompany.AccessibleName = resources.GetString("labelCompany.AccessibleName");
			this.labelCompany.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelCompany.Anchor")));
			this.labelCompany.AutoSize = ((bool) (resources.GetObject("labelCompany.AutoSize")));
			this.labelCompany.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelCompany.Dock")));
			this.labelCompany.Enabled = ((bool) (resources.GetObject("labelCompany.Enabled")));
			this.labelCompany.Font = ((System.Drawing.Font) (resources.GetObject("labelCompany.Font")));
			this.labelCompany.Image = ((System.Drawing.Image) (resources.GetObject("labelCompany.Image")));
			this.labelCompany.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelCompany.ImageAlign")));
			this.labelCompany.ImageIndex = ((int) (resources.GetObject("labelCompany.ImageIndex")));
			this.labelCompany.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelCompany.ImeMode")));
			this.labelCompany.Location = ((System.Drawing.Point) (resources.GetObject("labelCompany.Location")));
			this.labelCompany.Name = "labelCompany";
			this.labelCompany.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelCompany.RightToLeft")));
			this.labelCompany.Size = ((System.Drawing.Size) (resources.GetObject("labelCompany.Size")));
			this.labelCompany.TabIndex = ((int) (resources.GetObject("labelCompany.TabIndex")));
			this.labelCompany.Text = resources.GetString("labelCompany.Text");
			this.labelCompany.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelCompany.TextAlign")));
			this.labelCompany.Visible = ((bool) (resources.GetObject("labelCompany.Visible")));
			// 
			// LogonUserDialog
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool) (resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size) (resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.labelCompany);
			this.Controls.Add(this.comboBoxCompanies);
			this.Controls.Add(this.labelLogOn);
			this.Controls.Add(this.labelUser);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.textUserName);
			this.Controls.Add(this.textUserPassword);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pictureBox2);
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
			this.Name = "LogonUserDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition) (resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.TopMost = true;
			this.Load += new System.EventHandler(this.LogonUserDialog_Load);
			this.ResumeLayout(false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (textUserName.Text == string.Empty)
				{
					MessageBox.Show("Va rugam sa introduceti numele utilizatorului");
					return;
				}

				if (textUserPassword.Text == string.Empty)
				{
					MessageBox.Show("Va rugam sa introduceti parola");
					return;
				}

				string userID = string.Empty;
				bool isAdmin = false;

				//verify the user credentials
				if (UserServices.CheckUserCredentials(textUserName.Text.Trim(), textUserPassword.Text.Trim(), ref userID, ref isAdmin))
				{
					//everything is ok so set the id
					SharedData.UserId = userID;
					SharedData.UserName = textUserName.Text.Trim();
					SharedData.UserPassword = textUserPassword.Text.Trim();
					SharedData.IsAdministrator = isAdmin;

					//get the index of the selected company.
					int index = comboBoxCompanies.SelectedIndex;

					int currentIndex = -1;
					IDictionaryEnumerator ienum = sdCompaniesList.GetEnumerator();

					while (ienum.MoveNext())
					{
						++currentIndex;

						if (currentIndex == index)
						{
							selectedCompanyID = Convert.ToInt32(ienum.Key);
							break;
						}
					}

					DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageBox.Show("Invalid user");
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex.StackTrace);
			}
			finally
			{
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textUserPassword_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				buttonOK_Click(null, null);
			}
		}

		private void textUserName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				buttonOK_Click(null, null);
			}
		}

		private void LogonUserDialog_Load(object sender, EventArgs e)
		{
			LocalizeUserInterface();

			//set this stuff in debug mode
#if DEBUG
			textUserName.Text = "A";
			textUserPassword.Text = "A";
#endif

			try
			{
				//load the company list
				sdCompaniesList = CompanyServices.GetCompaniesList();

				if (sdCompaniesList.Count == 0)
				{
					Log.LogError("No company found. Quiting.....");
					MessageBox.Show("No company found. Please create the default company");
					Application.Exit();
				}
				else
				{
					IDictionaryEnumerator ienum = sdCompaniesList.GetEnumerator();

					while (ienum.MoveNext())
					{
						comboBoxCompanies.Items.Add(ienum.Value.ToString());
					}

					comboBoxCompanies.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex.StackTrace);
				throw ex;
			}
			finally
			{
			}
		}

		public void LocalizeUserInterface()
		{
			try
			{
				if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() != "en")
				{
					labelCompany.Text = Localization.GetCultureInfoResource("Company", "ObjectWire.Main.Resources.LogonUserDialog", Assembly.GetExecutingAssembly()).ToString();
					labelPassword.Text = Localization.GetCultureInfoResource("Password", "ObjectWire.Main.Resources.LogonUserDialog", Assembly.GetExecutingAssembly()).ToString();
					labelUser.Text = Localization.GetCultureInfoResource("User", "ObjectWire.Main.Resources.LogonUserDialog", Assembly.GetExecutingAssembly()).ToString();
					labelLogOn.Text = Localization.GetCultureInfoResource("LogOn", "ObjectWire.Main.Resources.LogonUserDialog", Assembly.GetExecutingAssembly()).ToString();

					buttonCancel.Text = Localization.GetCultureInfoResource("Cancel", "ObjectWire.Main.Resources.LogonUserDialog", Assembly.GetExecutingAssembly()).ToString();
					buttonOK.Text = Localization.GetCultureInfoResource("Ok", "ObjectWire.Main.Resources.LogonUserDialog", Assembly.GetExecutingAssembly()).ToString();
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex);
			}
		}

		/// <summary>
		/// The ID of the selected company.
		/// </summary>
		public int SelectedCompanyID
		{
			get
			{
				return selectedCompanyID;
			}
		}
	}
}