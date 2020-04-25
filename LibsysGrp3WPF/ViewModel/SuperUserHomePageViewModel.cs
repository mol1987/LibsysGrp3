using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class SuperUserHomePageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _btnManageVisitor;
        private ICommand _btnManageLibrarian;

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
    }
}
