using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace LibsysGrp3WPF
{
    public class UserCategoryToStr : IValueConverter
    {
		/// <summary>
		/// Converts user categori enum to srting to show user categori as text instead of number.
		/// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var convertObject = (UsersModel)value;
			string retStr = convertObject.UsersCategory.ToString();

            switch (retStr)
            {
				case "0":
                    {
						retStr = "Besökare";
					}
					break;
				case "1":
					{
						retStr = "Bibliotekariet";
					}
					break;
				case "2":
					{
						retStr = "Bibliotekschef";
					}
					break;

            }

            return retStr;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			return null;
		}
    }
}
