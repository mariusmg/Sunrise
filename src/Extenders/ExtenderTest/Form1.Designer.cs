namespace ExtenderTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 532);
            this.statusBar.Size = new System.Drawing.Size(603, 16);
            // 
            // groupBox
            // 
            this.groupBox.Size = new System.Drawing.Size(603, 56);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(676, 24);
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Size = new System.Drawing.Size(650, 20);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(339, 501);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(427, 501);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(515, 501);
            // 
            // buttonViewDetails
            // 
            this.buttonViewDetails.Location = new System.Drawing.Point(8, 501);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(547, 63);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(130, 412);
            this.dataGrid1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 548);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            this.Controls.SetChildIndex(this.statusBar, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.buttonUpdate, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            this.Controls.SetChildIndex(this.buttonViewDetails, 0);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
    }
}