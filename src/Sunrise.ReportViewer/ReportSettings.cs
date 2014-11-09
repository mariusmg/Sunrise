/*

       file: ReportSettings.cs 
description: 
     author: Marius Gheorghe

*/


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using voidsoft.Sunrise.ReportViewer;
using voidsoft.Sunrise.Core;


                                                              
namespace voidsoft.Sunrise.ReportViewer
{


	/// <summary>
	/// Summary description for ReportSettings.
	/// </summary>
	public class ReportSettings
	{
		private ReportSettings()
		{
		}


		/// <summary>
		/// Sets the report header data
		/// </summary>
		/// <param name="report"></param>
		public static void SetReportData(ref DataDynamics.ActiveReports.ActiveReport report)
		{

			Bitmap bmp = null;

			try
			{

				for(int i = 0 ; i < report.Sections[0].Controls.Count; i++)
				{
					switch(report.Sections[0].Controls[i].Name)
					{
						case "labelCompanyName":
							DataDynamics.ActiveReports.Label labelName = (DataDynamics.ActiveReports.Label) report.Sections[0].Controls[i];
							labelName.Text = SharedData.CompanyName;
							break;

						case "pictureLogo":
							DataDynamics.ActiveReports.Picture picture = (DataDynamics.ActiveReports.Picture) report.Sections[0].Controls[i];
							if(SharedData.CompanyLogoPath != string.Empty)
							{
								bmp = new Bitmap(SharedData.CompanyLogoPath);
								picture.Image = bmp;
							}
							break;
					}

				}
			}
			catch(Exception ex)
			{
				Log.LogError(ex.Message);
				throw ex;
			}
			finally
			{

			}
		}



		/// <summary>
		/// Sets the report data.
		/// </summary>
		/// <param name="report">Report.</param>
		/// <param name="reportTitle">Report title.</param>
		/// <param name="reportBusinessOwnerName">Name of the report business owner.</param>
		/// <param name="logoFilePath">Logo file path.</param>
		public static void SetReportData(DataDynamics.ActiveReports.ActiveReport report,
										 string reportTitle,
										 string reportBusinessOwnerName,
										 string logoFilePath)
		{
			throw new NotImplementedException(); 
			
		}

	
	}
}
