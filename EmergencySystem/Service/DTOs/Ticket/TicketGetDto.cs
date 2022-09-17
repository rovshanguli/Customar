using Service.DTOs.TicketStatus;

namespace Service.DTOs.Ticket
{
    public class TicketGetDto
    {
        public string TicketId { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string PhotoUrl { get; set; }
        public List<TSGetDto> Statuses { get; set; }

    }
}
