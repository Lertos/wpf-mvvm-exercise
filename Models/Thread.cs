namespace wpf_mvvm_exercise.Models
{
    internal class Thread
    {
        public string title { get; private set; }
        public string description { get; private set; }
        public DateTime createDate { get; }
        public User ownedBy { get; }
        public bool locked { get; private set; } = false;
        public bool only_admin_visible { get; } = false;
        public bool only_mod_visible { get; } = false;
        public List<Post> posts { get; } = new List<Post>();

        public Thread(string title, string description, User ownedBy) 
        {
            this.title = title;
            this.description = description;
            this.createDate = DateTime.Now;
            this.ownedBy = ownedBy;
        }

        public void EditTitle(string title) => this.title = title;

        public void EditDescription(string description) => this.description = description;
    }
}
