using BusinessModels;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// Validation class for BAL
    /// </summary>
    internal class BALValidation : IBALValidation
    {
        /// <summary>
        /// Validating username 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsValidUsername(string username)
        {
            if(Regex.IsMatch(username,@"^(?=.*[A-Z])(?=.*?[a-z]).{6,8}"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validating password
        /// </summary>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public bool IsValidPasswd(string passwd)
        {
            if (Regex.IsMatch(passwd,@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,16}"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validating phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool IsValidPhoneNo(string phoneNumber)
        {
            if(Regex.IsMatch(phoneNumber,"[0-9]{10}"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validating email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            if (email.EndsWith(".com") == false )
            {
                return false;
            }
            return true;
        }
    }
}