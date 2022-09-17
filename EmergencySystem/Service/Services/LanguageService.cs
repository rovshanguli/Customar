using Domain.Entities.Language;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class LanguageService : GenericService<Language>, ILanguageService
    {
        public LanguageService(AppDbContext context) : base(context)
        {

        }
    }

}
