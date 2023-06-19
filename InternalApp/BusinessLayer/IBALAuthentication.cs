using BusinessModels;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for BAL Authentication
    /// </summary>
    public interface IBALAuthentication
    {
        public bool IsLogin(User user);
        public bool IsRegistered(User user);
        public bool IsCorrectPasswd(User user);
    }
}
