using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// 
	/// </summary>
	public class BusinessItemDisplayForm : Form
	{
		protected GroupBox groupBox;
		protected Button buttonOk;
		protected Button buttonCancel;

		protected ActionStatus action;
		protected Button buttonPrint;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public BusinessItemDisplayForm(ActionStatus action)
		{
			InitializeComponent();

			this.action = action;
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox.Location = new System.Drawing.Point(8, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(534, 358);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.Location = new System.Drawing.Point(374, 365);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(80, 24);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "&OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(462, 365);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 24);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonPrint
			// 
			this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPrint.Location = new System.Drawing.Point(8, 365);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(80, 24);
			this.buttonPrint.TabIndex = 3;
			this.buttonPrint.Text = "&Print";
			this.buttonPrint.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// BusinessItemDisplayForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 401);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.groupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "BusinessItemDisplayForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.BusinessItemDisplayForm_Load);
			this.ResumeLayout(false);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (action == ActionStatus.Navigate)
			{
				Close();
			}
			else if (action == ActionStatus.Add)
			{
				if (ValidateData())
				{
					InsertData();
				}
			}
			else if (action == ActionStatus.Edit)
			{
				if (ValidateData())
				{
					UpdateData();
				}
			}
		}

		private void BusinessItemDisplayForm_Load(object sender, EventArgs e)
		{
			if (action == ActionStatus.Navigate) // || this.action == ItemAction.Update)
			{
				EnableControls(false);
				DisplayData();
			}
			else if (action == ActionStatus.Edit)
			{
				EnableControls(true);
				DisplayData();
			}
			else if (action == ActionStatus.Add)
			{
				EnableControls(false);
			}
		}

		/// <summary>
		/// Enables the controls.
		/// </summary>
		/// <param name="enable">Enable.</param>
		public virtual void EnableControls(bool enable)
		{
		}

		/// <summary>
		/// Validates the data.
		/// </summary>
		/// <returns></returns>
		public virtual bool ValidateData()
		{
			return false;
		}

		public virtual void UpdateData()
		{
		}

		public virtual void InsertData()
		{
		}

		public virtual void DisplayData()
		{
		}

		public virtual void PrintData()
		{
		}
	}
}