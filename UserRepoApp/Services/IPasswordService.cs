namespace UserRepoApp.Services
{
    public interface IPasswordService
    {
        public HashSalt EncryptPassword(string password);
        public bool CheckPassword(string enteredPassword, byte[] salt, string storedPassword);
    }
}
