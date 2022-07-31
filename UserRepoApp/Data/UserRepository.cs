using Microsoft.EntityFrameworkCore;
using UserRepoApp.Services;

namespace UserRepoApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        private readonly IPasswordService _passwordService;
        public UserRepository(UserContext userContext, IPasswordService passwordService)
        {
            _userContext = userContext;
            _passwordService = passwordService;
        }
        public async Task<User> AddUser(User user)
        {
            var existing = await _userContext.Users.FirstOrDefaultAsync(u=>u.Username==user.Username);
            if (existing == null)
            {
                var hash = _passwordService.EncryptPassword(user.Password);
                user.Password = hash.Hash;
                user.PwSalt = hash.Salt;
                user.CreatedAt = DateTime.UtcNow;
                user.LastLogin = DateTime.UtcNow;
                var created = await _userContext.Users.AddAsync(user);
                await _userContext.SaveChangesAsync();
                return created.Entity;
            }
            else
                return null;
        }

        public void DeleteUser(int userId)
        {
            var userToDelete =  _userContext.Users.FirstOrDefault(u=>u.Id == userId);
            if(userToDelete != null)
            {
                _userContext.Users.Remove(userToDelete);
                _userContext.SaveChanges();
            }
        }

        public async Task<User> GetUser(int userId)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize)
        {
            return await _userContext.Users.Skip<User>(pageNumber*pageSize).Take<User>(pageSize).OrderByDescending(u=>u.Id).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var userToUpdate = await _userContext.Users.FirstOrDefaultAsync(u=>u.Id == user.Id);
            if(userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.Status = user.Status;
                await _userContext.SaveChangesAsync();
                return userToUpdate;
            }
            return null;
        }
    }
}
