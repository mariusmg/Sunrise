using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class EntityPersistentObject : PersistentObject
	{
		public EntityPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base(database, connectionString, mainTable)
		{
		}

		public EntityPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
	}
}