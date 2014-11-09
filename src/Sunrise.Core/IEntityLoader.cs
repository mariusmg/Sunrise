/*

      file : IEntityLoader.cs
description: Interface which describes the implementation of the entity loaders
     author: Marius Gheorghe 
                            
  
*/

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Interface which describes the implementation of the entity loaders
	/// </summary>
	internal interface IEntityLoader
	{
		void LoadEntity(params object[] args);
	}
}