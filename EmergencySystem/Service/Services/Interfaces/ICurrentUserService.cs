using Service.DTOs.User;

namespace Service.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Task<CurrentUserInfoDto> GetCurrentUser();
    }
}
