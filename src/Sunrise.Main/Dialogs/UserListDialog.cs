/*

	   file: UserListDialog.cs
description: dialog which displays a list with the users.
     author: Gheorghe MARius.

*/

using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;
using voidsoft.Sunrise.DataSystem;

namespace voidsoft.Sunrise.Main.Dialogs
{
	/// <summary>
	/// Dialog which lists all the users.
	/// </summary>
	public class UserListDialog : Form
	{
		private ListBox listBoxUsers;
		private Button buttonView;
		private Button buttonDelete;
		private Button buttonAdd;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private UsersTableMetadata[] users;
		private PictureBox pictureBoxContainer;
		private Label labelUsers;
		private PictureBox pictureBoxLogo;
		private UsersPersistentObject userPersistent;

		public UserListDialog()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (UserListDialog));
			this.pictureBoxContainer = new System.Windows.Forms.PictureBox();
			this.listBoxUsers = new System.Windows.Forms.ListBox();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonView = new System.Windows.Forms.Button();
			this.labelUsers = new System.Windows.Forms.Label();
			this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBoxContainer
			// 
			this.pictureBoxContainer.AccessibleDescription = resources.GetString("pictureBoxContainer.AccessibleDescription");
			this.pictureBoxContainer.AccessibleName = resources.GetString("pictureBoxContainer.AccessibleName");
			this.pictureBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBoxContainer.Anchor")));
			this.pictureBoxContainer.BackColor = System.Drawing.Color.White;
			this.pictureBoxContainer.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBoxContainer.BackgroundImage")));
			this.pictureBoxContainer.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBoxContainer.Dock")));
			this.pictureBoxContainer.Enabled = ((bool) (resources.GetObject("pictureBoxContainer.Enabled")));
			this.pictureBoxContainer.Font = ((System.Drawing.Font) (resources.GetObject("pictureBoxContainer.Font")));
			this.pictureBoxContainer.Image = ((System.Drawing.Image) (resources.GetObject("pictureBoxContainer.Image")));
			this.pictureBoxContainer.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBoxContainer.ImeMode")));
			this.pictureBoxContainer.Location = ((System.Drawing.Point) (resources.GetObject("pictureBoxContainer.Location")));
			this.pictureBoxContainer.Name = "pictureBoxContainer";
			this.pictureBoxContainer.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBoxContainer.RightToLeft")));
			this.pictureBoxContainer.Size = ((System.Drawing.Size) (resources.GetObject("pictureBoxContainer.Size")));
			this.pictureBoxContainer.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBoxContainer.SizeMode")));
			this.pictureBoxContainer.TabIndex = ((int) (resources.GetObject("pictureBoxContainer.TabIndex")));
			this.pictureBoxContainer.TabStop = false;
			this.pictureBoxContainer.Text = resources.GetString("pictureBoxContainer.Text");
			this.pictureBoxContainer.Visible = ((bool) (resources.GetObject("pictureBoxContainer.Visible")));
			// 
			// listBoxUsers
			// 
			this.listBoxUsers.AccessibleDescription = resources.GetString("listBoxUsers.AccessibleDescription");
			this.listBoxUsers.AccessibleName = resources.GetString("listBoxUsers.AccessibleName");
			this.listBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("listBoxUsers.Anchor")));
			this.listBoxUsers.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("listBoxUsers.BackgroundImage")));
			this.listBoxUsers.ColumnWidth = ((int) (resources.GetObject("listBoxUsers.ColumnWidth")));
			this.listBoxUsers.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("listBoxUsers.Dock")));
			this.listBoxUsers.Enabled = ((bool) (resources.GetObject("listBoxUsers.Enabled")));
			this.listBoxUsers.Font = ((System.Drawing.Font) (resources.GetObject("listBoxUsers.Font")));
			this.listBoxUsers.HorizontalExtent = ((int) (resources.GetObject("listBoxUsers.HorizontalExtent")));
			this.listBoxUsers.HorizontalScrollbar = ((bool) (resources.GetObject("listBoxUsers.HorizontalScrollbar")));
			this.listBoxUsers.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("listBoxUsers.ImeMode")));
			this.listBoxUsers.IntegralHeight = ((bool) (resources.GetObject("listBoxUsers.IntegralHeight")));
			this.listBoxUsers.ItemHeight = ((int) (resources.GetObject("listBoxUsers.ItemHeight")));
			this.listBoxUsers.Location = ((System.Drawing.Point) (resources.GetObject("listBoxUsers.Location")));
			this.listBoxUsers.Name = "listBoxUsers";
			this.listBoxUsers.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("listBoxUsers.RightToLeft")));
			this.listBoxUsers.ScrollAlwaysVisible = ((bool) (resources.GetObject("listBoxUsers.ScrollAlwaysVisible")));
			this.listBoxUsers.Size = ((System.Drawing.Size) (resources.GetObject("listBoxUsers.Size")));
			this.listBoxUsers.TabIndex = ((int) (resources.GetObject("listBoxUsers.TabIndex")));
			this.listBoxUsers.Visible = ((bool) (resources.GetObject("listBoxUsers.Visible")));
			this.listBoxUsers.DoubleClick += new System.EventHandler(this.listBoxUsers_DoubleClick);
			this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
			// 
			// buttonDelete
			// 
			this.buttonDelete.AccessibleDescription = resources.GetString("buttonDelete.AccessibleDescription");
			this.buttonDelete.AccessibleName = resources.GetString("buttonDelete.AccessibleName");
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("buttonDelete.Anchor")));
			this.buttonDelete.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonDelete.BackgroundImage")));
			this.buttonDelete.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("buttonDelete.Dock")));
			this.buttonDelete.Enabled = ((bool) (resources.GetObject("buttonDelete.Enabled")));
			this.buttonDelete.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("buttonDelete.FlatStyle")));
			this.buttonDelete.Font = ((System.Drawing.Font) (resources.GetObject("buttonDelete.Font")));
			this.buttonDelete.Image = ((System.Drawing.Image) (resources.GetObject("buttonDelete.Image")));
			this.buttonDelete.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonDelete.ImageAlign")));
			this.buttonDelete.ImageIndex = ((int) (resources.GetObject("buttonDelete.ImageIndex")));
			this.buttonDelete.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("buttonDelete.ImeMode")));
			this.buttonDelete.Location = ((System.Drawing.Point) (resources.GetObject("buttonDelete.Location")));
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("buttonDelete.RightToLeft")));
			this.buttonDelete.Size = ((System.Drawing.Size) (resources.GetObject("buttonDelete.Size")));
			this.buttonDelete.TabIndex = ((int) (resources.GetObject("buttonDelete.TabIndex")));
			this.buttonDelete.Text = resources.GetString("buttonDelete.Text");
			this.buttonDelete.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonDelete.TextAlign")));
			this.buttonDelete.Visible = ((bool) (resources.GetObject("buttonDelete.Visible")));
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonView
			// 
			this.buttonView.AccessibleDescription = resources.GetString("buttonView.AccessibleDescription");
			this.buttonView.AccessibleName = resources.GetString("buttonView.AccessibleName");
			this.buttonView.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("buttonView.Anchor")));
			this.buttonView.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonView.BackgroundImage")));
			this.buttonView.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("buttonView.Dock")));
			this.buttonView.Enabled = ((bool) (resources.GetObject("buttonView.Enabled")));
			this.buttonView.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("buttonView.FlatStyle")));
			this.buttonView.Font = ((System.Drawing.Font) (resources.GetObject("buttonView.Font")));
			this.buttonView.Image = ((System.Drawing.Image) (resources.GetObject("buttonView.Image")));
			this.buttonView.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonView.ImageAlign")));
			this.buttonView.ImageIndex = ((int) (resources.GetObject("buttonView.ImageIndex")));
			this.buttonView.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("buttonView.ImeMode")));
			this.buttonView.Location = ((System.Drawing.Point) (resources.GetObject("buttonView.Location")));
			this.buttonView.Name = "buttonView";
			this.buttonView.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("buttonView.RightToLeft")));
			this.buttonView.Size = ((System.Drawing.Size) (resources.GetObject("buttonView.Size")));
			this.buttonView.TabIndex = ((int) (resources.GetObject("buttonView.TabIndex")));
			this.buttonView.Text = resources.GetString("buttonView.Text");
			this.buttonView.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonView.TextAlign")));
			this.buttonView.Visible = ((bool) (resources.GetObject("buttonView.Visible")));
			this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
			// 
			// labelUsers
			// 
			this.labelUsers.AccessibleDescription = resources.GetString("labelUsers.AccessibleDescription");
			this.labelUsers.AccessibleName = resources.GetString("labelUsers.AccessibleName");
			this.labelUsers.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("labelUsers.Anchor")));
			this.labelUsers.AutoSize = ((bool) (resources.GetObject("labelUsers.AutoSize")));
			this.labelUsers.BackColor = System.Drawing.Color.White;
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
			// pictureBoxLogo
			// 
			this.pictureBoxLogo.AccessibleDescription = resources.GetString("pictureBoxLogo.AccessibleDescription");
			this.pictureBoxLogo.AccessibleName = resources.GetString("pictureBoxLogo.AccessibleName");
			this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("pictureBoxLogo.Anchor")));
			this.pictureBoxLogo.BackColor = System.Drawing.Color.White;
			this.pictureBoxLogo.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("pictureBoxLogo.BackgroundImage")));
			this.pictureBoxLogo.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("pictureBoxLogo.Dock")));
			this.pictureBoxLogo.Enabled = ((bool) (resources.GetObject("pictureBoxLogo.Enabled")));
			this.pictureBoxLogo.Font = ((System.Drawing.Font) (resources.GetObject("pictureBoxLogo.Font")));
			this.pictureBoxLogo.Image = ((System.Drawing.Image) (resources.GetObject("pictureBoxLogo.Image")));
			this.pictureBoxLogo.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("pictureBoxLogo.ImeMode")));
			this.pictureBoxLogo.Location = ((System.Drawing.Point) (resources.GetObject("pictureBoxLogo.Location")));
			this.pictureBoxLogo.Name = "pictureBoxLogo";
			this.pictureBoxLogo.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("pictureBoxLogo.RightToLeft")));
			this.pictureBoxLogo.Size = ((System.Drawing.Size) (resources.GetObject("pictureBoxLogo.Size")));
			this.pictureBoxLogo.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode) (resources.GetObject("pictureBoxLogo.SizeMode")));
			this.pictureBoxLogo.TabIndex = ((int) (resources.GetObject("pictureBoxLogo.TabIndex")));
			this.pictureBoxLogo.TabStop = false;
			this.pictureBoxLogo.Text = resources.GetString("pictureBoxLogo.Text");
			this.pictureBoxLogo.Visible = ((bool) (resources.GetObject("pictureBoxLogo.Visible")));
			// 
			// buttonAdd
			// 
			this.buttonAdd.AccessibleDescription = resources.GetString("buttonAdd.AccessibleDescription");
			this.buttonAdd.AccessibleName = resources.GetString("buttonAdd.AccessibleName");
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles) (resources.GetObject("buttonAdd.Anchor")));
			this.buttonAdd.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonAdd.BackgroundImage")));
			this.buttonAdd.Dock = ((System.Windows.Forms.DockStyle) (resources.GetObject("buttonAdd.Dock")));
			this.buttonAdd.Enabled = ((bool) (resources.GetObject("buttonAdd.Enabled")));
			this.buttonAdd.FlatStyle = ((System.Windows.Forms.FlatStyle) (resources.GetObject("buttonAdd.FlatStyle")));
			this.buttonAdd.Font = ((System.Drawing.Font) (resources.GetObject("buttonAdd.Font")));
			this.buttonAdd.Image = ((System.Drawing.Image) (resources.GetObject("buttonAdd.Image")));
			this.buttonAdd.ImageAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonAdd.ImageAlign")));
			this.buttonAdd.ImageIndex = ((int) (resources.GetObject("buttonAdd.ImageIndex")));
			this.buttonAdd.ImeMode = ((System.Windows.Forms.ImeMode) (resources.GetObject("buttonAdd.ImeMode")));
			this.buttonAdd.Location = ((System.Drawing.Point) (resources.GetObject("buttonAdd.Location")));
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("buttonAdd.RightToLeft")));
			this.buttonAdd.Size = ((System.Drawing.Size) (resources.GetObject("buttonAdd.Size")));
			this.buttonAdd.TabIndex = ((int) (resources.GetObject("buttonAdd.TabIndex")));
			this.buttonAdd.Text = resources.GetString("buttonAdd.Text");
			this.buttonAdd.TextAlign = ((System.Drawing.ContentAlignment) (resources.GetObject("buttonAdd.TextAlign")));
			this.buttonAdd.Visible = ((bool) (resources.GetObject("buttonAdd.Visible")));
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// UserListDialog
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool) (resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size) (resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size) (resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.pictureBoxLogo);
			this.Controls.Add(this.labelUsers);
			this.Controls.Add(this.buttonView);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.listBoxUsers);
			this.Controls.Add(this.pictureBoxContainer);
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
			this.Name = "UserListDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft) (resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition) (resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.UserListDialog_Load);
			this.ResumeLayout(false);
		}

		private void UserListDialog_Load(object sender, EventArgs e)
		{
			LoadUserList();
		}

		private void buttonView_Click(object sender, EventArgs e)
		{
			UserRightsDialog usDialog = null;

			try
			{
				if (listBoxUsers.SelectedIndex > -1)
				{
					usDialog = new UserRightsDialog(users[listBoxUsers.SelectedIndex]);
					usDialog.ShowDialog();
					LoadUserList();
				}
			}
			catch (Exception ex)
			{
			}
			finally
			{
				if (usDialog != null)
				{
					usDialog.Dispose();
				}
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			try
			{
				int index = listBoxUsers.SelectedIndex;

				if (index > 0)
				{
					//ask the user
					if (MessageBox.Show("Doriti sa stergeti utilizatorul selectat ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						UsersTableMetadata currentUser = users[index];
						userPersistent.Delete(currentUser, false);

						LoadUserList();
					}
				}
			}
			catch (InvalidOperationException ioex)
			{
			}
			catch (ApplicationException aex)
			{
				MessageBox.Show(aex.Message);
			}
			catch (Exception ex)
			{
				MessageBox.Show("A intervenit o eroare");
			}
			finally
			{
			}
		}

		private void listBoxUsers_DoubleClick(object sender, EventArgs e)
		{
			if (listBoxUsers.SelectedIndex > -1)
			{
				buttonView_Click(null, null);
			}
		}

		private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			UserRightsDialog usDialog = null;

			try
			{
				usDialog = new UserRightsDialog();
				usDialog.ShowDialog();
				LoadUserList();
			}
			catch (Exception ex)
			{
			}
			finally
			{
				if (usDialog != null)
				{
					usDialog.Dispose();
				}
			}
		}

		private void LoadUserList()
		{
			listBoxUsers.Items.Clear();

			try
			{
				UsersTableMetadata user = new UsersTableMetadata();
				userPersistent = new UsersPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, user);

				users = (UsersTableMetadata[]) userPersistent.GetTableMetadata();

				for (int i = 0; i < users.Length; i++)
				{
					listBoxUsers.Items.Add(users[i].Name);
				}
			}
			catch (Exception ex)
			{
				Log.LogError("LoadUserList " + ex.Message);
			}
			finally
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void LocalizeUserInterface()
		{
			try
			{
				if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() != "en")
				{
					labelUsers.Text = Localization.GetCultureInfoResource("Users", "ObjectWire.Main.Resources.UserListDialog", Assembly.GetExecutingAssembly()).ToString();

					buttonAdd.Text = Localization.GetCultureInfoResource("Add", "ObjectWire.Main.Resources.UserListDialog", Assembly.GetExecutingAssembly()).ToString();
					buttonDelete.Text = Localization.GetCultureInfoResource("Delete", "ObjectWire.Main.Resources.UserListDialog", Assembly.GetExecutingAssembly()).ToString();
					buttonView.Text = Localization.GetCultureInfoResource("View", "ObjectWire.Main.Resources.UserListDialog", Assembly.GetExecutingAssembly()).ToString();
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex);
			}
		}
	}
}