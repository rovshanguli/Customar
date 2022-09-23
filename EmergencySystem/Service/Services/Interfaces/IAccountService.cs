using Domain.Entities.AppUSerModels;
using Service.DTOs.Register;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDto registerDto);
        Task<string> Login(LoginDto loginDto);
        Task<AppUser> GetUser(string id);
        Task AddUserToRole(string userId, string role);
    }
}
