namespace Service.DTOs.TicketStatus
{
    public class TSUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<TStatusTranslateDto> Translate { get; set; }
        public int Level { get; set; }
        public DateTime DateTime { get; set; }
    }
}
