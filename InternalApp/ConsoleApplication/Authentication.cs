using BusinessLayer;
using BusinessModels;

namespace ConsoleApplication
{
    /// <summary>
    /// Authentication class to check the inputs
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Authenticating login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsLogin(User user)
        {
            BALFactory balFactory = new();
            IBALAuthentication authentication = balFactory.GetBALAuthenticationObj();
            if(authentication.IsLogin(user))
                return true;
            return false;
        }

        /// <summary>
        /// Authenticating register user
        /// </summary>
        /// <param name="user"></param>
        public bool IsRegistered(User user)
        {
            BALFactory balFactory = new();
            IBALAuthentication authentication = balFactory.GetBALAuthenticationObj();
            if (authentication.IsRegistered(user))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Forgot password which checks new passwd and confirm passwd
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsCorrectPasswd(User user)
        {
            BALFactory balFactory = new();
            IBALAuthentication authentication = balFactory.GetBALAuthenticationObj();
            if (user.username!=null && user.confirm_passwd != null && user.new_passwd!=null)
            {
                return authentication.IsCorrectPasswd(user);
            }
            return false;
        }
    }
}
