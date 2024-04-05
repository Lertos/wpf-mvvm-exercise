using System.ComponentModel;

namespace wpf_mvvm_exercise.Enums
{
    public enum Role
    {
        [Description("Member")]
        MEMBER,
        [Description("Moderator")]
        MOD,
        [Description("Admin")]
        ADMIN
    }
}
