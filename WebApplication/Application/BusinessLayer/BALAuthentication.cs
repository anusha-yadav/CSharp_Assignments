using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;
using DataLayer;

namespace BusinessLayer
{
    public class BALAuthentication : IBALAuthentication
    {
        public int ForgotPassword(User user)
        {
            DALFactory dALFactory = new DALFactory();
            IDALAuthentication authentication = new DALAuthentication();
            return authentication.ForgotPassword(user);
        }

        public int RegisterUser(User user)
        {
            DALFactory dALFactory = new DALFactory();
            IDALAuthentication authentication = new DALAuthentication();
            return authentication.RegisterUser(user);
        }

        public bool LoginUser(User user)
        {
            DALFactory dALFactory = new DALFactory();
            IDALAuthentication authentication = new DALAuthentication(); 
            return authentication.LoginUser(user);
        }
    }
}
