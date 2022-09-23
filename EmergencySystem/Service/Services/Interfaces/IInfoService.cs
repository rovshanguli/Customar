using Domain.Entities.InfoModels;

namespace Service.Services.Interfaces
{
    public interface IInfoService : IGenericService<Info>
    {
        Task<List<Info>> GetInfosWithTranslate();
    }
}
