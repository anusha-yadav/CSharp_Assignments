using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// Validation class for BAL
    /// </summary>
    public class BALValidation
    {
        /// <summary>
        /// Validating password
        /// </summary>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public bool IsValidPasswd(string passwd)
        {
            if (passwd.Length <= 8 || !Regex.IsMatch(passwd, "[A-Z]"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validating phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool IsValidPhoneNo(string phoneNumber)
        {
            if (phoneNumber.Length < 10 && !Regex.IsMatch(phoneNumber, "[0-9]"))
            {
                return false;
            }
            else if (phoneNumber.Length == 10 && Regex.IsMatch(phoneNumber, "[0-9]"))
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
            if (email.EndsWith("@gmail.com") == false)
            {
                return false;
            }
            return true;
        }
    }
}