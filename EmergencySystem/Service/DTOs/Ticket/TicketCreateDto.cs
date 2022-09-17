namespace Service.DTOs.Ticket
{
    public class TicketCreateDto
    {
        public string TicketId { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string PhotoUrl { get; set; }
        public int TicketStatusId { get; set; }
        public List<int> AppealsId { get; set; }
        public string Note { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedForID { get; set; }
    }
}
