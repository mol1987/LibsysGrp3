using LibsysGrp3WPF.Model.Items;
using System;
using System.Globalization;
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

            string dueDate = "Förfallodatum: " + convertObject.DueDate.ToString("dd/MM/yyyy");
            string returnDate = "Återlämnades " + convertObject.ReturnDate?.ToString("dd/MM/yyyy");

            if (convertObject.ReturnDate != null)
            {
                //returnDate.Foreground = Brushes.Red;
                return returnDate;
            }
            return dueDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
