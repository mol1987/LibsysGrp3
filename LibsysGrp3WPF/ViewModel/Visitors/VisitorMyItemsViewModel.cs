using System;
using System.Collections.ObjectModel;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class VisitorMyItemsViewModel : BaseViewModel, IPageViewModel
    {
        private ObservableCollection<ItemsModel> _borrowed = new ObservableCollection<ItemsModel>
        {
            new ItemsModel()
            {
                ItemsID = 12,
                ItemType = "book",
                Title = "Sagan om Ringen",
                Description = "Molles favorit",
                Price = 99,
                Date = new DateTime(2020-05-20)
             },
            new ItemsModel()
            {
                ItemsID = 8,
                ItemType = "book",
                Title = "XXX",
                Description = "Jesses favorit",
                Price = 99,
                Date = new DateTime(2020-05-20)
             }
        };

        public ObservableCollection<ItemsModel> borrowed
        {
            get
            {
                return _borrowed;
            }
            set
            {
                _borrowed = value;
                OnPropertyChanged(nameof(borrowed));
            }
        }
    }
}
