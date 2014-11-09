namespace ExtenderTest
{
    partial class TestNavigationForm
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
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Size = new System.Drawing.Size(598, 56);
            // 
            // tabControl
            // 
            this.errorProvider.SetIconAlignment(this.tabControl, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.tabControl.Size = new System.Drawing.Size(598, 253);
            // 
            // tabDetails
            // 
            this.errorProvider.SetIconAlignment(this.tabDetails, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.tabDetails.Size = new System.Drawing.Size(590, 227);
            // 
            // TestNavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 309);
            this.Name = "TestNavigationForm";
            this.Text = "TestNavigationForm";
            this.Load += new System.EventHandler(this.TestNavigationForm_Load);
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}