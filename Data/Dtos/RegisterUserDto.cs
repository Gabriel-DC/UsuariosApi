using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
