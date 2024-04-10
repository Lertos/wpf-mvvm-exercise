namespace wpf_mvvm_exercise.Models
{
    public class Category
    {
        private const int MaxTitleLength = 30;
        private const int MaxDescriptionLength = 100;

        private string title;
        private string description;
        public bool locked { get; set; } = false;
        public bool only_admin_visible { get; set; } = false;
        public bool only_mod_visible { get; set; } = false;
        public List<Thread> threads { get; } = new List<Thread>();

        public Category(string title, string description)
        {
            this.title = title;
            this.description = description;
        }

        public string Title
        {
            get { return title; }
            set { title = value.Substring(0, MaxTitleLength); }
        }

        public string Description
        {
            get { return description; }
            set { description = value.Substring(0, MaxDescriptionLength); }
        }

        public bool AddNewThread(Thread thread)
        {
            foreach (var item in threads)
            {
                if (thread.Title.ToLower().Equals(item.Title.ToLower()))
                    return false;
            }

            threads.Add(thread);
            return true;
        }

        public bool DeleteThread(Thread thread)
        {
            foreach (var item in threads)
            {
                if (item.Equals(thread))
                {
                    threads.Remove(thread);
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Category category = (Category)obj;
            return this.GetHashCode() == category.GetHashCode();
        }

        public override int GetHashCode()
        {
            return title.GetHashCode() + description.GetHashCode();
        }
    }
}
