using Messanger.Dtos;
using Messanger.Models;

namespace Messanger.Interfaces;

public interface IUserRepository : IRepository<User, UserDto>
{
}
