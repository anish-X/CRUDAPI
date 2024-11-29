using CRUDAPI.Model;

namespace CRUDAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(User user);

        Task<bool> DeleteAsync(string username);

        Task<IEnumerable<User>> GetAllAsync();
    }
}
