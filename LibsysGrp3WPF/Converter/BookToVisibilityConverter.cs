using LibsysGrp3WPF.Model.Items;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LibsysGrp3WPF
{
    public class BookToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts user categori enum to srting to show user categori as text instead of number.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertObject = (FullBorrowListModel)value;

            if (convertObject.ReturnDate == null)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
