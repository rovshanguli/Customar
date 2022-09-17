namespace Service.DTOs.Ticket
{
    public class TicketUpdateDto
    {
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string PhotoUrl { get; set; }
        public int TicketTypeId { get; set; }

    }
}
