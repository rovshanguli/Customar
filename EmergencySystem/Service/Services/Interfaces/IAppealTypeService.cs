using Domain.Entities.AppealTypeModels;

namespace Service.Services.Interfaces
{
    public interface IAppealTypeService : IGenericService<AppealType>
    {
        Task<IEnumerable<AppealType>> GetAllWithTranslates();

        Task<List<AppealType>> GetAllWithId(List<int> ids);
    }

}
