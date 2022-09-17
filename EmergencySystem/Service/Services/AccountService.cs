using Domain.Entities.AppUSerModels;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.Register;
using Service.Helpers.Token;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IToken _tokenService;
        public AccountService(UserManager<AppUser> userManager, IToken tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) return null;

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return null;
            var roles = await _userManager.GetRolesAsync(user);

            string token = _tokenService.CreateToken(user.Email, user.UserName, (List<string>)roles);
            return token;

        }

        public async Task Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                DeviceLang = registerDto.DeviceLang,
                UserDataFIN = registerDto.UserDataFIN
            };
            await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, "Consumer");
        }



        public async Task AddUserToRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return;

            await _userManager.AddToRoleAsync(user, role);
        }

    }
}
