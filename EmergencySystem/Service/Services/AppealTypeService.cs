
using Domain.Entities.AppealTypeModels;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AppealTypeService : GenericService<AppealType>, IAppealTypeService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public AppealTypeService(AppDbContext context, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<AppealType>> GetAllWithTranslates()
        {
            var currentUser = await _currentUserService.GetCurrentUser();
            return await _context.AppealTypes.Include(x => x.Translates.Where(m => m.LangCode == currentUser.LangCode)).ToListAsync();
        }

        public async Task<List<AppealType>> GetAllWithId(List<int> ids)
        {
            return await _context.AppealTypes.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
