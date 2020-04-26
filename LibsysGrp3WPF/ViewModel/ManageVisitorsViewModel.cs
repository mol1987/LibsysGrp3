using System.Windows.Input;

namespace LibsysGrp3WPF
{
    public class ManageVisitorsViewModel : BaseViewModel, IPageViewModel
    {
        // Button fungerar inte än. Måste göras om
        private ICommand _btnBack;

        public ICommand btnBack
        {
            get
            {
                return _btnBack ?? (_btnBack = new RelayCommand(x =>
                {
                    Mediator.Notify(PagesChoice.pageSuperUserHomepage, "");
                }));
            }
        }
    }
}
