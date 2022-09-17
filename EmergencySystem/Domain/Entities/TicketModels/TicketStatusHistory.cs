using Domain.Common;
using Domain.Entities.AppUSerModels;
using Domain.Entities.TicketStatusModels;

namespace Domain.Entities.TicketModels
{
    public class TicketStatusHistory : BaseEntity
    {

        public string TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int TicketStatusId { get; set; }
        public TicketStatus TicketStatus { get; set; }

        public string CreatedById { get; set; }
        public AppUser CreatedBy { get; set; }
    }
}
