/*

	   file: UserLog.cs
description: logs the user actions.
     author: Gheorghe MARius

*/

using System;
using voidsoft.DataBlock;

namespace voidsoft.ObjectWire.Shared
{

	/// <summary>
	/// Logs user actions
	/// </summary>
	public class UserLog
	{
		private UserLog()
		{
		}



		/// <summary>
		/// Logs the user actions.
		/// Uses data from Shared.
		/// </summary>
		/// <param name="userAction"></param>
		/// <param name="details"></param>
		public static void LogUserAction(string userAction,
										 string details)
		{
			try
			{
				string commandString = "INSERT INTO UserLog(UserID, UserName, LogDate, UserAction, Details) VALUES(" + SharedData.UserId + "," + SharedData.UserName + ",'" + DateTime.Now.ToShortDateString() + "'," + userAction + "','" + details + "')";
				DataAccessLayer.ExecuteNonQuery(SharedData.DatabaseServerType, SharedData.SystemConnectionString, commandString);

			}
			catch(Exception ex)
			{
				Log.LogError("LogUserAction failed " + ex.StackTrace);
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="userName"></param>
		/// <param name="userAction"></param>
		/// <param name="details"></param>
		/// <param name="logDate"></param>
		public static void LogUserAction(string userID,
										string userName,
										string userAction,
										string details,
										DateTime logDate)
		{
			try
			{


			}
			catch(Exception ex)
			{
			}
		}

	
	}
}
