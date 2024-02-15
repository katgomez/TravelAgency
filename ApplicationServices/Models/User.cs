using System.ComponentModel.DataAnnotations;

namespace WS.DataServices.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
