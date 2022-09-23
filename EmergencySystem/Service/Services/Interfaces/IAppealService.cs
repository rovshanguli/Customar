using Domain.Entities.AppealModels;

namespace Service.Services.Interfaces
{
    public interface IAppealService : IGenericService<Appeal>
    {
        Task<IEnumerable<Appeal>> GetAllPaginate(int page, int pageSize);
        Task<Appeal> GetWithAppealTypes(int id);
        //GetUserAppeal
        Task<IEnumerable<Appeal>> GetUserAppeals(string userId);
    }

}
