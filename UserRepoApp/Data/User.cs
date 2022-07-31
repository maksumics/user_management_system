using System.ComponentModel.DataAnnotations;

namespace UserRepoApp.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public string Status { get; set; }
        [Required]
        public string Password { get; set; }

        public byte[] PwSalt { get; set; }

        public IList<Permission> Permissions { get; set; }
    }
}
