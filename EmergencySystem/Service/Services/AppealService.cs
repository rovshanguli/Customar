using Domain.Entities.AppealModels;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AppealService : GenericService<Appeal>, IAppealService
    {
        private readonly AppDbContext _context;
        public AppealService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Appeal>> GetAllPaginate(int page, int pageSize)
        {
            //paginate
            return Task.FromResult(_context.Appeals.Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable());
        }


        public Task<Appeal> GetWithAppealTypes(int id)
        {
            var data = _context.Appeals.Where(x => x.Id == id)
                .Include(x => x.AppealTypes)
                .ThenInclude(x => x.Translates)
                .FirstOrDefaultAsync();
            return data;
        }

        public Task<IEnumerable<Appeal>> GetUserAppeals(string userId)
        {
            var data = _context.Appeals.Where(x => x.CreatedByID == userId).AsEnumerable();
            return Task.FromResult(data);
        }



    }

}
