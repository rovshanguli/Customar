using Service.DTOs.Register;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDto registerDto);
        Task<string> Login(LoginDto loginDto);
        Task AddUserToRole(string userId, string role);
    }
}
