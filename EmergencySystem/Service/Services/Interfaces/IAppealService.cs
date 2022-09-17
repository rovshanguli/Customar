using Domain.Entities.AppealModels;

namespace Service.Services.Interfaces
{
    public interface IAppealService : IGenericService<Appeal>
    {
        //paginate
        Task<IEnumerable<Appeal>> GetAllPaginate(int page, int pageSize);
    }

}
