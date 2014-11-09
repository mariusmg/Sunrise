/*

  	  class: SharedData.cs
description: general data used in the application.
	 author: Marius Gheorghe

*/

using System.Collections.Generic;
using voidsoft.DataBlock;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Holds user/system informations.
	/// </summary>
	public static class SharedData
	{
		private static EDatabase systemServerType;
		private static string systemConnectionString;
		private static string userName;
		private static string userPassword;
		private static string userId;
		private static bool isAdministrator;
		private static string localizationSuffix;
		private static string companyName;
		private static string companyAddress;
		private static string companyLogoPath;
		private static int companyId;

		private static string databaseConnectionString;
		private static EDatabase databaseServerType;

		/// <summary>
		/// Hashtable which contains the loaded entities
		/// </summary>
		public static Dictionary<string, BusinessForm> loadedEntities;

		/// <summary>
		/// Static constructor
		/// </summary>
		static SharedData()
		{
			loadedEntities = new Dictionary<string, BusinessForm>();
		}

		/// <summary>
		/// Database server type for the system database
		/// </summary>
		public static EDatabase SystemServerType
		{
			get
			{
				return systemServerType;
			}
			set
			{
				systemServerType = value;
			}
		}

		/// <summary>
		/// Database connection string for the system database
		/// </summary>
		public static string SystemConnectionString
		{
			get
			{
				return systemConnectionString;
			}
			set
			{
				systemConnectionString = value;
			}
		}

		/// <summary>
		/// The name of the logger user.
		/// </summary>
		public static string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
			}
		}

		/// <summary>
		/// The password of the logged user.
		/// </summary>
		public static string UserPassword
		{
			get
			{
				return userPassword;
			}
			set
			{
				userPassword = value;
			}
		}

		/// <summary>
		/// The database ID of the logged user.
		/// </summary>
		public static string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				userId = value;
			}
		}

		/// <summary>
		/// Flag to know if the logged user is administrator or not.
		/// </summary>
		public static bool IsAdministrator
		{
			get
			{
				return isAdministrator;
			}
			set
			{
				isAdministrator = value;
			}
		}

		/// <summary>
		/// String used in localization. This string is
		/// used to identity the current language.
		/// </summary>
		public static string LocalizationSuffix
		{
			get
			{
				return localizationSuffix;
			}
			set
			{
				localizationSuffix = value;
			}
		}

		/// <summary>
		/// Company name.
		/// </summary>
		public static string CompanyName
		{
			get
			{
				return companyName;
			}
			set
			{
				companyName = value;
			}
		}

		/// <summary>
		/// The company address.
		/// </summary>
		public static string CompanyAddress
		{
			get
			{
				return companyAddress;
			}
			set
			{
				companyAddress = value;
			}
		}

		/// <summary>
		/// The path to the picture's file which contains the company logo.
		/// </summary>
		public static string CompanyLogoPath
		{
			get
			{
				return companyLogoPath;
			}
			set
			{
				companyLogoPath = value;
			}
		}

		/// <summary>
		/// Database company Id.
		/// </summary>
		public static int CompanyId
		{
			get
			{
				return companyId;
			}
			set
			{
				companyId = value;
			}
		}

		/// <summary>
		/// The database server type which is currently used
		/// </summary>
		public static EDatabase DatabaseServerType
		{
			get
			{
				return databaseServerType;
			}
			set
			{
				databaseServerType = value;
			}
		}

		/// <summary>
		/// the connection string used to connect to the database
		/// </summary>
		public static string DatabaseConnectionString
		{
			get
			{
				return databaseConnectionString;
			}
			set
			{
				databaseConnectionString = value;
			}
		}
	}
}