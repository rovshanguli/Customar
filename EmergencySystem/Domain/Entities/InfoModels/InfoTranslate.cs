using Domain.Common;


namespace Domain.Entities.InfoModels
{
    public class InfoTranslate : BaseEntity
    {
        public int InfoId { get; set; }
        public string LangCode { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
    }
}
