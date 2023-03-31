namespace DrugBot.Bot.Vk;

internal class VkUser : IVkUser
{
    public long? PeerId { get; }
    public long? UserId { get; }

    public VkUser(long? userId, long? peerId)
    {
        UserId = userId;
        PeerId = peerId;
    }

    public override int GetHashCode() => UserId.GetHashCode();

    public override string ToString() => UserId?.ToString() ?? "";
}