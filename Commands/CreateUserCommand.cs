﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf_mvvm_exercise.Models;
using wpf_mvvm_exercise.Services;
using wpf_mvvm_exercise.ViewModels;

namespace wpf_mvvm_exercise.Commands
{
    public class CreateUserCommand : CommandBase
    {
        private readonly Forum forum;
        private readonly NavigationService userListNavigationService;
        private readonly MakeUserViewModel makeUserViewModel;

        public CreateUserCommand(MakeUserViewModel makeUserViewModel, Forum forum, NavigationService userListNavigationService)
        {
            this.makeUserViewModel = makeUserViewModel;
            this.forum = forum;
            this.userListNavigationService = userListNavigationService;
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
            if (makeUserViewModel.LoginName.Length <= 4)
            {
                MessageBox.Show("The Login Name must be larger than 4 characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (makeUserViewModel.DisplayName.Length <= 4)
            {
                MessageBox.Show("The Display Name must be larger than 4 characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (makeUserViewModel.Password.Length <= 8)
            {
                MessageBox.Show("The Password must be larger than 8 characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!makeUserViewModel.Password.Equals(makeUserViewModel.ConfirmPassword))
            {
                MessageBox.Show("The two passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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

                this.userListNavigationService.Navigate();
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
