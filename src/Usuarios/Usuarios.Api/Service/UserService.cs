using Usuarios.Api.Models;

namespace Usuarios.Api.Service;

public class UserService : IUserService
{
    private readonly Dictionary<Guid, UserModel> _users = new();
    public Task<UserModel> CreateUser(UserModel user)
    {
        user.Id = Guid.NewGuid();
        _users[user.Id] = user;
        return Task.FromResult(user);
    }

    public Task<bool> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> UpdateUser(UserModel user)
    {
        throw new NotImplementedException();
    }
}        
