namespace wpf_mvvm_exercise.Models
{
    internal class Post
    {
        private const int MaxContentLength = 500;

        private string content;
        public User ownedBy { get; }
        private DateTime createDate;
        private DateTime modifiedDate;
        public Dictionary<int, bool> upvotes { get; }
        public Dictionary<int, bool> downvotes { get; }

        public Post(string content, User ownedBy)
        {
            this.content = content;
            this.ownedBy = ownedBy;
            this.createDate = DateTime.Now;
            this.modifiedDate = DateTime.Now;
            this.upvotes = new Dictionary<int, bool>();
            this.downvotes = new Dictionary<int, bool>();
        }

        public string Content
        {
            get { return content; }
            set { content = value.Substring(0, MaxContentLength); }
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

        public void AddUpvote(int userID) => this.upvotes[userID] = true;

        public void RemoveUpvote(int userID)
        {
            if (this.upvotes.ContainsKey(userID))
            {
                this.upvotes.Remove(userID);
            }
        }

        public void AddDownvote(int userID) => this.downvotes[userID] = true;

        public void RemoveDownvote(int userID)
        {
            if (this.downvotes.ContainsKey(userID))
            {
                this.downvotes.Remove(userID);
            }
        }

        public int HasVoted(int userID)
        {
            if (this.upvotes.ContainsKey(userID)) return 1;
            else if (this.downvotes.ContainsKey(userID)) return -1;

            return 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Post other = (Post)obj;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return content.GetHashCode() + ownedBy.GetHashCode();
        }
    }
}
