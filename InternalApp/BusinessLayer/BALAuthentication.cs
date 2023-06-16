using DataLayer;
using BusinessModels;

namespace BusinessLayer
{
    /// <summary>
    /// BAL Authentication class
    /// </summary>
    public class BALAuthentication
    {
        /// <summary>
        /// Authenticating login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsLogin(User user)
        {
            DataFactory dataFactory = new DataFactory();
            IDataAuthentication dataAuthentication = dataFactory.GetDataObj();
            if (user.username != null && user.password != null)
            {
                return dataAuthentication.IsValidLogin(user);
            }
            return false;
        }

        /// <summary>
        /// Authenticating new register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsRegistered(User user)
        {
            DataFactory dataFactory = new DataFactory();
            IDataAuthentication dataAuth = dataFactory.GetDataObj();
            if (user!=null)
            {
                return dataAuth.IsRegistered(user);
            }
            return false;
        }

        /// <summary>
        /// Authenticating new password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsCorrectPasswd(User user)
        {
            DataFactory dataFactory = new DataFactory();
            IDataAuthentication dataAuthentication = dataFactory.GetDataObj();
            if(user.confirm_passwd == user.new_passwd)
            {
                dataAuthentication.CorrectPasswd(user);
                return true;
            }
            return false;
        }
    }
}
