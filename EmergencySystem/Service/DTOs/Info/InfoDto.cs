using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Info
{
    public class InfoDto
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public List<InfoTranslateDto> Translates { get; set; }
        public IFormFile Photo { get; set; }
    }
}
