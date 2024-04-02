using System.Reflection.Metadata.Ecma335;

namespace wpf_mvvm_exercise.Models
{
    internal class Forum
    {
        private const int MaxTitleLength = 60;

        private string title;
        public List<Category> categories { get; } = new List<Category>();
        public List<User> users { get; } = new List<User>();

        public Forum(string title)
        {
            this.title = title;
        }

        public string Title
        {
            get { return title; }
            set { title = value.Substring(0, MaxTitleLength); }
        }

        public bool AddCategory(Category category)
        {
            foreach (var item in categories)
            {
                if (item.Title.ToLower().Equals(item.Title.ToLower()))
                    return false;
            }

            categories.Add(category);
            return true;
        }

        public bool DeleteCategory(Category category)
        {
            foreach (var item in categories)
            {
                if (this.Equals(item))
                {
                    categories.Remove(category);
                    return true;
                }
            }
            return false;
        }

        public bool AddUser(User user)
        {
            foreach (var item in users)
            {
                if (user.LoginName.ToLower().Equals(item.LoginName.ToLower()) || user.DisplayName.ToLower().Equals(item.DisplayName.ToLower()))
                    return false;
            }

            users.Add(user);
            return true;
        }

        public bool DeleteUser(User user)
        {
            foreach (var item in users)
            {
                if (this.Equals(item))
                {
                    users.Remove(user);
                    return true;
                }
            }
            return false;
        }
    }
}
