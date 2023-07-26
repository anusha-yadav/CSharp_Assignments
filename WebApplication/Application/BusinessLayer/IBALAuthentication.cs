using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBALAuthentication
    {
        int ForgotPassword(User user);
        bool LoginUser(User user);
        int RegisterUser(User user); 
    }
}
