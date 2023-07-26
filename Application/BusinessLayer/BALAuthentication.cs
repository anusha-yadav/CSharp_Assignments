using DataLayer;
using BusinessModels;

namespace BusinessLayer
{
    public class BALAuthentication
    {
        public int ForgotPassword(User user)
        {
            DALAuthentication authentication = new DALAuthentication();
            return authentication.ForgotPassword(user);
        }

        public int RegisterUser(User user)
        {
            DALAuthentication authentication = new DALAuthentication();
            return authentication.RegisterUser(user);
        }

        public bool LoginUser(User user) 
        {
            DALAuthentication authentication = new DALAuthentication();
            return authentication.LoginUser(user);
        }
    }
}
