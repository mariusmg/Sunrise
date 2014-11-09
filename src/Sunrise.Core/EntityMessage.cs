/*

  
      file : EntityMessage.cs
description: Enumeration with messages which can be send to a entity.
    author : Marius Gheorghe

  

*/

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Enum used to send messages from one module to other.
	/// </summary>
	public enum EntityMessage
	{
		BringToFront,
		Close,
		CustomMessage
	}
}