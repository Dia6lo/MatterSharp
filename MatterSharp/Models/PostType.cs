namespace MatterSharp.Models
{
    public enum PostType
    {
        Default,
        SlackAttachment,
        Generic,
        JoinLeave,
        AddRemove,
        HeaderChange,
        DisplayNameChange,
        PurposeChange,
        ChannelDeleted,
        Ephemeral
    }
}