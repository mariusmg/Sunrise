using System;
using System.Data;
using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class EntityUserRightsTableMetadata : TableMetadata
	{
		private DatabaseField[] _fields;

		public EntityUserRightsTableMetadata()
		{
			_fields = new DatabaseField[5];
			_fields[0] = new DatabaseField(DbType.String, "Id", true, true, null);
			_fields[1] = new DatabaseField(DbType.Int32, "EntityId", false, false, null);
			_fields[2] = new DatabaseField(DbType.Int32, "UserRightsId", false, false, null);
			_fields[3] = new DatabaseField(DbType.Int32, "UserId", false, false, null);
			_fields[4] = new DatabaseField(DbType.Boolean, "Flag", false, false, null);

			currentTableName = "EntityUserRights";
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

		public String Id
		{
			get
			{
				return (String) (GetField("Id")).fieldValue;
			}

			set
			{
				SetFieldValue("Id", value);
			}
		}

		public Int32 EntityId
		{
			get
			{
				return (Int32) (GetField("EntityId")).fieldValue;
			}

			set
			{
				SetFieldValue("EntityId", value);
			}
		}

		public Int32 UserRightsId
		{
			get
			{
				return (Int32) (GetField("UserRightsId")).fieldValue;
			}

			set
			{
				SetFieldValue("UserRightsId", value);
			}
		}

		public Int32 UserId
		{
			get
			{
				return (Int32) (GetField("UserId")).fieldValue;
			}

			set
			{
				SetFieldValue("UserId", value);
			}
		}

		public Boolean Flag
		{
			get
			{
				return (Boolean) (GetField("Flag")).fieldValue;
			}

			set
			{
				SetFieldValue("Flag", value);
			}
		}
	}
}