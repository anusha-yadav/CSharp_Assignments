using System;
using BusinessModels;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// BusinessLayer Authentication Class
    /// </summary>
    public class BALAuthentication : IBALAuthentication
    {
        /// <summary>
        /// Encryption method for password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception(Literals.encodeMsg + ex.Message);
            }
        }

        /// <summary>
        /// Authenticating forgot password method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int ForgotPassword(User user)
        {
            DALFactory dALFactory = new DALFactory();
            IDALAuthentication authentication = dALFactory.GetDALObject();
            User userObj = user;
            userObj.new_passwd = EncodePasswordToBase64(user.new_passwd);
            return authentication.ForgotPassword(userObj);
        }

        /// <summary>
        /// Authenticating user registration method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int RegisterUser(User user)
        {
            DALFactory dALFactory = new DALFactory();
            IDALAuthentication authentication = dALFactory.GetDALObject();
            User userObj = user;
            userObj.password = EncodePasswordToBase64(user.password);
            return authentication.RegisterUser(userObj);
        }

        /// <summary>
        /// Authenticating User login method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool LoginUser(User user)
        {
            DALFactory dALFactory = new DALFactory();
            IDALAuthentication authentication = dALFactory.GetDALObject();
            User userObj = user;
            userObj.password = EncodePasswordToBase64(user.password);
            return authentication.LoginUser(userObj);
        }
    }
}
