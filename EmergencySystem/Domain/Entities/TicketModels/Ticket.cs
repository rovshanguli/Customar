using Domain.Entities.AppealModels;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.TicketModels
{
    public class Ticket
    {
        [Key]
        public string TicketId { get; set; }

        public string Note { get; set; }
        public DateTime DateTime { get; set; }
        public List<Appeal> Appeals { get; set; }
        public List<TicketStatusHistory> Statuses { get; set; }
        public bool IsDeleted { get; set; }


        public Ticket()
        {
            DateTime = DateTime.UtcNow;
        }
    }
}
