using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class SuperUserHomePageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _btnManageVisitor;
        private ICommand _btnManageLibrarian;
        private ICommand _btnManageSuperUser;
        private ICommand _btnReport;
        private ICommand _btnLogout;

        public ICommand btnManageVisitor
        {
            get
            {
                return _btnManageVisitor ?? (_btnManageVisitor = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageManageVisitor, "");
                }));
            }
        }

        public ICommand btnManageLibrarian
        {
            get
            {
                return _btnManageLibrarian ?? (_btnManageLibrarian = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageManageLibrarian, "");
                }));
            }
        }

        public ICommand btnManageSuperUser
        {
            get
            {
                return _btnManageSuperUser ?? (_btnManageSuperUser = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageManageSuperUser, "");
                }));
            }
        }

        public ICommand btnReport
        {
            get
            {
                return _btnReport ?? (_btnReport = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageReport, "");
                }));
            }
        }
        public ICommand btnLogout
        {
            get
            {
                return _btnLogout ?? (_btnLogout = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageStartView, "");
                }));
            }
        }
        public void run()
        {
        }
    }
}
