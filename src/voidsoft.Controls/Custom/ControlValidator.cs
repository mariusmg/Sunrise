/*

	   file: ControlValidator.cs
	   
description: validates the data entered in the control. The validation is done
			 using the provided attributes (usually these are stored in the 
			 control's tag and are separated by ";"). The attributes can be:
				- required: a text or selected item is required.
				- numeric : the entered/selected text must be numeric.
				- pozitiv : as above but positive.
				
			  	
	 author: Marius Gheorghe


*/

using System;
using System.Windows.Forms;

namespace voidsoft.Sunrise.Controls
{
	/// <summary>
	/// Control validation 
	/// </summary>
	public sealed class ControlValidator
	{
		public const string REQUIRED = "REQUIRED";
		public const string POZITIVE = "POZITIVE";
		public const string NEGATIVE = "NEGATIVE";
		public const string NUMERIC = "NUMERIC";
		public const string INVALID_CHAR = "INVALID CHAR";

		/// <summary>
		/// Private constructor
		/// </summary>
		private ControlValidator()
		{
		}

		/// <summary>
		/// Validates the data entered/selected in a control.
		/// </summary>
		/// <param name="ctl">The validated control </param>
		/// <param name="attributes">The attributes by which the control is validated</param>
		/// <param name="failedAttribute">In case the control does not pass validation this field
		/// holds the name of the attribute for which the validation failed. Is the validation is ok (returns true)
		/// this parameter should be ignored.</param>
		/// <returns></returns>
		public static bool ValidateControl(Control ctl, string attributes, out string failedAttribute)
		{
			//check if we have any attributes
			if (attributes == string.Empty)
			{
				ctl = null;
				failedAttribute = string.Empty;
				return true;
			}

			bool isRequired = false;

			//check the control type

			// text box 
			if (ctl is TextBox)
			{
				string[] attrib = attributes.Split(new[] {';'});

				foreach (string s in attrib)
				{
					//skip the empty attributes
					if (s == string.Empty)
					{
						continue;
					}

					if (s.ToUpper() == REQUIRED)
					{
						isRequired = true;

						if (ctl.Text.Trim().Length == 0)
						{
							failedAttribute = REQUIRED;
							return false;
						}
					}
					else if (s.ToUpper() == POZITIVE)
					{
						if (!IsPozitive(ctl.Text))
						{
							failedAttribute = POZITIVE;
							return false;
						}
					}
					else if (s.ToUpper() == NEGATIVE)
					{
						if (! IsNegative(ctl.Text))
						{
							failedAttribute = NEGATIVE;
							return false;
						}
					}
					else if (s.ToUpper() == NUMERIC)
					{
						if (!IsNumeric(ctl.Text))
						{
							failedAttribute = NUMERIC;
							return false;
						}
					}
				}

				//check for invalid sql chars
				int charIndex = ctl.Text.IndexOf(';');

				if (charIndex > -1)
				{
					failedAttribute = INVALID_CHAR;
					return false;
				}

				charIndex = ctl.Text.IndexOf(@"/'''");

				if (charIndex > -1)
				{
					failedAttribute = INVALID_CHAR;
					return false;
				}

				failedAttribute = string.Empty;
				return true;
			}
				//query control
			if (ctl is QueryControl)
			{
				//only check for required.
				QueryControl qctl = (QueryControl) ctl;

				if (qctl.SelectedValue.Trim().Length == 0)
				{
					failedAttribute = REQUIRED;
					return false;
				}
				failedAttribute = string.Empty;
				return true;
			}
			if (ctl is MultiSelection)
			{
				//required
				MultiSelection selector = (MultiSelection) ctl;

				//required
				if (selector.SelectedValues.Length <= 0)
				{
					failedAttribute = REQUIRED;
					return false;
				}
				failedAttribute = string.Empty;
				return true;
			}
				//checked list box
			if (ctl is CheckedListBox)
			{
				//required
				if (((CheckedListBox) ctl).SelectedItems.Count > 0)
				{
					failedAttribute = string.Empty;
					return true;
				}
				failedAttribute = REQUIRED;
				return false;
			}
			failedAttribute = string.Empty;

			//not implemented
			return false;
		}

		/// <summary>
		/// Validates the data entered/selected in a control.
		/// </summary>
		/// <param name="ctl">The validated control. Is the case the attributes are taken 
		/// from the control's tag</param>
		/// <param name="failedAttribute">In case the control does not pass validation this field
		/// holds the name of the attribute for which the validation failed. Is the validation is ok (returns true)
		/// this parameter should be ignored</param>
		/// <returns></returns>
		public static bool ValidateControl(Control ctl, ref string failedAttribute)
		{
			if (ctl.Tag != null)
			{
				return ValidateControl(ctl, ctl.Tag.ToString(), out failedAttribute);
			}
			return ValidateControl(ctl, "", out failedAttribute);
		}

		/// <summary>
		/// Returns true if the specified string is a number
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private static bool IsNumeric(string text)
		{
			try
			{
				Decimal.Parse(text);
				return true;
			}
			catch (FormatException fex)
			{
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private static bool IsPozitive(string text)
		{
			try
			{
				decimal dval = Decimal.Parse(text);

				if (dval > 0)
				{
					return true;
				}
				return false;
			}
			catch (FormatException fex)
			{
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private static bool IsNegative(string text)
		{
			if (IsPozitive(text) && (Decimal.Parse(text) < 0))
			{
				return true;
			}
			return false;
		}
	}
}