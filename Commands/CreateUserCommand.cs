using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf_mvvm_exercise.Models;
using wpf_mvvm_exercise.ViewModels;

namespace wpf_mvvm_exercise.Commands
{
    public class CreateUserCommand : CommandBase
    {
        private readonly Forum forum;
        private readonly MakeUserViewModel makeUserViewModel;

        public CreateUserCommand(MakeUserViewModel makeUserViewModel, Forum forum)
        {
            this.makeUserViewModel = makeUserViewModel;
            this.forum = forum;

            makeUserViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //Conditionals that determine if the button does anything / is enabled
        public override bool CanExecute(object? parameter)
        {
            return 
                !string.IsNullOrEmpty(makeUserViewModel.LoginName) &&
                !string.IsNullOrEmpty(makeUserViewModel.DisplayName) &&
                !string.IsNullOrEmpty(makeUserViewModel.Password) &&
                !string.IsNullOrEmpty(makeUserViewModel.ConfirmPassword) &&
                base.CanExecute(parameter);
        }

        //The logic that occurs when the button attached to this command is pressed
        public override void Execute(object? parameter)
        {
            User user = new User(
                makeUserViewModel.LoginName,
                makeUserViewModel.Password,
                makeUserViewModel.DisplayName,
                makeUserViewModel.Role
                );

            bool wasAdded = forum.AddUser( user );

            if ( !wasAdded )
            {
                MessageBox.Show("A user already exists with this information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            else
            {
                MessageBox.Show("User successfully added!", "Success", MessageBoxButton.OK);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ( 
                e.PropertyName ==  nameof(makeUserViewModel.LoginName) ||
                e.PropertyName == nameof(makeUserViewModel.DisplayName) ||
                e.PropertyName == nameof(makeUserViewModel.Password) ||
                e.PropertyName == nameof(makeUserViewModel.ConfirmPassword)
                )
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
