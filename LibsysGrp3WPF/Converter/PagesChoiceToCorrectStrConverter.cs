using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
	/// <summary>
	/// Converts a PagesChoice enum to a string that makes sense to
	/// the user.
	/// </summary>
    public class PagesChoiceToCorrectStrConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var convertObject = (PagesChoice)value;
            string retStr = "";
			retStr = Mediator.PagesChoiceToStringName[convertObject];

			return retStr;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
