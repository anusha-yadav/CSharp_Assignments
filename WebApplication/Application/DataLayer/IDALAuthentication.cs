using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDALAuthentication
    {
        string EncodePasswordToBase64(string password);
        int ForgotPassword(User user);
        int RegisterUser(User user);
        bool LoginUser(User user);
    }
}
