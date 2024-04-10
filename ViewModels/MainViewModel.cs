using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_exercise.Models;

namespace wpf_mvvm_exercise.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(Forum forum)
        {
            CurrentViewModel = new MakeUserViewModel(forum);
        }
    }
}
