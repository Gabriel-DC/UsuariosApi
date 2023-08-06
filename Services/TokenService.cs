﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class TokenService
{
    internal void GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("id",  user.Id),
            new Claim("username", user.UserName!),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9SHA8SHA7SHA6SHA00"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials
            );

        //return token;
    }
}