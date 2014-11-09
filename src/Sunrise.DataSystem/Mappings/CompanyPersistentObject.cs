using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class CompanyPersistentObject : PersistentObject
	{
		public CompanyPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base(database, connectionString, mainTable)
		{
		}

		public CompanyPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
	}
}