/*
	
	  file : EventManager.cs
description: Geenric App domain wide event handler.
	author : Marius Gheorghe


*/

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// System wide event manager
	/// </summary>
	public class EventManager
	{
		/// <summary>
		/// Private constructor to prevent instantiating
		/// </summary>
		private EventManager()
		{
		}

		/// <summary>
		/// Delegate used to handle the EventDispatcher event.
		/// </summary>
		public delegate void DispatcherEventHandler(string eventIdentifier, params object[] values);

		/// <summary>
		/// System wide event to which the components must subscribe
		/// </summary>
		public static event DispatcherEventHandler EventDispatcher;

		/// <summary>
		/// Dispatch the event to all subscribers
		/// </summary>
		/// <param name="eventIdentifier">The event identifier</param>
		/// <param name="values">Event parameters</param>
		public static void DispatchEvent(string eventIdentifier, params object[] values)
		{
			lock (typeof (EventManager))
			{
				if (EventDispatcher != null)
				{
					EventDispatcher(eventIdentifier, values);
				}
			}
		}
	}
}