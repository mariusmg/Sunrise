/*

	   file: ReportViewer.cs
description: ActiveReports viewer. Allows to load/display a report.
     author: Gheorghe MARius.

*/

using System;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;



namespace voidsoft.Sunrise.ReportViewer
{


	public class ActiveReportsViewer :  System.Windows.Forms.Form
	{
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
	
		private System.ComponentModel.Container components = null;

		public ActiveReportsViewer()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Name = "ReportViewer";
			this.reportViewer1.Size = new System.Drawing.Size(396, 246);
			this.reportViewer1.TabIndex = 0;
			// 
			// ActiveReportsViewer
			// 
			this.ClientSize = new System.Drawing.Size(901, 439);
			this.Name = "ActiveReportsViewer";
			this.Load += new System.EventHandler(this.ActiveReportsViewer_Load);
			this.ResumeLayout(false);

        }
		#endregion


		#region report loaders

		/// <summary>
		/// Loads and displays the report.
		/// </summary>
		/// <param name="reportFileName">the report file</param>
		/// <param name="dataSource">the report datasource</param>
		public void LoadReport(string reportFileName, 
							   object dataSource)
		{
			ActiveReport arReport = null;

			try
			{
				arReport = new ActiveReport();
				arReport.LoadLayout(reportFileName);
				arReport.DataSource = dataSource;

				//customize report
				ReportSettings.SetReportData(ref arReport);

				arReport.Run();
				this.viewer.Document = arReport.Document;

			}
			catch(Exception ex)
			{
				Log.LogError(ex.Message + " " + ex.StackTrace);
				throw ex;
			}
		}

		private void ReportViewer_Load(object sender, System.EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}



		/// <summary>
		/// Loads and displays the report.
		/// </summary>
		/// <param name="arReport"></param>
		/// <param name="dataSource"></param>
		public void LoadReport(DataDynamics.ActiveReports.ActiveReport arReport, 
						  	   object dataSource)
		{
			try
			{
				arReport.DataSource = dataSource;

				//customize report
				ReportSettings.SetReportData(ref arReport);


				arReport.Run();
				this.viewer.Document = arReport.Document;
			}
			catch(Exception ex)
			{
				Log.LogError(ex.Message + " " + ex.StackTrace);
				throw ex;
			}
		}
		
		public void LoadReport(ActiveReport arReport)
		{
			try
			{
				//customize report
				//ReportSettings.SetReportData(arReport);

				arReport.Run();
				this.viewer.Document = arReport.Document;
			}
			catch(Exception ex)
			{
				Log.LogError(ex.Message + " " + ex.StackTrace);
				throw ex;
			}
		}
	
	
		#endregion

		private void ActiveReportsViewer_Load(object sender, EventArgs e)
		{

		}

	}
}
