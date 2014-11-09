/*


	   file: Log.cs
description: Error/Exceptions logger.
     author: Marius Gheorghe


*/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// Error messages logger
	/// </summary>
	public class Log
	{
		private static TextWriterTraceListener textWriter;

		/// <summary>
		/// Static constructor
		/// </summary>
		static Log()
		{
			textWriter = new TextWriterTraceListener(Application.StartupPath + @"\log.txt");
			//enable tracing
			Trace.Listeners.Add(textWriter);
		}

		/// <summary>
		/// Log the specified error message.
		/// </summary>
		/// <param name="errorMessage"></param>
		public static void LogError(string errorMessage)
		{
			Trace.WriteLine("");
			Trace.WriteLine("***************************");
			Trace.WriteLine(errorMessage);
			Trace.WriteLine("***************************");
			Trace.WriteLine("");
		}

		/// <summary>
		/// Logs the exception
		/// </summary>
		/// <param name="ex"></param>
		public static void LogError(Exception ex)
		{
			Trace.WriteLine("");
			Trace.WriteLine("***************************");
			Trace.WriteLine(ex.Message + " " + ex.StackTrace);
			Trace.WriteLine("Inner Exception");
			if (ex.InnerException != null)
			{
				Trace.WriteLine(ex.InnerException.Message + " " + ex.InnerException.StackTrace);
			}
			Trace.WriteLine("***************************");
			Trace.WriteLine("");
		}
	}
}