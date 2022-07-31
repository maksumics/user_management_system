using UserRepoApp.Models;

namespace UserRepoApp.Data
{
    public interface IPermissionRepository
    {
        Task<IList<Permission>> GetPermissionsForUser(int id);
        Task<IList<Permission>> AssignPermission(int userId, int permissionId);
        Task<IList<Permission>> RemovePermission(int userId, int permissionId);
        Task<Permission> CreatePermission(Permission permission);
    }
}
