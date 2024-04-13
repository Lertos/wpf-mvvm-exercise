using System;
using System.Collections.Generic;
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
    public class MakeUserViewModel : ViewModelBase
    {
        private string _loginName;
        public string LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
                OnPropertyChanged(nameof(LoginName));
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private Role _role;
        public Role Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeUserViewModel(Forum forum, NavigationService userListNavigationService)
        {
            SubmitCommand = new CreateUserCommand(this, forum, userListNavigationService);
            CancelCommand = new NavigationCommand(userListNavigationService);
        }
    }
}
