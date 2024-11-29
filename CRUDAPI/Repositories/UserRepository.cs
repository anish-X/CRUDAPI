using CRUDAPI.Data;
using CRUDAPI.Repositories.Interface;
using CRUDAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) {
            _context = context;   
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

            public async Task<bool> DeleteAsync(string username)
            {
            //try
            //{
            //    var user = await _context.Users.FirstOrDefaultAsync(name => name.Username == username);
            //    _context.Users.Remove(user);
            //    await _context.SaveChangesAsync();
            //    return true;
            //}
            //catch { return false; }
            // Validate the input
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            try
            {
                // Find the user by username
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    // User not found
                    return false;
                }

                // Remove the user
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (replace with your logging framework)
                Console.WriteLine($"Error deleting user: {ex.Message}");
                throw; // Re-throw the exception to inform the caller
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
