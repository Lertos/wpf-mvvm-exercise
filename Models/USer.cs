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
        private const int MaxLoginNameLength = 32;
        private const int MaxDisplayNameLength = 24;
        private const int MaxPasswordLength = 64;

        public int id { get; }
        private string loginName;
        private string password;
        private string displayName;
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

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value.Substring(0, MaxLoginNameLength); }
        }

        public string Password
        {
            get { return password; }
            set { password = value.Substring(0, MaxPasswordLength); }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value.Substring(0, MaxDisplayNameLength); }
        }

        public void EditRole(Role role) => this.role = role;

        public void AddUpvote() => this.upvotes++;

        public void RemoveUpvote() => this.upvotes--;

        public void AddDownvote() => this.downvotes++;

        public void RemoveDownvote() => this.downvotes--;

        //TODO: Implement HashCode and Equals methods
    }
}
