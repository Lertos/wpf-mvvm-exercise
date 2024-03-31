namespace wpf_mvvm_exercise.Models
{
    public enum Role
    {
        MEMBER,
        MOD,
        ADMIN
    }

    internal class User
    {
        public int id { get; }
        public string loginName { get; }
        public string password { get; private set; }
        public string displayName { get; private set; }
        public Role role { get; private set; }
        public int upvotes { get; private set; } = 0;
        public int downvotes { get; private set; } = 0;

        public User (int id, string loginName, string password, string displayName, Role role)
        {
            this.id = id;
            this.loginName = loginName;
            this.password = password;
            this.displayName = displayName;
            this.role = role;
        }

        public void EditDisplayName(string displayName) => this.displayName = displayName;

        public void EditPassword(string password) => this.password = password;

        public void EditRole(Role role) => this.role = role;

        public void AddUpvote() => this.upvotes++;

        public void RemoveUpvote() => this.upvotes--;

        public void AddDownvote() => this.downvotes++;

        public void RemoveDownvote() => this.downvotes--;
    }
}
