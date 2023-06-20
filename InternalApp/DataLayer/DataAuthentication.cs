using BusinessModels;

namespace DataLayer
{
    /// <summary>
    /// DataAuthentication class
    /// </summary>
    internal class DataAuthentication : IDataAuthentication
    {
        /// <summary>
        /// Validating login in datalayer
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidLogin(User user)
        {
            User validUser = DataSource.dataBase.Find(userObj => userObj.username.Equals(user.username) && userObj.password.Equals(user.password));
            if(validUser == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validating new password
        /// </summary>
        /// <param name="user"></param>
        public void ValidPasswd(User user) 
        { 
            User validPasswd = DataSource.dataBase.Find(userObj => userObj.username.Equals(user.username, StringComparison.Ordinal));
            if( validPasswd != null)
            {
                validPasswd.password = user.new_passwd;
            }
        }

        /// <summary>
        /// Adding details to database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsRegistered(User user)
        {
            if(!IsValidRegister(user))
            {
                DataSource dataSource = new DataSource();
                dataSource.AddDetails(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validating if user is already present in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidRegister(User user)
        {
            User validRegister = DataSource.dataBase.Find(userObj=>userObj.username.Equals(user.username) && userObj.phoneNumber.Equals(user.phoneNumber, StringComparison.Ordinal) && userObj.email.Equals(user.email, StringComparison.Ordinal));
            if( validRegister != null)
            {
                return true;
            }
            return false;
        }
    }
}
