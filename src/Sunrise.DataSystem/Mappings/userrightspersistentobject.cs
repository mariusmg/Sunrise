using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class UserRightsPersistentObject : PersistentObject
	{
		public UserRightsPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base(database, connectionString, mainTable)
		{
		}

		public UserRightsPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
	}
}