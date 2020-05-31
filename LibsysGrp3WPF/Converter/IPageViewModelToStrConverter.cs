using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace LibsysGrp3WPF
{
    public class IPageViewModelToStrConverter : IValueConverter
    {
        /// <summary>
        /// Converts user categori enum to srting to show user categori as text instead of number.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string returnStr = "";

            if (value is StartPageViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageStartView];
            } 
            else if (value is ManageVisitorsViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageManageVisitor];
            }
            else if (value is ReportsViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageReport];
            }
            else if (value is ManageBookViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageManageBook];
            }
            else if (value is ManageSeminarViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageManageSeminar];
            }
            else if (value is ManageUsersViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageManageUsers];
            }
            else if (value is VisitorEditProfilViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageVisitorEditProfil];
            }
            else if (value is VisitorMyItemsViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageVisitorMyItems];
            }
            else if (value is VisitorSearchViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageVisitorSearch];
            }
            else if (value is VisitorSeminarViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageVisitorSeminar];
            }
            else if (value is ManageCheckInViewModel)
            {
                returnStr = ">" + Mediator.PagesChoiceToStringName[PagesChoice.pageManageCheckIn];
            }


            return returnStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
