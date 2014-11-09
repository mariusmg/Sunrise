using voidsoft.DataBlock;

namespace ExtenderTest
{
	public class TestPersistentObject : PersistentObject
	{
		public TestPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base(database, connectionString, mainTable)
		{
		}

		public TestPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
	}
}