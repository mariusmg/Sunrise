/*

	   file: Entity.cs
description: Base class for creating entities.
	 author: Marius Gheorghe


*/

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Entity base class.
	/// </summary>
	public abstract class Entity
	{
		/// <summary>
		/// Entry point in the entity assembly.
		/// </summary>
		/// <param name="vars"></param>
		public abstract void ExecuteEntity(params object[] vars);

		/// <summary>
		/// Entity name
		/// </summary>
		public abstract string EntityName
		{
			get;
		}
	}
}