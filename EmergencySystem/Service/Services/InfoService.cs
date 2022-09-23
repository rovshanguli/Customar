using Domain.Entities.InfoModels;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class InfoService : GenericService<Info>, IInfoService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public InfoService(AppDbContext context, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<Info>> GetInfosWithTranslate()
        {
            var currentUser = await _currentUserService.GetCurrentUser();
            var infos = await _context.Infos.Include(x => x.Translates.Where(m => m.LangCode == currentUser.LangCode)).ToListAsync();
            return infos;
        }
    }

}
