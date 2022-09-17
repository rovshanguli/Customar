using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Language
{
    public class LanguageDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Code { get; set; }
        public string Icon { get; set; }
        public bool IsDefault { get; set; }
    }
}
