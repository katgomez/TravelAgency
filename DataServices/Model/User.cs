using System.ComponentModel.DataAnnotations;

namespace DataServices.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
