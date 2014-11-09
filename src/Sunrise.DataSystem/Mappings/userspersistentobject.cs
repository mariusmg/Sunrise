using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class UsersPersistentObject : PersistentObject
	{
		public UsersPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base(database, connectionString, mainTable)
		{
		}

		public UsersPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
	}
}