using Domain.Entities.AppealModels;
using Domain.Entities.SubCodeModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.AppUSerModels
{
    public class AppUser : IdentityUser
    {
        public string DeviceLang { get; set; }
        public List<SubscriptionCode> SubscriptionCodes { get; set; }

        [ForeignKey("UserData")]
        public string UserDataFIN { get; set; }
        public UserData UserData { get; set; }
        public List<Appeal> Appeals { get; set; }
    }
}
