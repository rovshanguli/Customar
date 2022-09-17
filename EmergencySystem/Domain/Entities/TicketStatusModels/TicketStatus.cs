using Domain.Common;
using Domain.Entities.TicketModels;

namespace Domain.Entities.TicketStatusModels
{
    public class TicketStatus : BaseEntity
    {
        public string Icon { get; set; }
        public int Level { get; set; }
        public List<TicketStatusHistory> TicketStatusHistories { get; set; }
        public List<TicketStatusTranslate> Translate { get; set; }

    }
}
