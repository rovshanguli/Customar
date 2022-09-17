using Domain.Common;

namespace Domain.Entities.InfoModels
{
    public class Info : BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public List<InfoTranslate> Translates { get; set; }
    }
}
