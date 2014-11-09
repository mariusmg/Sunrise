/*

       file: BusinessForm.cs
description: Base class for business UI forms.
     author: Marius Gheorghe.
  
  
  
  
 */

using System.Windows.Forms;

namespace voidsoft.Sunrise.Core
{
	public partial class BusinessForm : Form
	{
		public BusinessForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="args"></param>
		public virtual void ReceiveMessage(EntityMessage msg, params object[] args)
		{
			switch (msg)
			{
				case EntityMessage.BringToFront:
					BringToFront();
					break;
				case EntityMessage.Close:
					Close();
					break;
				case EntityMessage.CustomMessage:
					break;
			}
		}
	}
}