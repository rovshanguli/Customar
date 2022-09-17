using Domain.Common;
using Domain.Entities.AppUSerModels;

namespace Domain.Entities.SubCodeModels
{
    public class SubscriptionCode : BaseEntity
    {
        public string Code { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Address { get; set; }
        public string FIN { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
