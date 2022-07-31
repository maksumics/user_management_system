using Microsoft.EntityFrameworkCore;
using UserRepoApp.Models;

namespace UserRepoApp.Data
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly UserContext _userContext;

        public PermissionRepository(UserContext userContext)
        {
            _userContext = userContext; 
        }

        public async Task<IList<Permission>> AssignPermission(int userId, int permissionId)
        {
            var user = await _userContext.Users.Include(p=>p.Permissions).FirstOrDefaultAsync(u=>u.Id == userId);
            var permission = await _userContext.Permissions.Include(u=>u.Users).FirstOrDefaultAsync(p=>p.Id == permissionId);
            if (user != null && permission != null)
            {
                if (user.Permissions == null)
                    user.Permissions = new List<Permission>();
                if (permission.Users.Contains(user))
                    return null;
                user.Permissions.Add(permission);
                await _userContext.SaveChangesAsync();
                return user.Permissions.ToList();
            }
            else
                return null;
        }

        public async Task<Permission> CreatePermission(Permission permission)
        {
            var existing = await _userContext.Permissions.FirstOrDefaultAsync(p => p.Code == permission.Code);
            if (existing == null)
            {
                var created = await _userContext.Permissions.AddAsync(permission);
                await _userContext.SaveChangesAsync();
                return created.Entity;
            }
            else
                return null;
        }

        public async Task<IList<Permission>> GetPermissionsForUser(int id)
        {
            var user = _userContext.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
                return await _userContext.Permissions.Where(p => p.Users.Contains(user)).ToListAsync();
            else
                return null;
        }

        public async Task<IList<Permission>> RemovePermission(int userId, int permissionId)
        {
            var user = await _userContext.Users.Include(p => p.Permissions).FirstOrDefaultAsync(u => u.Id == userId);
            var permission = await _userContext.Permissions.Include(u => u.Users).FirstOrDefaultAsync(p => p.Id == permissionId);
            if (user != null && permission != null)
            {
                user.Permissions.Remove(permission);
                await _userContext.SaveChangesAsync();
                return user.Permissions.ToList();
            }
            else
                return null;
        }
    }
}
