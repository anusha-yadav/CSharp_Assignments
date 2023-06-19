using BusinessModels;

namespace DataLayer
{ 
    /// <summary>
    /// DataSource class which contains database
    /// </summary>
    internal class DataSource 
    {
        //Dtabase for application 
        public static List<User> dataBase = new List<User>();

        /// <summary>
        /// AddDetails adds the details in the database
        /// </summary>
        /// <param name="user"></param>
        public void AddDetails(User user)
        {
            dataBase.Add(user);
        }

        /// <summary>
        /// GetDetails fetches the details 
        /// </summary>
        public void GetDetails()
        {
            for (int i = 0; i < dataBase.Count; i++)
            {
                Literals.DisplayObjDetails(dataBase[i]);
            }
        }
    }
}