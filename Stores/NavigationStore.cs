﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_exercise.ViewModels;

namespace wpf_mvvm_exercise.Stores
{
    public class NavigationStore
    {
        private ViewModelBase? currentViewModel;

        public ViewModelBase? CurrentViewModel 
        {
            get { return currentViewModel;} 
            set 
            { 
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action? CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
