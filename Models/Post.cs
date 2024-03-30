namespace wpf_mvvm_exercise.Models
{
    internal class Post
    {
        public string content { get; private set; }
        public User ownedBy { get; }
        public DateTime createDate { get; }
        public Dictionary<int, bool> upvotes { get; }
        public Dictionary<int, bool> downvotes { get; }
        public Post(string content, User ownedBy)
        {
            this.content = content;
            this.ownedBy = ownedBy;
            this.upvotes = new Dictionary<int, bool>();
            this.downvotes = new Dictionary<int, bool>();
        }

        public void EditContent(string content)
        {
            this.content = content;
        }

        public void AddUpvote(int userID)
        {
            this.upvotes[userID] = true;
        }

        public void RemoveUpvote(int userID)
        {
            if (this.upvotes.ContainsKey(userID))
            {
                this.upvotes.Remove(userID);
            }
        }

        public void AddDownvote(int userID)
        {
            this.downvotes[userID] = true;
        }

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


    }

}
