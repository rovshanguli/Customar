using Microsoft.Extensions.DependencyInjection;
using Service.Helpers.Token;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<ITicketStatusService, TicketStatusService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ISubCodeService, SubCodeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IInfoService, InfoService>();
            services.AddScoped<IAppealService, AppealService>();
            services.AddScoped<IAppealTypeService, AppealTypeService>();
            services.AddScoped<IToken, Token>();


            return services;
        }
    }
}
