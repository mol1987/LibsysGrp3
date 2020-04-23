using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class StartPageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _buttonPage2;
        private ICommand _buttonQuit;

        public ICommand ButtonPage2
        {
            get
            {
                return _buttonPage2 ?? (_buttonPage2 = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.Page2, "");
                }));
            }
        }
        public ICommand ButtonQuit
        {
            get
            {
                return _buttonQuit ?? (_buttonQuit = new RelayCommand(x =>
                {
                    Mediator.CloseApplication();
                }));
            }
        }
    }
}
