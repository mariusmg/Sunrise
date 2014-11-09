/*

		file: Main.cs
 description: Application's main window. 
	  author: Marius Gheorghe

*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;
using voidsoft.Sunrise.DataSystem;
using voidsoft.Sunrise.Main.Dialogs;

namespace voidsoft.Sunrise.Main
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainWindow : Form
	{
		private StatusBar statusBar;
		private StatusBarPanel sbPanelUser;
		private StatusBarPanel sbPanelCompany;
		private MainMenu mainMenu;
		private MenuItem menuItem1;
		private MenuItem menuItem2;
		private MenuItem menuItem3;
		private MenuItem menuItem4;
		private MenuItem menuItem5;
		private MenuItem menuItem6;
		private MenuItem menuItem7;
		private MenuItem menuItem8;
		private MenuItem menuItem9;
		private ToolStrip toolStrip;
		//private RaftingContainer leftRaftingContainer;
		//private RaftingContainer leftRaftingContainer1;
		//private RaftingContainer topRaftingContainer;
		//private RaftingContainer bottomRaftingContainer;
		private IContainer components;

		public MainWindow()
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
			components = new Container();
			statusBar = new StatusBar();
			sbPanelUser = new StatusBarPanel();
			sbPanelCompany = new StatusBarPanel();
			mainMenu = new MainMenu(components);
			menuItem1 = new MenuItem();
			menuItem3 = new MenuItem();
			menuItem4 = new MenuItem();
			menuItem5 = new MenuItem();
			menuItem6 = new MenuItem();
			menuItem2 = new MenuItem();
			menuItem7 = new MenuItem();
			menuItem8 = new MenuItem();
			menuItem9 = new MenuItem();
			toolStrip = new ToolStrip();
			((ISupportInitialize) (sbPanelUser)).BeginInit();
			((ISupportInitialize) (sbPanelCompany)).BeginInit();
			SuspendLayout();
			// 
			// statusBar
			// 
			statusBar.ImeMode = ImeMode.NoControl;
			statusBar.Location = new Point(0, 725);
			statusBar.Name = "statusBar";
			statusBar.Panels.AddRange(new[] {sbPanelUser, sbPanelCompany});
			statusBar.Size = new Size(1082, 16);
			statusBar.TabIndex = 0;
			// 
			// sbPanelUser
			// 
			sbPanelUser.Name = "sbPanelUser";
			// 
			// sbPanelCompany
			// 
			sbPanelCompany.AutoSize = StatusBarPanelAutoSize.Contents;
			sbPanelCompany.Name = "sbPanelCompany";
			sbPanelCompany.Width = 10;
			// 
			// mainMenu
			// 
			mainMenu.MenuItems.AddRange(new[] {menuItem1, menuItem2});
			// 
			// menuItem1
			// 
			menuItem1.Index = 0;
			menuItem1.MenuItems.AddRange(new[] {menuItem3, menuItem4, menuItem5, menuItem6});
			menuItem1.Text = "&Options";
			// 
			// menuItem3
			// 
			menuItem3.Index = 0;
			menuItem3.Text = "&Users";
			menuItem3.Click += menuUsers_Activate;
			// 
			// menuItem4
			// 
			menuItem4.Index = 1;
			menuItem4.Text = "&Switch user";
			menuItem4.Click += menuLogUser_Activate;
			// 
			// menuItem5
			// 
			menuItem5.Index = 2;
			menuItem5.Text = "-";
			// 
			// menuItem6
			// 
			menuItem6.Index = 3;
			menuItem6.Text = "Company";
			menuItem6.Click += menuCompany_Activate;
			// 
			// menuItem2
			// 
			menuItem2.Index = 1;
			menuItem2.MenuItems.AddRange(new[] {menuItem7, menuItem8, menuItem9});
			menuItem2.Text = "&Help";
			// 
			// menuItem7
			// 
			menuItem7.Index = 0;
			menuItem7.Text = "&Help";
			// 
			// menuItem8
			// 
			menuItem8.Index = 1;
			menuItem8.Text = "-";
			// 
			// menuItem9
			// 
			menuItem9.Index = 2;
			menuItem9.Text = "&About";
			menuItem9.Click += menuAbout_Activate;
			// 
			// toolStrip
			// 
			toolStrip.Location = new Point(0, 0);
			toolStrip.Name = "toolStrip";
			toolStrip.Size = new Size(42, 25);
			toolStrip.TabIndex = 0;
			toolStrip.Text = "toolStrip1";
			// 
			// MainWindow
			// 
			AutoScaleBaseSize = new Size(5, 13);
			ClientSize = new Size(1082, 741);
			Controls.Add(statusBar);
			IsMdiContainer = true;
			Menu = mainMenu;
			Name = "MainWindow";
			Text = "Sunrise framework";
			Load += MainWindow_Load;
			((ISupportInitialize) (sbPanelUser)).EndInit();
			((ISupportInitialize) (sbPanelCompany)).EndInit();
			ResumeLayout(false);
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			try
			{
				//set the logged user
				statusBar.Panels[0].Text = "User: " + SharedData.UserName;

				//set the company
				statusBar.Panels[1].Text = "Company: " + SharedData.CompanyName;
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
		}

		private void menuUsers_Activate(object sender, EventArgs e)
		{
			UserListDialog usDialog = null;

			try
			{
				if (SharedData.IsAdministrator)
				{
					usDialog = new UserListDialog();
					usDialog.ShowDialog();
				}
				else
				{
					MessageBox.Show("You must have administrator rights");
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex.StackTrace);
			}
			finally
			{
				if (usDialog == null)
				{
					usDialog.Dispose();
				}
			}
		}

		private void menuLogUser_Activate(object sender, EventArgs e)
		{
			try
			{
				foreach (Form frm in MdiChildren)
				{
					frm.Close();
					frm.Dispose();
				}

				EntryPoint.LogUser();
			}
			catch (Exception ex)
			{
			}
		}

		private void menuAbout_Activate(object sender, EventArgs e)
		{
			AboutDialog abDialog = null;

			try
			{
				abDialog = new AboutDialog();
				abDialog.ShowDialog();
			}
			catch
			{
			}
			finally
			{
				if (abDialog != null)
				{
					abDialog.Dispose();
				}
			}
		}

		private void menuHelp_Activate(object sender, EventArgs e)
		{
		}

		private void menuCompany_Activate(object sender, EventArgs e)
		{
			CompanyDataDialog cdDialog = null;

			try
			{
				cdDialog = new CompanyDataDialog();
				cdDialog.ShowDialog();
			}
			catch (Exception ex)
			{
				Log.LogError(ex.StackTrace);
			}
			finally
			{
				if (cdDialog != null)
				{
					cdDialog.Dispose();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadEntity("ExtenderTest"); //,"ExtenderTest.dll", this);
		}

		private void LoadEntity(string entityName)
		{
			try
			{
				AbstractClassEntityLoader loader = new AbstractClassEntityLoader();
				loader.LoadEntity(entityName, entityName + ".dll", this);
			}
			catch (ApplicationException aex)
			{
				MessageBox.Show("Invalid user rights");
			}
			catch (Exception ex)
			{
			}
		}

		private void LoadEntity(string entityName, string entityAssembly)
		{
			try
			{
			}
			catch (ApplicationException aex)
			{
				MessageBox.Show("Invalid user rights");
			}
			catch (Exception ex)
			{
			}
		}
	}
}