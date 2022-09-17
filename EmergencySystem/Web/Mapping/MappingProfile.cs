using AutoMapper;
using Domain.Entities.AppealModels;
using Domain.Entities.AppealTypeModels;
using Domain.Entities.InfoModels;
using Domain.Entities.Language;
using Domain.Entities.SubCodeModels;
using Domain.Entities.TicketModels;
using Domain.Entities.TicketStatusModels;
using Service.DTOs.Appeal;
using Service.DTOs.AppealType;
using Service.DTOs.Info;
using Service.DTOs.Language;
using Service.DTOs.SubCode;
using Service.DTOs.Ticket;
using Service.DTOs.TicketStatus;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketStatus, TSCreateDto>().ReverseMap();
            CreateMap<TicketStatus, TSUpdateDto>().ReverseMap();
            CreateMap<TicketStatus, TSGetDto>().ReverseMap();
            CreateMap<TicketStatusTranslate, TStatusTranslateDto>().ReverseMap();
            CreateMap<Ticket, TicketGetDto>().ReverseMap();
            CreateMap<Ticket, TicketCreateDto>().ReverseMap();
            CreateMap<Ticket, TicketUpdateDto>().ReverseMap();

            CreateMap<SubscriptionCode, SubCodeDto>().ReverseMap();
            CreateMap<Language, LanguageDto>().ReverseMap();

            CreateMap<Info, InfoDto>().ReverseMap();
            CreateMap<InfoTranslate, InfoTranslateDto>().ReverseMap();
           // CreateMap<Appeal, AppealDto>().ReverseMap();
            CreateMap<AppealType, AppealTypeDto>().ReverseMap();
            CreateMap<AppealDto, Appeal>()
                .ForMember(c => c.AppealTypes, opt => opt.MapFrom(c => c.AppealTypes.Select(v=>new AppealType() { Id=v }))).ReverseMap();
            CreateMap<AppealTypeTranslate, AppealTypeTranslateDto>().ReverseMap();
            
        }
    }
}
