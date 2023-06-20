using DataLayer;
using BusinessModels;

namespace BusinessLayer
{
    /// <summary>
    /// BAL Authentication class which inherits the IBALAuthentication interface
    /// </summary>
    internal class BALAuthentication : IBALAuthentication
    {
        /// <summary>
        /// Authenticating login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsLogin(User user)
        {
            DALFactory dataFactory = new();
            IDataAuthentication dataAuth = dataFactory.GetDataAuthObj();

            if (user.username != null && user.password != null)
            {
                return dataAuth.IsValidLogin(user);
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
            DALFactory dataFactory = new DALFactory();
            IDataAuthentication dataAuth = dataFactory.GetDataAuthObj();

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
        public bool IsValidPasswd(User user)
        {
            DALFactory dataFactory = new DALFactory();
            IDataAuthentication dataAuth = dataFactory.GetDataAuthObj();

            if(user.confirm_passwd == user.new_passwd)
            {
                dataAuth.ValidPasswd(user);
                return true;
            }
            return false;
        }
    }
}
