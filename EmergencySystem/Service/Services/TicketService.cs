using Domain.Entities.TicketModels;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;
        public TicketService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Ticket> CreateAsync(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _context.Tickets.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task SoftDeleteAsync(Ticket entity)
        {
            if (entity is null) throw new ArgumentNullException();
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Ticket entity)
        {
            if (entity is null) throw new ArgumentNullException();
            _context.Tickets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Ticket> FindAsync(Expression<Func<Ticket, bool>> predicate)
        {
            return await _context.Tickets.FindAsync(predicate);
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.Where(m => m.IsDeleted == false).ToListAsync();
        }

        public async Task<Ticket> GetAsync(string id)
        {
            Ticket entity = await _context.Tickets.FirstOrDefaultAsync(m => m.TicketId == id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return entity;
        }

        public async Task UpdateAsync(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
