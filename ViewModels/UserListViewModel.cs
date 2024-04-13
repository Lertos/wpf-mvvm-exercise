using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_mvvm_exercise.Commands;
using wpf_mvvm_exercise.Enums;
using wpf_mvvm_exercise.Models;
using wpf_mvvm_exercise.Services;
using wpf_mvvm_exercise.Stores;

namespace wpf_mvvm_exercise.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {

        private readonly ObservableCollection<UserViewModel> users;
        private readonly Forum forum;

        public IEnumerable<UserViewModel> Users => users;

        public ICommand CreateUserCommand { get; }

        public UserListViewModel(Forum forum, NavigationService navigationService)
        {
            CreateUserCommand = new NavigationCommand(navigationService);

            this.forum = forum;
            this.users = new ObservableCollection<UserViewModel>();

            UpdateUsers();
        }

        private void UpdateUsers()
        {
            users.Clear();

            foreach (var item in forum.users)
            {
                UserViewModel userViewModel = new UserViewModel(item);
                users.Add(userViewModel);
            }
        }
    }
}
