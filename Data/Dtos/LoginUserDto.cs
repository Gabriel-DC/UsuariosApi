using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class LoginUserDto
    {
        public LoginUserDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
