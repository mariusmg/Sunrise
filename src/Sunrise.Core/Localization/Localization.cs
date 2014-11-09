/*

	   file: Localization.cs
description: design to suport localization.
	 author: Marius Gheorghe


*/

using System;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Summary description for Localization.
	/// </summary>
	public class Localization
	{
		private static object lockResourceAware; // = new object();
		private static object lockResource; // = new object();

		static Localization()
		{
			lockResourceAware = new object();
			lockResource = new object();
		}

		/// <summary>
		/// Private ctor to prevent instantiation
		/// </summary>
		private Localization()
		{
		}

		/// <summary>
		/// Returns the specified resource using the internal convention
		/// for culture info aware resources.                                   		
		/// </summary>
		/// <param name="resourceId">The resource identificator.</param>
		/// <param name="resourceName">The resource filename</param>
		/// <param name="asm">Assembly in which the resource resides.</param>
		/// <returns>The resource value. </returns>
		public static object GetCultureInfoResource(string resourceId, string resourceName, Assembly asm)
		{
			ResourceManager rsm = null;

			try
			{
				lock (lockResourceAware.GetType())
				{
					rsm = new ResourceManager(resourceName, asm);
					return rsm.GetObject(resourceId + "_" + Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower());
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (rsm != null)
				{
					rsm.ReleaseAllResources();
				}
			}
		}

		/// <summary>
		/// Returns the specified resource using the specified language convention
		/// </summary>
		/// <param name="resourceId">Resource's id</param>
		/// <param name="resourceName">Resource name including the namespace</param>
		/// <param name="languageName">The 2 letters ISO language name</param>
		/// <param name="asm">Assembly from which the resource is loaded</param>
		/// <returns>Resource</returns>
		public static object GetCultureInfoResource(string resourceId, string resourceName, string languageName, Assembly asm)
		{
			ResourceManager rsm = null;

			try
			{
				lock (lockResourceAware.GetType())
				{
					rsm = new ResourceManager(resourceName, asm);
					return rsm.GetObject(resourceId + "_" + languageName);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (rsm != null)
				{
					rsm.ReleaseAllResources();
				}
			}
		}

		/// <summary>
		/// Returns the specified resource.
		/// </summary>
		/// <param name="resourceID">The resource identificator</param>
		/// <param name="resourceName">The resource filename</param>
		/// <param name="asm">Assembly in which the resource resides.</param>
		/// <returns>The resource value.</returns>
		public static object GetResource(string resourceID, string resourceName, Assembly asm)
		{
			ResourceManager rsm = null;

			try
			{
				lock (lockResource.GetType())
				{
					rsm = new ResourceManager(resourceName, asm);
					return rsm.GetString(resourceID);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (rsm != null)
				{
					rsm.ReleaseAllResources();
				}
			}
		}
	}
}