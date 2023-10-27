using Messanger.Dtos;
using Messanger.Interfaces;

namespace Messanger.Repositories;

public class MessageRepository : IMessageRepository
{
    public Task<int> CreateAsync(MessageDto entity)
    {

    }

    public Task<int> DeepDeletedAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Message>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Message> GetAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(int id, MessageDto entity)
    {
        throw new NotImplementedException();
    }
}
