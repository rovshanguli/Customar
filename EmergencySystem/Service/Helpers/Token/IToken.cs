using Domain.Entities.AppUSerModels;

namespace Service.Helpers.Token
{
    public interface IToken
    {
        string CreateToken(AppUser user, List<string> roles);
    }
}
