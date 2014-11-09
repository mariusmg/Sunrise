/*

  
	   file: EntryPoint.cs
description: application entry point.
	 author: Marius Gheorghe.
  

*/

using System;
using System.Threading;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;
using voidsoft.Sunrise.DataSystem;
using voidsoft.Sunrise.Main.Dialogs;

namespace voidsoft.Sunrise.Main
{
	/// <summary>
	/// Entry Point class
	/// </summary>
	public sealed class EntryPoint
	{
		private static Form mainWindow;

		/// <summary>
		///  Application entry point
		/// </summary>
		public static void Main()
		{
			Application.ThreadException += Application_ThreadException;

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			Configuration.InitializeCultureInfo();

			//enable visual styles on XP/2003.
			Application.EnableVisualStyles();

			Configuration.InitializeSystemData();

			//log on the user
			try
			{
				LogUser();
			}
			catch (Exception ex)
			{
				Log.LogError(ex.StackTrace);

				MessageBox.Show("Failed to log the user");
				Application.Exit();
			}
		}

		/// <summary>
		/// Log in the user
		/// </summary>
		public static void LogUser()
		{
			LogonUserDialog luDialog = null;

			try
			{
				//if the main window is already open dispose everything and GC.
				if (mainWindow != null)
				{
					mainWindow.Close();
					mainWindow.Dispose();
					GC.Collect();
				}

				luDialog = new LogonUserDialog();

				if (luDialog.ShowDialog() == DialogResult.OK)
				{
					//init data
					Configuration.InitializeDatabase(luDialog.SelectedCompanyID);

					MainWindow window = new MainWindow();
					EntryPoint.mainWindow = window;

					mainWindow.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (luDialog != null)
				{
					luDialog.Dispose();
				}
			}
		}

		/// <summary>
		/// Thread Exception event handlers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		internal static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Log.LogError(e.Exception.Message + e.Exception.StackTrace);
		}

		/// <summary>
		/// Application Domain unhandled exception event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = (Exception) e.ExceptionObject;
			Log.LogError(ex.Message + ex.StackTrace);
		}
	}
}