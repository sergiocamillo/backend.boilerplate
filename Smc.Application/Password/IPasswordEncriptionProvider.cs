namespace Smc.Application.Password
{
    public interface IPasswordEncriptionProvider
    {
        string EncriptPassword(string password, string salt);
    }
}
