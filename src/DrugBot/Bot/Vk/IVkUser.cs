using DrugBot.Core.Bot;

namespace DrugBot.Bot.Vk;

public interface IVkUser : IUser
{
    long? PeerId { get; }
}