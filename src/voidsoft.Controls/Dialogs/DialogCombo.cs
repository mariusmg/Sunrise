/*

  	   file: DialogCombo.cs
description: A dialog which allows the user to select data
			 from a combo box.
	 author: Gheorghe MARius


*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Dialog which allows the user to select data from a combobox.
	/// </summary>
	public class DialogCombo : Form
	{
		protected ComboBox cbo;
		protected Button buttonOK;
		protected Button buttonCancel;
		protected Label labelName;

		private Container components = null;

		protected IList list = null;
		protected IDictionary idict = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="list"></param>
		public DialogCombo(IList list)
		{
			InitializeComponent();

			this.list = list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idict"></param>
		public DialogCombo(IDictionary idict)
		{
			InitializeComponent();
			this.idict = idict;
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
			this.cbo = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbo
			// 
			this.cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo.FormattingEnabled = true;
			this.cbo.ItemHeight = 13;
			this.cbo.Location = new System.Drawing.Point(8, 32);
			this.cbo.Name = "cbo";
			this.cbo.Size = new System.Drawing.Size(296, 21);
			this.cbo.TabIndex = 0;
			this.cbo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyUp);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonOK.Location = new System.Drawing.Point(168, 72);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 32);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyUp);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonCancel.Location = new System.Drawing.Point(240, 72);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 32);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyUp);
			// 
			// labelName
			// 
			this.labelName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelName.Location = new System.Drawing.Point(8, 8);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(288, 16);
			this.labelName.TabIndex = 3;
			// 
			// DialogCombo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 109);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.cbo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DialogCombo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.DialogCombo_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_KeyUp);
			this.ResumeLayout(false);
		}

		private void DialogCombo_Load(object sender, EventArgs e)
		{
			if (list != null)
			{
				cbo.DataSource = list;
			}
			else
			{
				IDictionaryEnumerator ienum = idict.GetEnumerator();

				while (ienum.MoveNext())
				{
					cbo.Items.Add(ienum.Value.ToString());
				}
			}
		}

		private void cbo_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}