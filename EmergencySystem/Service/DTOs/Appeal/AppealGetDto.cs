

using Service.DTOs.AppealType;

namespace Service.DTOs.Appeal
{
    public class AppealGetDto
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Address { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string PhotoUrl { get; set; }
        public string CreatedByID { get; set; }
        public string Note { get; set; }
        public List<AppealTypeDto> AppealTypes { get; set; }
    }
}
