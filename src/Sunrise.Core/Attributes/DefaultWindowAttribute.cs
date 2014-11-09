/*

       file : DefaultWindowAttribute.cs
description : Attribute used to load the default form for a entity.
      author: Marius Gheorghe

 
*/

using System;

namespace voidsoft.Sunrise.Core
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class DefaultWindowAttribute : Attribute
	{
	}
}