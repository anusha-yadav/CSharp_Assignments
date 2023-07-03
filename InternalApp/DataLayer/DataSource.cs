using DataModels;

namespace DataLayer
{ 
    /// <summary>
    /// DataSource class which contains database
    /// </summary>
    internal class DataSource 
    {
        /// <summary>
        /// Database for application
        /// </summary>
        public static List<User> dataBase = new List<User>();

        /// <summary>
        /// AddDetails adds the details in the database
        /// </summary>
        /// <param name="user"></param>
        public void AddDetails(User user)
        {
            dataBase.Add(user);
        }
    }
}