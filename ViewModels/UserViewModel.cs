using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using wpf_mvvm_exercise.Models;

namespace wpf_mvvm_exercise.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _user;

        public int ID => _user.id;
        public string Username => _user.LoginName;
        public string DisplayName => _user.DisplayName;
        public string Role => _user.role.ToString();
        public int Upvotes => _user.upvotes;
        public int Downvotes => _user.downvotes;

        internal UserViewModel(User user)
        {
            _user = user;
        }
    }
}
