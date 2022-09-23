using Domain.Common;
using Domain.Entities.AppealTypeModels;
using Domain.Entities.AppUSerModels;
using Domain.Entities.TicketModels;

namespace Domain.Entities.AppealModels
{
    public class Appeal : BaseEntity
    {

        public string Lat { get; set; }
        public string Long { get; set; }
        public string Address { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string PhotoUrl { get; set; }



        public List<AppealType> AppealTypes { get; set; }
        public string TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public string CreatedByID { get; set; }
        public AppUser CreatedBy { get; set; }
        public bool CreatedTicket { get; set; }

    }
}
