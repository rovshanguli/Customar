using Domain.Entities.AppUSerModels;

namespace Service.DTOs.TicketStatus
{
    public class TSGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Level { get; set; }
        public string CreatedByID { get; set; }
        public AppUser CreatedBy { get; set; }
        public DateTime DateTime { get; set; }

    }
}
