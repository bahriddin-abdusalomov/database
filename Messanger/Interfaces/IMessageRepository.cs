using Messanger.Dtos;

namespace Messanger.Interfaces;

public interface IMessageRepository : IRepository<Message, MessageDto>
{
}
