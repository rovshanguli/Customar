using Domain.Entities.InfoModels;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class InfoService : GenericService<Info>, IInfoService
    {
        public InfoService(AppDbContext context) : base(context)
        {
        }
    }

}
