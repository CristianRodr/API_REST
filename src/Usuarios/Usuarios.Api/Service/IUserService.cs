

using Usuarios.Api.Models;

namespace Usuarios.Api.Service;

public interface IUserService
{
    Task<UserModel> GetUserById(Guid id);
    Task<UserModel> CreateUser(UserModel user);
    Task<UserModel> UpdateUser(UserModel user);
    Task<bool> DeleteUser(Guid id);        
}        
