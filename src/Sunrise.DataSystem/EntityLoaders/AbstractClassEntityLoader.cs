/*


  	   file: EntityLoader.cs
description: Provides entity services.
	 author: Marius Gheorghe 



*/

using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using voidsoft.Sunrise.Core;

namespace voidsoft.Sunrise.DataSystem
{
	/// <summary>
	/// 
	/// </summary>
	public class AbstractClassEntityLoader : IEntityLoader
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityName"></param>
		/// <param name="assemblyName"></param>
		/// <param name="parentWindow"></param>
		public void LoadEntity(string entityName, string assemblyName, Form parentWindow, params object[] args)
		{
			try
			{
				#region check if the entity is loaded

				IEnumerator ienum = SharedData.loadedEntities.Keys.GetEnumerator();
				int index = -1;

				while (ienum.MoveNext())
				{
					++index;

					if (ienum.Current.ToString().ToLower() == entityName.ToLower())
					{
						//see if it's a business form
						try
						{
							BusinessForm cfm = SharedData.loadedEntities[entityName];
							cfm.Visible = true;
							cfm.ReceiveMessage(EntityMessage.BringToFront);
						}
						catch
						{
							//it's not a business form it's a regular window.
							Form form = SharedData.loadedEntities[entityName];
							form.Visible = true;
							form.BringToFront();
						}

						return;
					}
				}

				#endregion

				UserRights user = new UserRights();

				//on debug skip checking the user credentials
#if DEBUG

				user.AllowAdd = true;
				user.AllowDelete = true;
				user.AllowEdit = true;
				user.AllowView = true;
#else
                                      				
	//check the rights for the logged user
			    user = EntityServices.GetEntityUserRights(Int32.Parse(SharedData.UserId), entityName);
#endif

				//check if the user has the view right
				if (user.AllowView)
				{
					InvokeEntity(assemblyName, user, parentWindow);
				}
				else
				{
					throw new ApplicationException("Invalid user rights");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Loads the specified entity without checking the user rights
		/// </summary>
		/// <param name="assemblyName"></param>
		/// <param name="user"></param>
		/// <param name="parentWindow"></param>
		internal void InvokeEntity(string assemblyName, UserRights user, Form parentWindow)
		{
			try
			{
				Assembly asm = Assembly.LoadFrom(Application.StartupPath + @"\" + assemblyName);

				Type[] types = asm.GetTypes();

				foreach (Type type in types)
				{
					if (type.BaseType.Name == "Entity")
					{
						//args
						object[] args = new object[2];
						args[0] = parentWindow;
						args[1] = user;

						object instance = Activator.CreateInstance(type);

						type.InvokeMember("ExecuteEntity", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly, null, instance, args);

						break;
					}
				}

				//normal loader

				//				Type tp = asm.GetType("voidsoft.ObjectWire.Entity", true);
				//		
				//				//args
				//				object[] args = new object[2];
				//				args[0] = parentWindow;
				//				args[1] = user;
				//		
				//				//invoke it
				//				tp.InvokeMember("ExecuteEntity", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public , null, null, args);
			}
			catch (Exception ex)
			{
				//log and rethrow it

				Log.LogError(ex.Message);

				throw ex;
			}
		}
	}
}