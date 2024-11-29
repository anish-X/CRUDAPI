using CRUDAPI.Services.Interface;
using CRUDAPI.Model;
using CRUDAPI.DTOs;
using CRUDAPI.Repositories.Interface;


namespace CRUDAPI.Services
{
    public class UserService : IUserService
    {
    
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var user =  await _userRepository.GetByUsernameAsync(username);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User> UpdateUserAsync(string username, UserDto userDto)
        {
            var exisitingUser = await _userRepository.GetByUsernameAsync(username);
                
            exisitingUser.Username = userDto.Username;
            exisitingUser.Id = userDto.Id;
            exisitingUser.Email = userDto.Email;
            exisitingUser.Name = userDto.Name;

            return await _userRepository.UpdateAsync(exisitingUser);
        }

        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Username = userDto.Username,
            };

            return await _userRepository.CreateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with'{username}' not found");
            }

            return await _userRepository.DeleteAsync(username);
        }


    }
}