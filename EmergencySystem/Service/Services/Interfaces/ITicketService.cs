using Domain.Entities.TicketModels;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket> GetAsync(string id);
        Task<Ticket> CreateAsync(Ticket entity);
        Task UpdateAsync(Ticket entity);
        Task SoftDeleteAsync(Ticket entity);
        Task DeleteAsync(Ticket entity);
        Task<Ticket> FindAsync(Expression<Func<Ticket, bool>> predicate);
    }

}
