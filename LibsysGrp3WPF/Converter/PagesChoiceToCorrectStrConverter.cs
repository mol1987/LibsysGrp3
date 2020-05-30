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
                    retStr = "Start sida";
                    break;
                case PagesChoice.pageManageVisitor:
                    retStr = "Hantera besökare";
                    break;
                case PagesChoice.pageReport:
                    retStr = "Rapportera objekt";
                    break;
                case PagesChoice.pageManageBook:
                    retStr = "Hantera objekt";
                    break;
                case PagesChoice.pageManageSeminar:
                    retStr = "Hantera seminarier";
                    break;
                case PagesChoice.pageManageUsers:
                    retStr = "Hantera användare";
                    break;
                case PagesChoice.pageVisitorEditProfil:
                    retStr = "Ändra profil";
                    break;
                case PagesChoice.pageVisitorMyItems:
                    retStr = "Mina lån";
                    break;
                case PagesChoice.pageVisitorSearch:
                    retStr = "Låna objekt";
                    break;
                case PagesChoice.pageVisitorSeminar:
                    retStr = "seminarier";
                    break;
                case PagesChoice.pageManageCheckIn:
                    retStr = "Återlämna objekt";
                    break;
                case PagesChoice.pageManageStock:
                    retStr = "Hantera lager";
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
