/*

      file : IEntityLoader.cs
description: Interface which describes the implementation of the entity loaders
     author: Marius Gheorghe 
                            
  
*/

using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Interface which describes the implementation of the entity loaders
	/// </summary>
	internal interface IEntityLoader
	{
		void LoadEntity(string entityName, string assemblyPath, Form parentWindow, params object[] args);
	}
}