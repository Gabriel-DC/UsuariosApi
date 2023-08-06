using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;

        public UserService(
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginUserDto loginUserDto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);

            if (!result.Succeeded)
                throw new AuthenticationException("Autenticação falhou");

            User user = _signInManager
            .UserManager
            .Users
            .First(u => u.NormalizedUserName == loginUserDto.Username.ToUpper());

            string token = _tokenService.GenerateToken(user);

            return token;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterUserDto registerUserDto)
        {
            User user = _mapper.Map<User>(registerUserDto);

            IdentityResult result = await _userManager.CreateAsync(user, registerUserDto.Password);

            return result;
        }
    }
}
