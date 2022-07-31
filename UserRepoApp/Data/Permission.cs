using System.ComponentModel.DataAnnotations;

namespace UserRepoApp.Data
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }

        public IList<User> Users { get; set; }
    }
}
