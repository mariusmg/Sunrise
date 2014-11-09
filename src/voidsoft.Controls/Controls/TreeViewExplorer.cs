


using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Win32API;
using voidsoft.Controls;




namespace voidsoft.Controls
{
	public class TreeViewExplorer : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView treeView;
		public System.Windows.Forms.ImageList img;
		private System.ComponentModel.IContainer components;

		public TreeViewExplorer()
		{
			InitializeComponent();

		}


		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TreeViewExplorer));
			this.treeView = new System.Windows.Forms.TreeView();
			this.img = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.ImageList = this.img;
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(224, 280);
			this.treeView.TabIndex = 0;
			// 
			// img
			// 
			this.img.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.img.ImageSize = new System.Drawing.Size(16, 16);
//			this.img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img.ImageStream")));
			this.img.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// TreeViewExplorer
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.treeView});
			this.Name = "TreeViewExplorer";
			this.Size = new System.Drawing.Size(224, 280);
			this.ResumeLayout(false);

		}
		#endregion
	
	
	
	
	

		public void LoadMainItems()
		{

			this.treeView.Nodes.Add( new TreeNode("Desktop", 3,3));
 
			string[] drives = System.Environment.GetLogicalDrives();

			for(int i = 0 ; i < drives.Length; i++)
			{
					this.treeView.Nodes[0].Nodes.Add(System.Win32API.CFileSystem.DriveType(drives[i]));
			}
            

		   this.treeView.Nodes[0].EnsureVisible();

		}


	


		#region private stuff






		#endregion
	
	
	
	
	
	
	
	}
}
