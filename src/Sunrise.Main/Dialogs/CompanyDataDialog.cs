/*

	   file: CompanyDataDialog.cs
description:
     author:


*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;
using voidsoft.Sunrise.DataSystem;

namespace voidsoft.Sunrise.Main.Dialogs
{
	/// <summary>
	/// 
	/// </summary>
	public class CompanyDataDialog : Form
	{
		private GroupBox groupBox;
		private Label labelName;
		private TextBox textBoxName;
		private Label labelAddress;
		private Button buttonOK;
		private Button buttonCancel;
		private Label label1;
		private TextBox textLogoPath;
		private Button buttonBrowse;
		private TextBox textBoxAddress;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private PictureBox pictureBoxBackground;
		private PictureBox pictureBoxPicture;
		private Label labelDetails;

		/// <summary>
		/// flag to know if the user changed data
		/// </summary>
		private bool isDirty;

		/// <summary>
		/// the company old name
		/// </summary>
		private string oldName;

		public CompanyDataDialog()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (CompanyDataDialog));
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textLogoPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.labelAddress = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
			this.pictureBoxPicture = new System.Windows.Forms.PictureBox();
			this.labelDetails = new System.Windows.Forms.Label();
			this.groupBox.SuspendLayout();
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
			// groupBox
			// 
			this.groupBox.AccessibleDescription = resources.GetString("groupBox.AccessibleDescription");
			this.groupBox.AccessibleName = resources.GetString("groupBox.AccessibleName");
			this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("groupBox.Anchor")));
			this.groupBox.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("groupBox.BackgroundImage")));
			this.groupBox.Controls.Add(this.buttonBrowse);
			this.groupBox.Controls.Add(this.textLogoPath);
			this.groupBox.Controls.Add(this.label1);
			this.groupBox.Controls.Add(this.textBoxAddress);
			this.groupBox.Controls.Add(this.labelAddress);
			this.groupBox.Controls.Add(this.textBoxName);
			this.groupBox.Controls.Add(this.labelName);
			this.groupBox.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("groupBox.Dock")));
			this.groupBox.Enabled = ((bool) (resources.GetObject("groupBox.Enabled")));
			this.groupBox.Font = ((System.Drawing.Font) (resources.GetObject("groupBox.Font")));
			this.groupBox.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("groupBox.ImeMode")));
			this.groupBox.Location = ((System.Drawing.Point) (resources.GetObject("groupBox.Location")));
			this.groupBox.Name = "groupBox";
			this.groupBox.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("groupBox.RightToLeft")));
			this.groupBox.Size = ((System.Drawing.Size) (resources.GetObject("groupBox.Size")));
			this.groupBox.TabIndex = ((int) (resources.GetObject("groupBox.TabIndex")));
			this.groupBox.TabStop = false;
			this.groupBox.Text = resources.GetString("groupBox.Text");
			this.groupBox.Visible = ((bool) (resources.GetObject("groupBox.Visible")));
			this.groupBox.Enter += new System.EventHandler(this.groupBox_Enter);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.AccessibleDescription = resources.GetString("buttonBrowse.AccessibleDescription");
			this.buttonBrowse.AccessibleName = resources.GetString("buttonBrowse.AccessibleName");
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("buttonBrowse.Anchor")));
			this.buttonBrowse.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonBrowse.BackgroundImage")));
			this.buttonBrowse.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("buttonBrowse.Dock")));
			this.buttonBrowse.Enabled = ((bool) (resources.GetObject("buttonBrowse.Enabled")));
			this.buttonBrowse.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("buttonBrowse.FlatStyle")));
			this.buttonBrowse.Font = ((System.Drawing.Font) (resources.GetObject("buttonBrowse.Font")));
			this.buttonBrowse.Image = ((System.Drawing.Image) (resources.GetObject("buttonBrowse.Image")));
			this.buttonBrowse.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonBrowse.ImageAlign")));
			this.buttonBrowse.ImageIndex = ((int) (resources.GetObject("buttonBrowse.ImageIndex")));
			this.buttonBrowse.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("buttonBrowse.ImeMode")));
			this.buttonBrowse.Location = ((System.Drawing.Point) (resources.GetObject("buttonBrowse.Location")));
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("buttonBrowse.RightToLeft")));
			this.buttonBrowse.Size = ((System.Drawing.Size) (resources.GetObject("buttonBrowse.Size")));
			this.buttonBrowse.TabIndex = ((int) (resources.GetObject("buttonBrowse.TabIndex")));
			this.buttonBrowse.Text = resources.GetString("buttonBrowse.Text");
			this.buttonBrowse.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonBrowse.TextAlign")));
			this.buttonBrowse.Visible = ((bool) (resources.GetObject("buttonBrowse.Visible")));
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// textLogoPath
			// 
			this.textLogoPath.AccessibleDescription = resources.GetString("textLogoPath.AccessibleDescription");
			this.textLogoPath.AccessibleName = resources.GetString("textLogoPath.AccessibleName");
			this.textLogoPath.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("textLogoPath.Anchor")));
			this.textLogoPath.AutoSize = ((bool) (resources.GetObject("textLogoPath.AutoSize")));
			this.textLogoPath.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("textLogoPath.BackgroundImage")));
			this.textLogoPath.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("textLogoPath.Dock")));
			this.textLogoPath.Enabled = ((bool) (resources.GetObject("textLogoPath.Enabled")));
			this.textLogoPath.Font = ((System.Drawing.Font) (resources.GetObject("textLogoPath.Font")));
			this.textLogoPath.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("textLogoPath.ImeMode")));
			this.textLogoPath.Location = ((System.Drawing.Point) (resources.GetObject("textLogoPath.Location")));
			this.textLogoPath.MaxLength = ((int) (resources.GetObject("textLogoPath.MaxLength")));
			this.textLogoPath.Multiline = ((bool) (resources.GetObject("textLogoPath.Multiline")));
			this.textLogoPath.Name = "textLogoPath";
			this.textLogoPath.PasswordChar = ((char) (resources.GetObject("textLogoPath.PasswordChar")));
			this.textLogoPath.ReadOnly = true;
			this.textLogoPath.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("textLogoPath.RightToLeft")));
			this.textLogoPath.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject("textLogoPath.ScrollBars")));
			this.textLogoPath.Size = ((System.Drawing.Size) (resources.GetObject("textLogoPath.Size")));
			this.textLogoPath.TabIndex = ((int) (resources.GetObject("textLogoPath.TabIndex")));
			this.textLogoPath.Text = resources.GetString("textLogoPath.Text");
			this.textLogoPath.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject("textLogoPath.TextAlign")));
			this.textLogoPath.Visible = ((bool) (resources.GetObject("textLogoPath.Visible")));
			this.textLogoPath.WordWrap = ((bool) (resources.GetObject("textLogoPath.WordWrap")));
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
			// textBoxAddress
			// 
			this.textBoxAddress.AccessibleDescription = resources.GetString("textBoxAddress.AccessibleDescription");
			this.textBoxAddress.AccessibleName = resources.GetString("textBoxAddress.AccessibleName");
			this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("textBoxAddress.Anchor")));
			this.textBoxAddress.AutoSize = ((bool) (resources.GetObject("textBoxAddress.AutoSize")));
			this.textBoxAddress.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("textBoxAddress.BackgroundImage")));
			this.textBoxAddress.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("textBoxAddress.Dock")));
			this.textBoxAddress.Enabled = ((bool) (resources.GetObject("textBoxAddress.Enabled")));
			this.textBoxAddress.Font = ((System.Drawing.Font) (resources.GetObject("textBoxAddress.Font")));
			this.textBoxAddress.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("textBoxAddress.ImeMode")));
			this.textBoxAddress.Location = ((System.Drawing.Point) (resources.GetObject("textBoxAddress.Location")));
			this.textBoxAddress.MaxLength = ((int) (resources.GetObject("textBoxAddress.MaxLength")));
			this.textBoxAddress.Multiline = ((bool) (resources.GetObject("textBoxAddress.Multiline")));
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.PasswordChar = ((char) (resources.GetObject("textBoxAddress.PasswordChar")));
			this.textBoxAddress.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("textBoxAddress.RightToLeft")));
			this.textBoxAddress.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject("textBoxAddress.ScrollBars")));
			this.textBoxAddress.Size = ((System.Drawing.Size) (resources.GetObject("textBoxAddress.Size")));
			this.textBoxAddress.TabIndex = ((int) (resources.GetObject("textBoxAddress.TabIndex")));
			this.textBoxAddress.Text = resources.GetString("textBoxAddress.Text");
			this.textBoxAddress.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject("textBoxAddress.TextAlign")));
			this.textBoxAddress.Visible = ((bool) (resources.GetObject("textBoxAddress.Visible")));
			this.textBoxAddress.WordWrap = ((bool) (resources.GetObject("textBoxAddress.WordWrap")));
			this.textBoxAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxAddress_KeyUp);
			// 
			// labelAddress
			// 
			this.labelAddress.AccessibleDescription = resources.GetString("labelAddress.AccessibleDescription");
			this.labelAddress.AccessibleName = resources.GetString("labelAddress.AccessibleName");
			this.labelAddress.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelAddress.Anchor")));
			this.labelAddress.AutoSize = ((bool) (resources.GetObject("labelAddress.AutoSize")));
			this.labelAddress.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelAddress.Dock")));
			this.labelAddress.Enabled = ((bool) (resources.GetObject("labelAddress.Enabled")));
			this.labelAddress.Font = ((System.Drawing.Font) (resources.GetObject("labelAddress.Font")));
			this.labelAddress.Image = ((System.Drawing.Image) (resources.GetObject("labelAddress.Image")));
			this.labelAddress.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelAddress.ImageAlign")));
			this.labelAddress.ImageIndex = ((int) (resources.GetObject("labelAddress.ImageIndex")));
			this.labelAddress.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelAddress.ImeMode")));
			this.labelAddress.Location = ((System.Drawing.Point) (resources.GetObject("labelAddress.Location")));
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelAddress.RightToLeft")));
			this.labelAddress.Size = ((System.Drawing.Size) (resources.GetObject("labelAddress.Size")));
			this.labelAddress.TabIndex = ((int) (resources.GetObject("labelAddress.TabIndex")));
			this.labelAddress.Text = resources.GetString("labelAddress.Text");
			this.labelAddress.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelAddress.TextAlign")));
			this.labelAddress.Visible = ((bool) (resources.GetObject("labelAddress.Visible")));
			// 
			// textBoxName
			// 
			this.textBoxName.AccessibleDescription = resources.GetString("textBoxName.AccessibleDescription");
			this.textBoxName.AccessibleName = resources.GetString("textBoxName.AccessibleName");
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("textBoxName.Anchor")));
			this.textBoxName.AutoSize = ((bool) (resources.GetObject("textBoxName.AutoSize")));
			this.textBoxName.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("textBoxName.BackgroundImage")));
			this.textBoxName.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("textBoxName.Dock")));
			this.textBoxName.Enabled = ((bool) (resources.GetObject("textBoxName.Enabled")));
			this.textBoxName.Font = ((System.Drawing.Font) (resources.GetObject("textBoxName.Font")));
			this.textBoxName.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("textBoxName.ImeMode")));
			this.textBoxName.Location = ((System.Drawing.Point) (resources.GetObject("textBoxName.Location")));
			this.textBoxName.MaxLength = ((int) (resources.GetObject("textBoxName.MaxLength")));
			this.textBoxName.Multiline = ((bool) (resources.GetObject("textBoxName.Multiline")));
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.PasswordChar = ((char) (resources.GetObject("textBoxName.PasswordChar")));
			this.textBoxName.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("textBoxName.RightToLeft")));
			this.textBoxName.ScrollBars = ((System.Windows.Forms.ScrollBars) (resources.GetObject("textBoxName.ScrollBars")));
			this.textBoxName.Size = ((System.Drawing.Size) (resources.GetObject("textBoxName.Size")));
			this.textBoxName.TabIndex = ((int) (resources.GetObject("textBoxName.TabIndex")));
			this.textBoxName.Text = resources.GetString("textBoxName.Text");
			this.textBoxName.TextAlign = ((System.Windows.Forms.HorizontalAlignment) (resources.GetObject("textBoxName.TextAlign")));
			this.textBoxName.Visible = ((bool) (resources.GetObject("textBoxName.Visible")));
			this.textBoxName.WordWrap = ((bool) (resources.GetObject("textBoxName.WordWrap")));
			this.textBoxName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyUp);
			// 
			// labelName
			// 
			this.labelName.AccessibleDescription = resources.GetString("labelName.AccessibleDescription");
			this.labelName.AccessibleName = resources.GetString("labelName.AccessibleName");
			this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelName.Anchor")));
			this.labelName.AutoSize = ((bool) (resources.GetObject("labelName.AutoSize")));
			this.labelName.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelName.Dock")));
			this.labelName.Enabled = ((bool) (resources.GetObject("labelName.Enabled")));
			this.labelName.Font = ((System.Drawing.Font) (resources.GetObject("labelName.Font")));
			this.labelName.Image = ((System.Drawing.Image) (resources.GetObject("labelName.Image")));
			this.labelName.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelName.ImageAlign")));
			this.labelName.ImageIndex = ((int) (resources.GetObject("labelName.ImageIndex")));
			this.labelName.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelName.ImeMode")));
			this.labelName.Location = ((System.Drawing.Point) (resources.GetObject("labelName.Location")));
			this.labelName.Name = "labelName";
			this.labelName.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelName.RightToLeft")));
			this.labelName.Size = ((System.Drawing.Size) (resources.GetObject("labelName.Size")));
			this.labelName.TabIndex = ((int) (resources.GetObject("labelName.TabIndex")));
			this.labelName.Text = resources.GetString("labelName.Text");
			this.labelName.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelName.TextAlign")));
			this.labelName.Visible = ((bool) (resources.GetObject("labelName.Visible")));
			// 
			// pictureBoxBackground
			// 
			this.pictureBoxBackground.AccessibleDescription = resources.GetString("pictureBoxBackground.AccessibleDescription");
			this.pictureBoxBackground.AccessibleName = resources.GetString("pictureBoxBackground.AccessibleName");
			this.pictureBoxBackground.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBoxBackground.Anchor")));
			this.pictureBoxBackground.BackColor = System.Drawing.Color.White;
			this.pictureBoxBackground.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBoxBackground.BackgroundImage")));
			this.pictureBoxBackground.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBoxBackground.Dock")));
			this.pictureBoxBackground.Enabled = ((bool) (resources.GetObject("pictureBoxBackground.Enabled")));
			this.pictureBoxBackground.Font = ((System.Drawing.Font) (resources.GetObject("pictureBoxBackground.Font")));
			this.pictureBoxBackground.Image = ((System.Drawing.Image) (resources.GetObject("pictureBoxBackground.Image")));
			this.pictureBoxBackground.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBoxBackground.ImeMode")));
			this.pictureBoxBackground.Location = ((System.Drawing.Point) (resources.GetObject("pictureBoxBackground.Location")));
			this.pictureBoxBackground.Name = "pictureBoxBackground";
			this.pictureBoxBackground.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBoxBackground.RightToLeft")));
			this.pictureBoxBackground.Size = ((System.Drawing.Size) (resources.GetObject("pictureBoxBackground.Size")));
			this.pictureBoxBackground.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBoxBackground.SizeMode")));
			this.pictureBoxBackground.TabIndex = ((int) (resources.GetObject("pictureBoxBackground.TabIndex")));
			this.pictureBoxBackground.TabStop = false;
			this.pictureBoxBackground.Text = resources.GetString("pictureBoxBackground.Text");
			this.pictureBoxBackground.Visible = ((bool) (resources.GetObject("pictureBoxBackground.Visible")));
			// 
			// pictureBoxPicture
			// 
			this.pictureBoxPicture.AccessibleDescription = resources.GetString("pictureBoxPicture.AccessibleDescription");
			this.pictureBoxPicture.AccessibleName = resources.GetString("pictureBoxPicture.AccessibleName");
			this.pictureBoxPicture.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBoxPicture.Anchor")));
			this.pictureBoxPicture.BackColor = System.Drawing.Color.White;
			this.pictureBoxPicture.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBoxPicture.BackgroundImage")));
			this.pictureBoxPicture.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBoxPicture.Dock")));
			this.pictureBoxPicture.Enabled = ((bool) (resources.GetObject("pictureBoxPicture.Enabled")));
			this.pictureBoxPicture.Font = ((System.Drawing.Font) (resources.GetObject("pictureBoxPicture.Font")));
			this.pictureBoxPicture.Image = ((System.Drawing.Image) (resources.GetObject("pictureBoxPicture.Image")));
			this.pictureBoxPicture.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBoxPicture.ImeMode")));
			this.pictureBoxPicture.Location = ((System.Drawing.Point) (resources.GetObject("pictureBoxPicture.Location")));
			this.pictureBoxPicture.Name = "pictureBoxPicture";
			this.pictureBoxPicture.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBoxPicture.RightToLeft")));
			this.pictureBoxPicture.Size = ((System.Drawing.Size) (resources.GetObject("pictureBoxPicture.Size")));
			this.pictureBoxPicture.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBoxPicture.SizeMode")));
			this.pictureBoxPicture.TabIndex = ((int) (resources.GetObject("pictureBoxPicture.TabIndex")));
			this.pictureBoxPicture.TabStop = false;
			this.pictureBoxPicture.Text = resources.GetString("pictureBoxPicture.Text");
			this.pictureBoxPicture.Visible = ((bool) (resources.GetObject("pictureBoxPicture.Visible")));
			// 
			// labelDetails
			// 
			this.labelDetails.AccessibleDescription = resources.GetString("labelDetails.AccessibleDescription");
			this.labelDetails.AccessibleName = resources.GetString("labelDetails.AccessibleName");
			this.labelDetails.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelDetails.Anchor")));
			this.labelDetails.AutoSize = ((bool) (resources.GetObject("labelDetails.AutoSize")));
			this.labelDetails.BackColor = System.Drawing.Color.White;
			this.labelDetails.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("labelDetails.Dock")));
			this.labelDetails.Enabled = ((bool) (resources.GetObject("labelDetails.Enabled")));
			this.labelDetails.Font = ((System.Drawing.Font) (resources.GetObject("labelDetails.Font")));
			this.labelDetails.Image = ((System.Drawing.Image) (resources.GetObject("labelDetails.Image")));
			this.labelDetails.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelDetails.ImageAlign")));
			this.labelDetails.ImageIndex = ((int) (resources.GetObject("labelDetails.ImageIndex")));
			this.labelDetails.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("labelDetails.ImeMode")));
			this.labelDetails.Location = ((System.Drawing.Point) (resources.GetObject("labelDetails.Location")));
			this.labelDetails.Name = "labelDetails";
			this.labelDetails.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("labelDetails.RightToLeft")));
			this.labelDetails.Size = ((System.Drawing.Size) (resources.GetObject("labelDetails.Size")));
			this.labelDetails.TabIndex = ((int) (resources.GetObject("labelDetails.TabIndex")));
			this.labelDetails.Text = resources.GetString("labelDetails.Text");
			this.labelDetails.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("labelDetails.TextAlign")));
			this.labelDetails.Visible = ((bool) (resources.GetObject("labelDetails.Visible")));
			// 
			// CompanyDataDialog
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool) (resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size) (resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.labelDetails);
			this.Controls.Add(this.pictureBoxPicture);
			this.Controls.Add(this.pictureBoxBackground);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Enabled = ((bool) (resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font) (resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point) (resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size) (resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size) (resources.GetObject("$this.MinimumSize")));
			this.Name = "CompanyDataDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition) (resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.CompanyDataDialog_Load);
			this.groupBox.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofDialog = null;

			try
			{
				ofDialog = new OpenFileDialog();
				ofDialog.Multiselect = false;
				ofDialog.Filter = "Pictures |*.jpg";
				ofDialog.RestoreDirectory = true;
				if (ofDialog.ShowDialog() == DialogResult.OK)
				{
					textLogoPath.Text = ofDialog.FileName;
					isDirty = true;
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex.Message + " " + ex.StackTrace);
			}
			finally
			{
				if (ofDialog != null)
				{
					ofDialog.Dispose();
				}
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			//check if the user made changes
			if (isDirty)
			{
				//validate data and save changes
				if (ValidateUserInput())
				{
					try
					{
						CompanyTableMetadata company = new CompanyTableMetadata();
						company.Id = SharedData.CompanyId;
						company.Name = textBoxName.Text.Trim();
						company.Address = textBoxAddress.Text.Trim();
						company.Logo = textLogoPath.Text;

						CompanyServices.UpdateCompanyData(company);
					}
					catch (Exception ex)
					{
						Log.LogError(ex.Message + " " + ex.StackTrace);
						MessageBox.Show("Failed to update data");
					}

					//set the new values
					SharedData.CompanyAddress = textBoxAddress.Text.Trim();
					SharedData.CompanyName = textBoxName.Text.Trim();
					SharedData.CompanyLogoPath = textLogoPath.Text.Trim();
				}
			}
			Close();
		}

		private void CompanyDataDialog_Load(object sender, EventArgs e)
		{
			//set data
			try
			{
				textBoxName.Text = SharedData.CompanyName;
				textBoxAddress.Text = SharedData.CompanyAddress;
				textLogoPath.Text = SharedData.CompanyLogoPath;

				//hold the old name
				oldName = textBoxName.Text;
			}
			catch (Exception ex)
			{
			}
		}

		/// <summary>
		/// Valides the user's input
		/// </summary>
		/// <returns></returns>
		private bool ValidateUserInput()
		{
			if (textBoxName.Text.Trim() == "")
			{
				MessageBox.Show("Please enter the name");
				return false;
			}

			//check if the user changed the name
			if (oldName != textBoxName.Text.Trim())
			{
				if (CompanyServices.IsCompanyName(textBoxName.Text.Trim()))
				{
					MessageBox.Show("The name already exists. Please choose another one");
					return false;
				}
			}

			return true;
		}

		private void textBoxName_KeyUp(object sender, KeyEventArgs e)
		{
			isDirty = true;
		}

		private void textBoxAddress_KeyUp(object sender, KeyEventArgs e)
		{
			isDirty = true;
		}

		private void groupBox_Enter(object sender, EventArgs e)
		{
		}
	}
}