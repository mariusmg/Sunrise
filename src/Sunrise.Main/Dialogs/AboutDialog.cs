/*

	   file: AboutDialog.cs
description:



*/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Main.Dialogs
{
	/// <summary>
	/// Summary description for AboutDialog.
	/// </summary>
	public class AboutDialog : Form
	{
		private PictureBox pictureBox1;
		private Label labelTitle;
		private Button buttonClose;
		private Label labelCopyright;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public AboutDialog()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (AboutDialog));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelCopyright = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(72, 64);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// labelTitle
			// 
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.labelTitle.Location = new System.Drawing.Point(96, 16);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(216, 24);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Sunrise  Framework";
			// 
			// buttonClose
			// 
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonClose.Location = new System.Drawing.Point(240, 128);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(88, 32);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "&OK";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// labelCopyright
			// 
			this.labelCopyright.Location = new System.Drawing.Point(104, 48);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(193, 16);
			this.labelCopyright.TabIndex = 3;
			this.labelCopyright.Text = "(C) 2004 -2014 Marius Gheorghe";
			// 
			// AboutDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(338, 176);
			this.Controls.Add(this.labelCopyright);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.Text = "About";
			this.Load += new System.EventHandler(this.AboutDialog_Load);
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AboutDialog_Load(object sender, EventArgs e)
		{
		}
	}
}