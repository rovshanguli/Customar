namespace Service.DTOs.TicketStatus
{
    public class TSCreateDto
    {
        public string Icon { get; set; }

        public int Level { get; set; }
        public List<TStatusTranslateDto> Translate { get; set; }
        public DateTime DateTime { get; set; }
    }
}
