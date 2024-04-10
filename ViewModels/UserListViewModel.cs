using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_mvvm_exercise.Enums;
using wpf_mvvm_exercise.Models;

namespace wpf_mvvm_exercise.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {

        private readonly ObservableCollection<UserViewModel> _users;

        public IEnumerable<UserViewModel> Users => _users;

        public ICommand CreateUserCommand { get; }

        public UserListViewModel()
        {
            _users = new ObservableCollection<UserViewModel>();

            //TODO: Remove - simply for testing
            _users.Add(new UserViewModel(new User("jackson", "123pass", "Jack Son", Role.MEMBER)));
            _users.Add(new UserViewModel(new User("anthoney", "pass123", "Ant Honey", Role.MOD)));
        }
    }
}
