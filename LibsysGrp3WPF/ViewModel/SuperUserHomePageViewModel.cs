using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LibsysGrp3WPF
{
    public class SuperUserHomePageViewModel : BaseViewModel, IPageViewModel
    {
        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("here I am");
        }
    }
}
