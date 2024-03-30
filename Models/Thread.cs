namespace wpf_mvvm_exercise.Models
{
    internal class Thread
    {
        public string title { get; }
        public string description { get; }
        public DateTime createDate { get; }
        public User ownedBy { get; }
        public bool locked { get; private set; }
        public bool only_admin_visible { get; }
        public bool only_mod_visible { get; }
        public List<Post> posts { get; }

        public Thread(string title, string description, User ownedBy) 
        {
            this.title = title;
            this.description = description;
            this.ownedBy = ownedBy;
            //Set default values
            this.locked = false;
            this.only_admin_visible = false;
            this.only_mod_visible = false;
            this.posts = new List<Post>();
        }

        public void EditThread(Thread thread)
        {
            
        }
    }
}
