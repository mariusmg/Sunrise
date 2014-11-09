


using System;
using System.Data;
using voidsoft.DataBlock;

using voidsoft.ObjectWire.DataSystem;



namespace voidsoft.ObjectWire.DataSystem
{
	public class EntityPersistentObject : voidsoft.DataBlock.PersistentObject
	{ 
 
		public EntityPersistentObject(EDatabase database, string connectionString, TableMetadata mainTable) : base (database, connectionString, mainTable) 
		{
		}
      
		public EntityPersistentObject(Session session, TableMetadata mainTable) : base(session, mainTable)
		{
		}
      
	}
}
