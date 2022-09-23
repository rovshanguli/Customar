using Domain.Entities.AppUSerModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Register;
using Service.Helpers.Token;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context; 
        private readonly IToken _tokenService;
        public AccountService(UserManager<AppUser> userManager, IToken tokenService, AppDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user is null) return null;

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return null;
            var roles = await _userManager.GetRolesAsync(user);

            string token = _tokenService.CreateToken(user , (List<string>)roles);
            return token;

        }

        public async Task<AppUser> GetUser(string id)
        {
            var user = _userManager.Users.Include(c => c.UserData);
            return await user.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {

                UserName = registerDto.Username,
                DeviceLang = "az",
                UserDataFIN = string.IsNullOrWhiteSpace(registerDto.UserDataFIN) ? null : registerDto.UserDataFIN
            };
            var userCreateResult = await _userManager.CreateAsync(user, registerDto.Password);
           
            if (userCreateResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Consumer");
            }
           
        }



        public async Task AddUserToRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return;

            await _userManager.AddToRoleAsync(user, role);
        }

    }
}
