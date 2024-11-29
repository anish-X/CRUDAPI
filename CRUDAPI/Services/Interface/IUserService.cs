using CRUDAPI.DTOs;
using CRUDAPI.Model;

namespace CRUDAPI.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByUsernameAsync(string username);
        Task<User> CreateUserAsync(UserDto userDto);
        Task<User> UpdateUserAsync(string user, UserDto userDto);
        Task<bool> DeleteUserAsync(string username);

    }
}
