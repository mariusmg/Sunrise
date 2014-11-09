using System;
using System.Data;
using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class UsersTableMetadata : TableMetadata
	{
		private DatabaseField[] _fields;

		public UsersTableMetadata()
		{
			_fields = new DatabaseField[4];
			_fields[0] = new DatabaseField(DbType.Int32, "Id", true, true, null);
			_fields[1] = new DatabaseField(DbType.String, "Name", false, false, null);
			_fields[2] = new DatabaseField(DbType.String, "Password", false, false, null);
			_fields[3] = new DatabaseField(DbType.Boolean, "IsAdmin", false, false, null);

			currentTableName = "Users";

			Relations.Add(new TableRelation("FK_UserRights", "EntityUserRights", "UserId"));
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

		public String Password
		{
			get
			{
				return (String) (GetField("Password")).fieldValue;
			}

			set
			{
				SetFieldValue("Password", value);
			}
		}

		public Boolean IsAdmin
		{
			get
			{
				return (Boolean) (GetField("IsAdmin")).fieldValue;
			}

			set
			{
				SetFieldValue("IsAdmin", value);
			}
		}
	}
}