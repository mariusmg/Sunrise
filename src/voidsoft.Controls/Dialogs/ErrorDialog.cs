using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Summary description for ErrorDialog.
	/// </summary>
	internal class ErrorDialog : Form
	{
		private Button buttonOK;
		public TextBox textBoxDetails;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private const int SMALL_WIDTH = 426;
		private const int SMALL_HEIGHT = 160;

		private const int BIG_WIDTH = 426;
		private Button buttonDetails;
		public TextBox textBoxError;
		private const int BIG_HEIGHT = 296;

		public ErrorDialog()
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonDetails = new System.Windows.Forms.Button();
			this.textBoxDetails = new System.Windows.Forms.TextBox();
			this.textBoxError = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(328, 120);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(72, 32);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "&OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonDetails
			// 
			this.buttonDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonDetails.Location = new System.Drawing.Point(8, 120);
			this.buttonDetails.Name = "buttonDetails";
			this.buttonDetails.Size = new System.Drawing.Size(72, 32);
			this.buttonDetails.TabIndex = 1;
			this.buttonDetails.Text = "&Details";
			this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
			// 
			// textBoxDetails
			// 
			this.textBoxDetails.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxDetails.Enabled = false;
			this.textBoxDetails.Location = new System.Drawing.Point(16, 168);
			this.textBoxDetails.Multiline = true;
			this.textBoxDetails.Name = "textBoxDetails";
			this.textBoxDetails.Size = new System.Drawing.Size(392, 160);
			this.textBoxDetails.TabIndex = 3;
			this.textBoxDetails.Text = "";
			this.textBoxDetails.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBoxError
			// 
			this.textBoxError.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxError.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxError.Location = new System.Drawing.Point(16, 16);
			this.textBoxError.Multiline = true;
			this.textBoxError.Name = "textBoxError";
			this.textBoxError.Size = new System.Drawing.Size(392, 96);
			this.textBoxError.TabIndex = 4;
			this.textBoxError.Text = "";
			// 
			// ErrorDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(418, 160);
			this.Controls.Add(this.textBoxError);
			this.Controls.Add(this.textBoxDetails);
			this.Controls.Add(this.buttonDetails);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ErrorDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ErrorDialog";
			this.Load += new System.EventHandler(this.ErrorDialog_Load);
			this.ResumeLayout(false);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void ErrorDialog_Load(object sender, EventArgs e)
		{
		}

		private void buttonDetails_Click(object sender, EventArgs e)
		{
			if (Height == SMALL_HEIGHT)
			{
				Height = BIG_HEIGHT;
				Width = BIG_WIDTH;
			}
			else
			{
				Height = SMALL_HEIGHT;
				Width = SMALL_WIDTH;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}