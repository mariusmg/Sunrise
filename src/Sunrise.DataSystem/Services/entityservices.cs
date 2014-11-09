using System;
using System.Collections;
using System.Data;
using System.Text;
using voidsoft.DataBlock;
using voidsoft.Sunrise.Core;

namespace voidsoft.Sunrise.DataSystem
{
	/// <summary>
	/// Entities and user rights services
	/// </summary>
	public class EntityServices
	{
		private static EntityTableMetadata entity;
		private static EntityPersistentObject entityPersistent;

		private static UserRightsTableMetadata userRights;
		private static UserRightsPersistentObject userRightsPersistent;

		private static EntityUserRightsTableMetadata entityUserRights;
		private static EntityUserRightsPersistentObject entityUserRightsPersistent;

		//caching
		private static SortedList sdUserRights;
		private static SortedList sdEntities;

		//static fields which hold the user rights id's from the database
		public static int UserRightView = 1;
		public static int UserRightInsert = 2;
		public static int UserRightDelete = 3;
		public static int UserRightUpdate = 4;

		/// <summary>
		/// Static constructor
		/// </summary>
		static EntityServices()
		{
			entity = new EntityTableMetadata();
			entityPersistent = new EntityPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, entity);

			userRights = new UserRightsTableMetadata();
			userRightsPersistent = new UserRightsPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, userRights);

			entityUserRights = new EntityUserRightsTableMetadata();
			entityUserRightsPersistent = new EntityUserRightsPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, entityUserRights);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static SortedList GetEntities()
		{
			if (sdEntities == null)
			{
				sdEntities = entityPersistent.GetFieldList(entity.TableFields[0], entity.TableFields[1]);
				return sdEntities;
			}
			return sdEntities;
		}

		/// <summary>
		/// Gets the entity supported user rights.
		/// </summary>
		/// <returns></returns>
		public static DataSet GetEntitySupportedRights()
		{
			try
			{
				EntityRightsTableMetadata entityRights = new EntityRightsTableMetadata();
				EntityUserRightsPersistentObject entityPersistent = new EntityUserRightsPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, entityRights);

				QueryCriteria qc = new QueryCriteria(entityRights.TableName, entityRights.TableFields);

				DataSet dsEntityRights = entityPersistent.GetDataSet(qc);
				return dsEntityRights;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static SortedList GetUserRights()
		{
			if (sdUserRights == null)
			{
				sdUserRights = userRightsPersistent.GetFieldList(userRights.TableFields[0], userRights.TableFields[1]);
				return sdUserRights;
			}
			return sdUserRights;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public static DataSet GetEntityUserRights(int userId)
		{
			QueryCriteria qc = new QueryCriteria(entityUserRights);
			qc.Add(CriteriaOperator.Equality, entityUserRights.GetField("UserId"), userId);

			DataSet ds = entityUserRightsPersistent.GetDataSet(qc);
			return ds;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="entityName"></param>
		/// <returns></returns>
		public static UserRights GetEntityUserRights(int userId, string entityName)
		{
			try
			{
				int entityId = -1;

				//get the user rights
				GetUserRights();
				GetEntities();

				IDictionaryEnumerator ienum = sdEntities.GetEnumerator();

				while (ienum.MoveNext())
				{
					if (ienum.Value.ToString().ToLower().Trim() == entityName.ToLower().Trim())
					{
						entityId = Convert.ToInt32(ienum.Key);
						break;
					}
				}

				if (entityId == -1)
				{
					throw new ArgumentException("Invalid entity name");
				}

				//initialize the user rights 
				UserRights usr = new UserRights(false, false, false, false, string.Empty);
				StringBuilder sbuild = new StringBuilder();

				QueryCriteria qc = new QueryCriteria(entityUserRights);
				qc.Add(CriteriaOperator.Equality, entityUserRights.GetField("UserId"), userId);
				qc.Add(CriteriaOperator.Equality, entityUserRights.GetField("EntityId"), entityId);

				EntityUserRightsTableMetadata[] list = (EntityUserRightsTableMetadata[]) entityUserRightsPersistent.GetTableMetadata(qc);

				for (int i = 0; i < list.Length; i++)
				{
					if (list[i].UserRightsId == UserRightView)
					{
						usr.AllowView = list[i].Flag;
					}
					else if (list[i].UserRightsId == UserRightInsert)
					{
						usr.AllowAdd = list[i].Flag;
					}
					else if (list[i].UserRightsId == UserRightDelete)
					{
						usr.AllowDelete = list[i].Flag;
					}
					else if (list[i].UserRightsId == UserRightUpdate)
					{
						usr.AllowEdit = list[i].Flag;
					}
					else
					{
						sbuild.Append(GetUserRightName(list[i].UserRightsId) + "=" + (Convert.ToInt32(list[i].Flag)));
					}
				}

				return usr;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private static string GetUserRightName(int id)
		{
			IDictionaryEnumerator ienum = sdUserRights.GetEnumerator();

			while (ienum.MoveNext())
			{
				if (ienum.Key == (object) id)
				{
					return ienum.Value.ToString();
				}
			}

			return "";
		}
	}
}