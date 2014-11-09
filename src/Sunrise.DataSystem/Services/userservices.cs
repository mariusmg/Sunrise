using System;
using voidsoft.DataBlock;
using voidsoft.Sunrise.Core;

namespace voidsoft.Sunrise.DataSystem
{
	/// <summary>
	/// Summary description for UserServices.
	/// </summary>
	public class UserServices
	{
		private static UsersTableMetadata user;
		private static UsersPersistentObject userPersistent;

		/// <summary>
		/// Static ctor
		/// </summary>
		static UserServices()
		{
			user = new UsersTableMetadata();
			userPersistent = new UsersPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, user);
		}

		/// <summary>
		/// Checks a user's log on credentials. Returns true if everything is ok
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="userPassword"></param>
		/// <returns></returns>
		public static bool CheckUserCredentials(string userName, string userPassword, ref string userId, ref bool isAdministrator)
		{
			try
			{
				QueryCriteria qc = new QueryCriteria(user);
				qc.Add(CriteriaOperator.Equality, user.TableFields[1], userName); //name
				qc.Add(CriteriaOperator.Equality, user.TableFields[2], userPassword); //password

				UsersTableMetadata[] newUser = (UsersTableMetadata[]) userPersistent.GetTableMetadata(qc);
				isAdministrator = newUser[0].IsAdmin;
				userId = newUser[0].Id.ToString();

				return newUser[0] != null ? true : false;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Checks if the specified user name already exists
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public static bool IsUserName(string userName)
		{
			try
			{
				QueryCriteria qc = new QueryCriteria(user);
				qc.Add(CriteriaOperator.Equality, user.TableFields[1], userName);

				UsersTableMetadata[] usr = (UsersTableMetadata[]) userPersistent.GetTableMetadata(qc);

				if (usr.Length == 0)
				{
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.LogError("IsUserName " + ex.Message);

				return true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		/// <param name="userRights"></param>
		public static void CreateUser(UsersTableMetadata user, EntityUserRightsTableMetadata[] userRights)
		{
			userPersistent.Create(user, userRights);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		/// <param name="userRights"></param>
		public static void UpdateUser(UsersTableMetadata user, EntityUserRightsTableMetadata[] userRights)
		{
			try
			{
				userPersistent.Update(user, userRights);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}