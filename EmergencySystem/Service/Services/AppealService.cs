using Domain.Entities.AppealModels;
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








    }

}
