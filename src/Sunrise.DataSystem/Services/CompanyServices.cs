using System;
using System.Collections;
using voidsoft.DataBlock;
using voidsoft.Sunrise.Core;

namespace voidsoft.Sunrise.DataSystem
{
	/// <summary>
	/// CompanyServices
	/// </summary>
	public class CompanyServices
	{
		private static CompanyTableMetadata company;
		private static CompanyPersistentObject companyPersistent;

		static CompanyServices()
		{
			company = new CompanyTableMetadata();
			companyPersistent = new CompanyPersistentObject(SharedData.SystemServerType, SharedData.SystemConnectionString, company);
		}

		/// <summary>
		/// Gets the company list.
		/// </summary>
		/// <returns></returns>
		public static SortedList GetCompaniesList()
		{
			SortedList sdValue = null;

			try
			{
				sdValue = companyPersistent.GetFieldList(company.TableFields[0], company.TableFields[1]);
				return sdValue;
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="companyId"></param>
		/// <param name="name"></param>
		/// <param name="address"></param>
		/// <param name="connectionString"></param>
		/// <param name="logoPath"></param>
		/// <param name="serverType"></param>
		public static void GetCompanyDetails(ref int companyId, ref string name, ref string address, ref string connectionString, ref string logoPath, ref int serverType)
		{
			try
			{
				CompanyTableMetadata cmp = (CompanyTableMetadata) companyPersistent.GetTableMetadata(companyId);

				name = cmp.Name;
				connectionString = cmp.ConnectionString;
				serverType = cmp.ServerType;

				if (!cmp.IsNull("Address"))
				{
					address = cmp.Address;
				}
				else
				{
					address = string.Empty;
				}

				if (!cmp.IsNull("Logo"))
				{
					logoPath = cmp.Logo;
				}
				else
				{
					logoPath = string.Empty;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Updates the company info
		/// </summary>
		/// <param name="comp"></param>
		public static void UpdateCompanyData(CompanyTableMetadata companyData)
		{
			companyPersistent.Update(companyData);
		}

		/// <summary>
		/// Checks if the specified user name already exists
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public static bool IsCompanyName(string companyName)
		{
			try
			{
				QueryCriteria qc = new QueryCriteria(company);
				qc.Add(CriteriaOperator.Equality, company.TableFields[1], companyName);

				CompanyTableMetadata[] usr = (CompanyTableMetadata[]) companyPersistent.GetTableMetadata(qc);

				if (usr.Length == 0)
				{
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.LogError("IsUserName " + ex.Message);

				return true;
			}
		}
	}
}