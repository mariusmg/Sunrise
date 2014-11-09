using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class EntityUserRightsPersistentObject : PersistentObject
	{
		public EntityUserRightsPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base(database, connectionString, mainTable)
		{
		}

		public EntityUserRightsPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
	}
}