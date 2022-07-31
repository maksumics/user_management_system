namespace UserRepoApp.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize);
        Task<User> GetUser(int userId);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
