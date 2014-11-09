using System;
using System.Data;
using voidsoft.DataBlock;

namespace ExtenderTest
{
	public class TestTableMetadata : TableMetadata
	{
		private DatabaseField[] _fields;

		public TestTableMetadata()
		{
			_fields = new DatabaseField[3];
			_fields[0] = new DatabaseField(DbType.Int32, "Id", true, true, null);
			_fields[1] = new DatabaseField(DbType.String, "Name", false, false, null);
			_fields[2] = new DatabaseField(DbType.Int32, "Age", false, false, null);

			currentTableName = "Test";
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

		public Int32 Age
		{
			get
			{
				return (Int32) (GetField("Age")).fieldValue;
			}

			set
			{
				SetFieldValue("Age", value);
			}
		}
	}
}