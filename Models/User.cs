using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Models
{
    public class User : IdentityUser
    {
        //[Key]
        //[Required]
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public User() : base ()
        {
        }
    }
}
