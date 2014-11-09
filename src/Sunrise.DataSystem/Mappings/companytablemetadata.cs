using System;
using System.Data;
using voidsoft.DataBlock;

namespace voidsoft.Sunrise.DataSystem
{
	public class CompanyTableMetadata : TableMetadata
	{
		private DatabaseField[] _fields;

		public CompanyTableMetadata()
		{
			_fields = new DatabaseField[6];
			_fields[0] = new DatabaseField(DbType.Int32, "Id", true, true, null);
			_fields[1] = new DatabaseField(DbType.String, "Name", false, false, null);
			_fields[2] = new DatabaseField(DbType.String, "ConnectionString", false, false, null);
			_fields[3] = new DatabaseField(DbType.Int32, "ServerType", false, false, null);
			_fields[4] = new DatabaseField(DbType.String, "Address", false, false, null);
			_fields[5] = new DatabaseField(DbType.String, "Logo", false, false, null);

			currentTableName = "Company";
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

		public String ConnectionString
		{
			get
			{
				return (String) (GetField("ConnectionString")).fieldValue;
			}

			set
			{
				SetFieldValue("ConnectionString", value);
			}
		}

		public Int32 ServerType
		{
			get
			{
				return (Int32) (GetField("ServerType")).fieldValue;
			}

			set
			{
				SetFieldValue("ServerType", value);
			}
		}

		public String Address
		{
			get
			{
				return (String) (GetField("Address")).fieldValue;
			}

			set
			{
				SetFieldValue("Address", value);
			}
		}

		public String Logo
		{
			get
			{
				return (String) (GetField("Logo")).fieldValue;
			}

			set
			{
				SetFieldValue("Logo", value);
			}
		}
	}
}