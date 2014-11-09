using System;
using System.Data;
using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class EntityTableMetadata : TableMetadata
	{
		private DatabaseField[] _fields;

		public EntityTableMetadata()
		{
			_fields = new DatabaseField[2];
			_fields[0] = new DatabaseField(DbType.Int32, "Id", false, false, null);
			_fields[1] = new DatabaseField(DbType.String, "Name", false, false, null);

			currentTableName = "Entity";
		}

		public override DatabaseField[] TableFields
		{
			get
			{
				return _fields;
			}
			set
			{
				_fields = value;
			}
		}

		public Int32 Id
		{
			get
			{
				return (Int32) (GetField("Id")).fieldValue;
			}

			set
			{
				SetFieldValue("Id", value);
			}
		}

		public String Name
		{
			get
			{
				return (String) (GetField("Name")).fieldValue;
			}

			set
			{
				SetFieldValue("Name", value);
			}
		}
	}
}