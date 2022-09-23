using AutoMapper;
using Service.DTOs.User;
using Service.Services.Interfaces;
using System.Security.Claims;

namespace Web.Services.CurrentUserService
{
    public class CurrentUser : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public CurrentUser(IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IAccountService accountService

            )
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<CurrentUserInfoDto> GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var entity = await _accountService.GetUser(userId);
            var dto = _mapper.Map<CurrentUserInfoDto>(entity);
            dto.LangCode = entity.DeviceLang;
            return dto;
        }
    }
}
