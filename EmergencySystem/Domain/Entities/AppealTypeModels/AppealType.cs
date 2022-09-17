using Domain.Common;
using Domain.Entities.AppealModels;

namespace Domain.Entities.AppealTypeModels
{
    public class AppealType : BaseEntity
    {
        public string Icon { get; set; }
        public List<Appeal> Appeals { get; set; }
        public List<AppealTypeTranslate> Translates { get; set; }
    }
}
