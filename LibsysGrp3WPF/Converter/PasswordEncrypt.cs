using System;
using System.Globalization;

namespace LibsysGrp3WPF.Converter
{
    /// <summary>
    /// Encrypt password with * converter
    /// </summary>
    public class PasswordEncrypt
    {
        private static string StoredCleanPassword;

        /// <summary>
        /// String to masked
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string cleanPassword = (string)value;
            string maskedPassword = "";

            foreach (char chr in cleanPassword)
            {
                maskedPassword += "";
            }

            StoredCleanPassword = cleanPassword;

            return maskedPassword;
        }

        /// <summary>
        /// Masked to string
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            // Copy paste bug fix
            if (StoredCleanPassword == null)
                StoredCleanPassword = (string)value;


            string maskedPassword = (string)value;
            string cleanPassword = "";
            // Indexer for the stored password
            int j = 0;

            foreach (char chr in maskedPassword)
            {
                if (chr == '*')
                    cleanPassword += StoredCleanPassword[j];
                else
                    cleanPassword += chr;

                j++;
            }
            return cleanPassword;
        }
    }
}
