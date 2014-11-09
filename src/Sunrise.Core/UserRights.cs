/*

   	   file: UserRights
description: contains the user rights for a specified entity. Additional user rights
             can be specified. 
	 author: Marius Gheorghe

*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Describes the user rights for a specified module.
	/// </summary>
	public class UserRights
	{
		//the "other settings" format for user rights is
		//[User Rights Name] = [Value (true | false)];

		private bool allowAdd;

		public bool AllowAdd
		{
			get
			{
				return allowAdd;
			}

			set
			{
				allowAdd = value;
			}
		}

		private bool allowEdit;

		public bool AllowEdit
		{
			get
			{
				return allowEdit;
			}

			set
			{
				allowEdit = value;
			}
		}

		private bool allowDelete;

		public bool AllowDelete
		{
			get
			{
				return allowDelete;
			}

			set
			{
				allowDelete = value;
			}
		}

		private bool allowView;

		public bool AllowView
		{
			get
			{
				return allowView;
			}

			set
			{
				allowView = value;
			}
		}

		public string OtherRights;

		private Dictionary<string, string> dict;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="AllowAdd"></param>
		/// <param name="AllowEdit"></param>
		/// <param name="AllowDelete"></param>
		/// <param name="AllowView"></param>
		/// <param name="otherRights"></param>
		public UserRights(bool AllowAdd, bool AllowEdit, bool AllowDelete, bool AllowView, string otherRights)
		{
			this.AllowAdd = AllowAdd;
			this.AllowDelete = AllowDelete;
			this.AllowEdit = AllowEdit;
			this.AllowView = AllowView;
			OtherRights = otherRights;

			dict = new Dictionary<string, string>();

			if (otherRights != string.Empty)
			{
				ParseAdditionalData();
			}
		}

		public UserRights()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userRightName"></param>
		/// <returns></returns>
		public bool GetUserRight(string userRightName)
		{
			foreach (KeyValuePair<string, string> vc in dict)
			{
				if (vc.Key.ToLower() == userRightName)
				{
					if (vc.Value.ToLower() == "true")
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// PArse additional user rights
		/// </summary>
		internal void ParseAdditionalData()
		{
			try
			{
				string[] data = OtherRights.Split(';');

				foreach (string current in data)
				{
					string[] values = Regex.Split(current, "=");

					if (values.Length == 2)
					{
						dict.Add(values[0], values[1]);
					}
				}
			}
			catch (Exception ex)
			{
				Log.LogError(ex);
			}
		}
	}
}