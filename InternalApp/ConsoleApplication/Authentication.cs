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
            BALAuthentication authentication = new();
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
            BALAuthentication auth = new BALAuthentication();
            if (auth.IsRegistered(user))
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
            BALAuthentication authentication = new BALAuthentication();
            if(user.username!=null && user.confirm_passwd != null && user.new_passwd!=null)
            {
                return authentication.IsCorrectPasswd(user);
            }
            return false;
        }
    }
}
