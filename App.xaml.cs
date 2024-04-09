﻿using System.Configuration;
using System.Data;
using System.Windows;
using wpf_mvvm_exercise.Enums;
using wpf_mvvm_exercise.Models;
using wpf_mvvm_exercise.ViewModels;

namespace wpf_mvvm_exercise
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            /*
            User user1 = new (1, "jackson", "123pass", "Jack Son", Role.MEMBER);
            User user2 = new (2, "anthoney", "pass123", "Ant Honey", Role.MOD);

            Post post1 = new ("I think this website is quite unique!", user1);
            Post post2 = new ("This website seems more like a tutorial for someone to learn something new...", user2);

            Models.Thread thread = new ("Hot Takes", "A place for all your wildest takes.", user1);

            Category category = new("Members Lounge", "A place for members to dicuss topics.");

            Forum forum = new("WPF Forums");

            thread.AddPost(post1);
            thread.AddPost(post2);

            category.AddNewThread(thread);

            forum.AddCategory(category);
            */

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
