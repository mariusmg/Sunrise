using System;
using System.Data;
using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class UserRightsTableMetadata : TableMetadata
	{
		private DatabaseField[] _fields;

		public UserRightsTableMetadata()
		{
			_fields = new DatabaseField[2];
			_fields[0] = new DatabaseField(DbType.Int32, "Id", true, true, null);
			_fields[1] = new DatabaseField(DbType.String, "Name", false, false, null);

			currentTableName = "UserRights";
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

		public String UserRight
		{
			get
			{
				return (String) (GetField("UserRight")).fieldValue;
			}

			set
			{
				SetFieldValue("UserRight", value);
			}
		}
	}
}