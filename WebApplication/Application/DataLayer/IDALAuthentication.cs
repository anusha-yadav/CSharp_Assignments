using BusinessModels;

namespace DataLayer
{
    /// <summary>
    /// Interface for DAL Authentication Class
    /// </summary>
    public interface IDALAuthentication
    {
        int ForgotPassword(User user);
        int RegisterUser(User user);
        bool LoginUser(User user);
    }
}
