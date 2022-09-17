using Domain.Entities.SubCodeModels;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SubCodeService : GenericService<SubscriptionCode>, ISubCodeService
    {
        public SubCodeService(AppDbContext context) : base(context)
        {

        }
    }
}
