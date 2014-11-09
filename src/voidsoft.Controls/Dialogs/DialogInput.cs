/*

	   file: DialogInput.cs
description:	



*/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Summary description for DialogInput.
	/// </summary>
	public class DialogInput : Form
	{
		private GroupBox groupBox;
		public Label labelName;
		public TextBox textBox;
		public Button buttonOK;
		public Button buttonCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public DialogInput()
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.labelName = new System.Windows.Forms.Label();
			this.textBox = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.labelName);
			this.groupBox.Controls.Add(this.textBox);
			this.groupBox.Location = new System.Drawing.Point(8, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(328, 72);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			// 
			// labelName
			// 
			this.labelName.Location = new System.Drawing.Point(8, 16);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(312, 16);
			this.labelName.TabIndex = 0;
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(8, 40);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(312, 20);
			this.textBox.TabIndex = 1;
			this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(200, 80);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 32);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.buttonOK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(272, 80);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 32);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonCancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
			// 
			// DialogInput
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonOK;
			this.ClientSize = new System.Drawing.Size(344, 120);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DialogInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DialogInput";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.ResumeLayout(false);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (textBox.Text != "")
				{
					DialogResult = DialogResult.OK;
				}

				Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception ex)
			{
			}
		}

		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == Keys.Enter)
				{
					Close();
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void textBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}