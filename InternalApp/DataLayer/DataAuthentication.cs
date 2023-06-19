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
            for(int i = 0; i < DataSource.dataBase.Count; i++)
            {
                if (DataSource.dataBase[i].username == user.username && DataSource.dataBase[i].password==user.password)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Validating new password
        /// </summary>
        /// <param name="user"></param>
        public void CorrectPasswd(User user) 
        { 
            for(int i=0;i<DataSource.dataBase.Count;i++)
            {
                if (DataSource.dataBase[i].username == user.username)
                {
                    DataSource.dataBase[i].password = user.new_passwd;
                }
            }
        }

        /// <summary>
        /// Validating if user is present already in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsRegistered(User user)
        {
            for (int i = 0; i < DataSource.dataBase.Count; i++)
            {
                if (DataSource.dataBase[i].username == user.username && DataSource.dataBase[i].phoneNumber == user.phoneNumber && DataSource.dataBase[i].email == user.email)
                {
                    return false;
                }
            }
            DataSource dataSource = new DataSource();
            dataSource.AddDetails(user);
            return true;
        }
    }
}
