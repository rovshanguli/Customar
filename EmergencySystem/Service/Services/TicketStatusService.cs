using Domain.Entities.TicketStatusModels;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class TicketStatusService : GenericService<TicketStatus>, ITicketStatusService
    {
        private readonly AppDbContext _context;
        public TicketStatusService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<TicketStatus> GetByLevelAsync(int level)
        {
            return _context.TicketStatuses.FirstOrDefaultAsync(x => x.Level == level);
        }
    }
}
