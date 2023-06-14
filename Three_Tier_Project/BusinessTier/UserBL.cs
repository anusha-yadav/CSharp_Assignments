using System;
using DataLayer;

namespace BusinessTier
{
    public class UserBL
    {
        public void LoginDisplay()
        {
            Console.WriteLine("Please enter username and password");
            String uname = Console.ReadLine();
            String passwd = Console.ReadLine();
            if (IsValid_User(uname, passwd))
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Login Sucessfull");
                Console.WriteLine("------------------");
            }
            else
            {
                Console.WriteLine("Please enter correct details");
            }
        }

        public bool IsValid_User(string uname,string passwd)
        {
            UserDA userDA = new UserDA();
            List<List<string>> dataBase = userDA.AddData();
            for(int i=0; i<dataBase.Count; i++)
            {
                if (dataBase[i][0] == uname && dataBase[i][1] == passwd)
                {
                    return true;
                }
            }
            return false;
        }

        public void Registration_Display()
        {
            UserDA user = new UserDA();
            Console.WriteLine("Please enter details");
            user.AddData();
        }
    }
}