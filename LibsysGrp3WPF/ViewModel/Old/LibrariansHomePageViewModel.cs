using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class LibrariansHomePageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _btnBook;
        private ICommand _btnEbook;
        private ICommand _btnSeminar;
        private ICommand _btnManageVisitor;
        private ICommand _btnLogout;

        public ICommand btnBook
        {
            get
            {
                return _btnBook ?? (_btnBook = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageManageBook, "");
                }));
            }
        }

        public ICommand btnEbook
        {
            get
            {
                return _btnEbook ?? (_btnEbook = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageManageEbook, "");
                }));
            }
        }

        public ICommand btnSeminar
        {
            get
            {
                return _btnSeminar ?? (_btnSeminar = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageManageSeminar, "");
                }));
            }
        }

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

        public ICommand btnLogout
        {
            get
            {
                return _btnLogout ?? (_btnLogout = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.Page1, "");
                }));
            }
        }
        public void run()
        {
        }
    }
}
