/*

      file : AttributeEntityLoader.cs
description: EntityLoader based 
     author: Marius Gheorghe

  
arguments :  1. - path of the entity file.
             2. - window parent 

*/

using System;
using System.Reflection;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// 
	/// </summary>
	public class DefaultWindowEntityLoader : IEntityLoader
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityName"></param>
		/// <param name="assemblyPath"></param>
		/// <param name="parentWindow"></param>
		/// <param name="args"></param>
		public void LoadEntity(string entityName, string assemblyPath, Form parentWindow, params object[] args)
		{
			Form parentForm = null;

			try
			{
				Assembly asm = Assembly.LoadFrom(assemblyPath);

				Type[] types = asm.GetTypes();

				//check if we  have a parent window
				if (args.Length > 1)
				{
					parentForm = (Form) args[1];
				}

				Type windowType = null;

				foreach (Type tip in types)
				{
					if (tip.IsClass)
					{
						object[] customAttributes = tip.GetCustomAttributes(typeof (DefaultWindowAttribute), false);

						if (customAttributes.Length > 0)
						{
							windowType = tip;
							break;
						}
					}
				}

				if (windowType == null)
				{
					throw new InvalidOperationException("The attribute DefaultWindow was not found");
				}

				Form form = (Form) Activator.CreateInstance(windowType);
				form.Owner = parentForm;
				form.Show();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}