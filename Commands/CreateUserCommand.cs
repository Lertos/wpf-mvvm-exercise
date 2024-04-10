using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public override void Execute(object? parameter)
        {
            User user = new User(
                makeUserViewModel.LoginName,
                makeUserViewModel.Password,
                makeUserViewModel.DisplayName,
                makeUserViewModel.Role
                );

            forum.AddUser( user );
        }
    }
}
