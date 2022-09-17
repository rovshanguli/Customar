using Domain.Common;

namespace Domain.Entities.Language
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public bool IsDefault { get; set; }
    }
}
