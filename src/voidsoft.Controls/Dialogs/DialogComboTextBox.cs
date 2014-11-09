/*

	   file: DialogComboTextBox.cs
description:
	 author: Gheorghe MARius.



*/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	public class DialogComboTextBox : Form
	{
		private string[] dataObjects;

		public ComboBox cboData;
		private Button buttonOK;
		private Button buttonCancel;
		public Label labelCriteria;
		public Label labelSearch;
		public TextBox textSearch;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public DialogComboTextBox(string[] dataObjects)
		{
			InitializeComponent();

			this.dataObjects = dataObjects;
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
			this.cboData = new System.Windows.Forms.ComboBox();
			this.textSearch = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelCriteria = new System.Windows.Forms.Label();
			this.labelSearch = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cboData
			// 
			this.cboData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboData.Location = new System.Drawing.Point(112, 8);
			this.cboData.Name = "cboData";
			this.cboData.Size = new System.Drawing.Size(168, 21);
			this.cboData.TabIndex = 0;
			// 
			// textSearch
			// 
			this.textSearch.Location = new System.Drawing.Point(8, 56);
			this.textSearch.Multiline = true;
			this.textSearch.Name = "textSearch";
			this.textSearch.Size = new System.Drawing.Size(272, 104);
			this.textSearch.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(144, 168);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 32);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(216, 168);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 32);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelCriteria
			// 
			this.labelCriteria.Location = new System.Drawing.Point(8, 8);
			this.labelCriteria.Name = "labelCriteria";
			this.labelCriteria.Size = new System.Drawing.Size(96, 16);
			this.labelCriteria.TabIndex = 4;
			this.labelCriteria.Text = "Choose :";
			// 
			// labelSearch
			// 
			this.labelSearch.Location = new System.Drawing.Point(8, 32);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(264, 16);
			this.labelSearch.TabIndex = 5;
			// 
			// DialogComboTextBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 208);
			this.Controls.Add(this.labelSearch);
			this.Controls.Add(this.labelCriteria);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textSearch);
			this.Controls.Add(this.cboData);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "DialogComboTextBox";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.DialogCombo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void DialogCombo_Load(object sender, EventArgs e)
		{
			try
			{
				cboData.DataSource = dataObjects;
				cboData.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
			}
		}
	}
}