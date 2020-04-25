using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibsysGrp3WPF.Views
{
    /// <summary>
    /// Interaction logic for SuperUserHomePage.xaml
    /// </summary>
    public partial class SuperUserHomePage : Page
    {
        public SuperUserHomePage()
        {
            InitializeComponent();
        }
        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("here I am");
        }
    }
}
