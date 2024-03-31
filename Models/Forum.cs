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

        //TODO: Implement Add / Delete methods for Categories
        //TODO: Implement Add / Delete methods for Users
    }
}
