using Domain.Entities.TicketStatusModels;

namespace Service.Services.Interfaces
{
    public interface ITicketStatusService : IGenericService<TicketStatus>
    {
        Task<TicketStatus> GetByLevelAsync(int level);
    }
}
