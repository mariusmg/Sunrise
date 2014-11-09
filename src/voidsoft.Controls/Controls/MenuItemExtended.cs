

using System;
using System.Drawing;
using System.Windows.Forms;


namespace voidsoft.Controls
{

	public class MenuItemExtended  : System.Windows.Forms.MenuItem
	{
		
		private string _caption;
		private Bitmap _bmp;

		
		public MenuItemExtended()   : base()
		{
		}


		public MenuItemExtended(string caption)
		{
			this._caption = caption;
		}

		public MenuItemExtended(string caption, Bitmap bmp)
		{

		}

	
	}
}
