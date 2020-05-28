using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
	/// <summary>
	/// Converts a StockWithBorrow object
	/// to a string that makes sense for the check in view
	/// Basicly lists stockId and stock status with the Due Date.
	/// 'Ex. 12. Återlämningsdatum 2020-12-12'
	/// </summary>
    public class StockWithBorrowToCheckInStrConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var convertObject = (StockWithBorrow)value;
            string retStr = "Ex. " + convertObject.StockID + ".";
			if (convertObject.UsersID == 0)
				retStr += " Finns i lagret";
			else
			{
				retStr += " Återlämningsdatum: " + convertObject.DueDate;
				if (convertObject.DueDate > DateTime.Now)
					retStr += " (Försenad)";
			}
			return retStr;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
