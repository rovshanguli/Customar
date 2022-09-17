namespace Service.DTOs.Info
{
    public class InfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public List<InfoTranslateDto> Translates { get; set; }
    }
}
