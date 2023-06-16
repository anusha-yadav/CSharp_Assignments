using BusinessModels;

namespace DataLayer
{ 
    /// <summary>
    /// DataSource class which contains database
    /// </summary>
    internal class DataSource 
    {
        public static List<User> dataBase = new List<User>();
        public void AddDetails(User user)
        {
            dataBase.Add(user);
        }

        public void GetDetails()
        {
            for (int i = 0; i < dataBase.Count; i++)
            {
                Literals.DisplayObjDetails(dataBase[i]);
            }
        }
    }
}