using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_exercise.Stores;
using wpf_mvvm_exercise.ViewModels;

namespace wpf_mvvm_exercise.Services
{
    public class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate() 
        {
            this.navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
