using BusinessModels;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for BAL Authentication Class
    /// </summary>
    public interface IBALAuthentication
    {
        int ForgotPassword(User user);
        bool LoginUser(User user);
        int RegisterUser(User user); 
    }
}
