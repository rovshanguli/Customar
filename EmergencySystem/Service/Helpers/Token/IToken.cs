namespace Service.Helpers.Token
{
    public interface IToken
    {
        string CreateToken(string email, string username, List<string> roles);
    }
}
