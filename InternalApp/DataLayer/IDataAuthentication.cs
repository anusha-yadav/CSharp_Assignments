using BusinessModels;

namespace DataLayer
{
    /// <summary>
    /// Interface for DataAuthentication
    /// </summary>
    public interface IDataAuthentication
    {
        public bool IsValidLogin(User user);
        public void CorrectPasswd(User user);
        public bool IsRegistered(User user);
    }
}
