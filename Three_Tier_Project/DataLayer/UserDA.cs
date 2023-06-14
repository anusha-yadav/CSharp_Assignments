using System;

namespace DataLayer
{
    public class UserDA
    {
        public List<List<string>> AddData()
        {
            List<List<String>>dataBase = new List<List<string>>();
            int f = 0;
            string uname = Console.ReadLine();
            string passwd = Console.ReadLine();
            string email = Console.ReadLine();
            List<string> l1 = new List<string>();
            l1.Add(uname);
            l1.Add(passwd);
            l1.Add(email);
            for (int i = 0; i < dataBase.Count; i++)
            {
                if (dataBase[i][0] == uname && dataBase[i][1] == passwd && dataBase[i][2] == email)
                {
                    f = 1;
                    break;
                }
            }
            if (f == 0)
                dataBase.Add(l1);
            return dataBase;
        }
    }
}