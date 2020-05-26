﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public class DeleteSuperuserViewModel : BaseViewModel, IPageViewModel
    {
        private UsersModel _selectedItem;
        private ICommand _buttonRemove;
        private ObservableCollection<UsersModel> _usersList;

        public ObservableCollection<UsersModel> UsersList
        {
            get
            {
                return _usersList;
            }
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }
        public UsersModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ICommand ButtonRemove
        {
            get
            {
                return _buttonRemove ?? (_buttonRemove = new RelayCommand(x =>
                {
                    _selectedItem.RemoveUser();
                    UsersList.Remove(_selectedItem);
                }));
            }
        }

        public DeleteSuperuserViewModel()
        {
            getSuperuser();
        }

        private void getSuperuser()
        {
            // gets all users and filters to all librarians.
            var repo = new LibsysRepo();
            var tempUsersList = repo.GetUsers<Users>().Where(x => x.UsersCategory == (int)UsersCategory.Chieflibrarian);
            UsersList = UsersModel.convertToObservableCollection(tempUsersList);
        }
        public void run()
        {
        }
    }
}