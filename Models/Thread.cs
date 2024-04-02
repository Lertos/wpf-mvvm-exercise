using System.Threading;

namespace wpf_mvvm_exercise.Models
{
    internal class Thread
    {
        private const int MaxTitleLength = 60;
        private const int MaxDescriptionLength = 200;

        private string title;
        private string description;
        private DateTime createDate;
        private DateTime modifiedDate;
        public User ownedBy { get; }
        public bool locked { get; set; } = false;
        public bool only_admin_visible { get; set; } = false;
        public bool only_mod_visible { get; set; } = false;
        public List<Post> posts { get; } = new List<Post>();

        public Thread(string title, string description, User ownedBy) 
        {
            this.title = title;
            this.description = description;
            this.createDate = DateTime.Now;
            this.modifiedDate = DateTime.Now;
            this.ownedBy = ownedBy;
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

        public string CreateDate
        {
            get { return createDate.ToString("dddd, dd MMMM yyyy"); }
        }

        public string ModifiedDate
        {
            get { return modifiedDate.ToString("dddd, dd MMMM yyyy"); }
            set { modifiedDate = DateTime.Now; }
        }

        public bool AddPost(Post post)
        {
            posts.Add(post);
            return true;
        }

        public bool DeletePost(Post post)
        {
            foreach (var item in posts)
            {
                if (item.Equals(post))
                {
                    posts.Remove(post);
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Thread other = (Thread)obj;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return title.GetHashCode() + description.GetHashCode() + ownedBy.GetHashCode() + createDate.GetHashCode();
        }
    }
}
