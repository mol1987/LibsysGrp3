using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class PagesChoiceToCorrectStrConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var convertObject = (PagesChoice)value;
            string retStr = "";
			switch (convertObject)
			{
                case PagesChoice.pageStartView:
                    retStr = "Start Sida";
                    break;
                case PagesChoice.pageManageVisitor:
                    retStr = "Hantera Besökare";
                    break;
                case PagesChoice.pageReport:
                    retStr = "Rapportera Objekt";
                    break;
                case PagesChoice.pageManageBook:
                    retStr = "Hantera Objekt";
                    break;
                case PagesChoice.pageManageSeminar:
                    retStr = "Hantera Seminarier";
                    break;
                case PagesChoice.pageManageUsers:
                    retStr = "Hantera Användare";
                    break;
                case PagesChoice.pageVisitorEditProfil:
                    retStr = "Ändra Profil";
                    break;
                case PagesChoice.pageVisitorMyItems:
                    retStr = "Mina Lån";
                    break;
                case PagesChoice.pageVisitorSearch:
                    retStr = "Låna Objekt";
                    break;
                case PagesChoice.pageVisitorSeminar:
                    retStr = "Seminarier";
                    break;
                case PagesChoice.pageManageCheckIn:
                    retStr = "Återlämna Objekt";
                    break;
                case PagesChoice.pageManageStock:
                    retStr = "Hantera Lager";
                    break;
                default:
                    break;
			}

			return retStr;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
