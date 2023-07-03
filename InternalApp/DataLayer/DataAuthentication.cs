using BM = BusinessModels.User;

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
        public bool IsValidLogin(BM user)
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
        public void CorrectPasswd(BM user) 
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
        public bool IsRegistered(BM user)
        {
            for (int i = 0; i < DataSource.dataBase.Count; i++)
            {
                if (DataSource.dataBase[i].username == user.username && DataSource.dataBase[i].phoneNumber == user.phoneNumber && DataSource.dataBase[i].email == user.email)
                {
                    return false;
                }
            }
            DataSource dataSource = new DataSource();
            dataSource.AddDetails(ConvertObj(user));
            return true;
        }

        /// <summary>
        /// Converting business model user object to data model user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataModels.User ConvertObj(BM user)
        {
            DataModels.User obj = new DataModels.User();
            obj.username = user.username;
            obj.password = user.password;
            obj.phoneNumber = user.phoneNumber;
            obj.email = user.email;
            return obj;
        }
    }
}
