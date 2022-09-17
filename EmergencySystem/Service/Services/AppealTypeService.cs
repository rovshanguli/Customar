
using Domain.Entities.AppealTypeModels;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AppealTypeService : GenericService<AppealType>, IAppealTypeService
    {
        private readonly AppDbContext _context;
        public AppealTypeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppealType>> GetAllWithTranslates()
        {
            return await _context.AppealTypes.Include(x => x.Translates).ToListAsync();
        }

        public async Task<List<AppealType>> GetAllWithId(List<int> ids)
        {
            return await _context.AppealTypes.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
