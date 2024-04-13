using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_exercise.Models;
using wpf_mvvm_exercise.Services;
using wpf_mvvm_exercise.Stores;
using wpf_mvvm_exercise.ViewModels;

namespace wpf_mvvm_exercise.Commands
{
    public class NavigationCommand : CommandBase
    {
        private readonly NavigationService navigationService;

        public NavigationCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            navigationService.Navigate();
        }
    }
}
