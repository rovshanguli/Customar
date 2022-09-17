using Domain.Common;

namespace Domain.Entities.TicketStatusModels
{
    public class TicketStatusTranslate : BaseEntity
    {
        public int TicketStatusId { get; set; }
        public string LangCode { get; set; }
        public string Name { get; set; }
    }
}
