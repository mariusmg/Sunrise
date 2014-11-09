/*

	   file: Configuration.cs
description: Application configuration data.
	 author: Marius Gheorghe


*/

using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using voidsoft.DataBlock;
using voidsoft.Sunrise.Core;

namespace voidsoft.Sunrise.DataSystem
{
	/// <summary>
	/// Configuration class.
	/// </summary>
	public sealed class Configuration
	{
		private Configuration()
		{
		}

		//const which are used to init the database provider type
		private const byte ACCESS = 1;
		private const byte SQLSERVER = 2;
		private const byte MYSQL = 3;

		/// <summary>
		/// Initializes the main thread culture info. If the value 
		/// in the config file is "default" then there is no change.
		/// </summary>
		public static void InitializeCultureInfo()
		{
			try
			{
				AppSettingsReader aread = new AppSettingsReader();
				object result = aread.GetValue("UICultureInfo", typeof (string));

				if (result.ToString().ToLower() == "default")
				{
				}
				else
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(result.ToString());
				}
			}
			catch (Exception ex)
			{
				Log.LogError("Failed to set thread culture info " + ex.StackTrace);
			}
			finally
			{
			}
		}

		/// <summary>
		/// Initializes the system database.
		/// </summary>
		public static void InitializeSystemData()
		{
			try
			{
				AppSettingsReader aread = new AppSettingsReader();

				object connectionString = aread.GetValue("SystemStringConnection", typeof (string));
				object serverType = aread.GetValue("SystemDatabaseServer", typeof (string));

				if (serverType.ToString().ToLower() == "sqlserver")
				{
					SharedData.SystemServerType = EDatabase.SqlServer;
					SharedData.SystemConnectionString = connectionString.ToString();
				}
				else if (serverType.ToString().ToLower() == "mysql")
				{
					SharedData.SystemServerType = EDatabase.MySQL;
					SharedData.SystemConnectionString = connectionString.ToString();
				}
				else if (serverType.ToString().ToLower() == "access")
				{
					SharedData.SystemServerType = EDatabase.Access;
					SharedData.SystemConnectionString = connectionString.ToString();
				}
			}
			catch (Exception ex)
			{
				Log.LogError("Failed to get system database data." + ex.Message);
				Application.Exit();
			}
			finally
			{
			}
		}

		/// <summary>
		///Initialize the user database.
		/// </summary>
		/// <param name="companyId">company ID</param>
		public static void InitializeDatabase(int companyId)
		{
			try
			{
				int serverType = 0;
				string companyName = string.Empty, companyAddress = string.Empty, connectionString = string.Empty, logoPath = string.Empty;

				CompanyServices.GetCompanyDetails(ref companyId, ref companyName, ref companyAddress, ref connectionString, ref logoPath, ref serverType);

				//init the database provider and type based on this flag.

				SharedData.CompanyId = companyId;
				SharedData.CompanyName = companyName;
				SharedData.CompanyAddress = companyAddress;
				SharedData.DatabaseConnectionString = connectionString;
				SharedData.CompanyLogoPath = logoPath;

				switch (serverType)
				{
					case ACCESS:
						SharedData.DatabaseServerType = EDatabase.Access;
						break;

					case SQLSERVER:
						SharedData.DatabaseServerType = EDatabase.SqlServer;
						break;

					case MYSQL:
						SharedData.DatabaseServerType = EDatabase.MySQL;
						break;
				}
			}
			catch (Exception ex)
			{
				Log.LogError("Failed to initialize company data " + ex.StackTrace);
				throw ex;
			}
		}
	}
}