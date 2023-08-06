using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("id",  user.Id),
            new Claim("username", user.UserName!),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
            new Claim("loginUtcTimeStamp", DateTime.UtcNow.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9SHA8SHA7SHA6SHA5SHA4SHA3SHA2SHA1SHA00"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
