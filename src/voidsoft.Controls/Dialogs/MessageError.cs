using System;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Summary description for MessageError.
	/// </summary>
	public class MessageError
	{
		/// <summary>
		/// 
		/// </summary>
		private MessageError()
		{
		}

		/// <summary>
		/// Displays an error message dialog
		/// </summary>
		/// <param name="captionText"></param>
		/// <param name="errorMessage"></param>
		/// <param name="details"></param>
		public static void Show(string captionText, string errorMessage, string details)
		{
			ErrorDialog error = null;

			try
			{
				error = new ErrorDialog();
				error.textBoxDetails.Text = details;
				error.textBoxError.Text = errorMessage;
				error.Text = captionText;
				error.ShowDialog();
			}
			catch (Exception ex)
			{
				//this should never happen :))
			}
			finally
			{
				if (error != null)
				{
					error.Dispose();
				}
			}
		}
	}
}