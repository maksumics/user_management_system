using AutoMapper;
using UserRepoApp.Data;
using UserRepoApp.Models;

namespace UserRepoApp.MapperProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<User, EditUserModel>();
            CreateMap<EditUserModel, User>();
            CreateMap<User, CreateUserModel>();
            CreateMap<CreateUserModel, User>();
            CreateMap<Permission, PermissionModel>();
            CreateMap<PermissionModel, Permission>();
        }
    }
}
