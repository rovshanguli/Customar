using Domain.Entities.AppealModels;
using Domain.Entities.AppealTypeModels;
using Domain.Entities.AppUSerModels;
using Domain.Entities.InfoModels;
using Domain.Entities.Language;
using Domain.Entities.SubCodeModels;
using Domain.Entities.TicketModels;
using Domain.Entities.TicketStatusModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //SubCodeModels
        public DbSet<SubscriptionCode> SubscriptionCodes { get; set; }

        //TicketModels
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatusTranslate> TicketStatusTranslates { get; set; }

        //TicketStatus Models
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketStatusHistory> TicketStatusHistories { get; set; }


        //Language
        public DbSet<Language> Languages { get; set; }

        //Info
        public DbSet<Info> Infos { get; set; }
        public DbSet<InfoTranslate> InfoTranslates { get; set; }

        //Appeal
        public DbSet<Appeal> Appeals { get; set; }

        //AppealType
        public DbSet<AppealType> AppealTypes { get; set; }
        public DbSet<AppealTypeTranslate> AppealTypeTranslates { get; set; }
    }
}
