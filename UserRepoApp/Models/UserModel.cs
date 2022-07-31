using System.ComponentModel.DataAnnotations;

namespace UserRepoApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
