using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(LoginUserDto loginUserDto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);

            return result;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterUserDto registerUserDto)
        {
            User user = _mapper.Map<User>(registerUserDto);

            IdentityResult result = await _userManager.CreateAsync(user, registerUserDto.Password);

            return result;
        }
    }
}
