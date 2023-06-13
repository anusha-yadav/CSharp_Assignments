using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Login : BuisnessClient
    {
        public void Display()
        {
            Console.WriteLine("Please enter username and password");
            String uname = Console.ReadLine();
            String passwd = Console.ReadLine();
            if(IsValid(uname, passwd) == false)
            {
                Console.WriteLine("Please enter correct password and username");
            }
            else
            {
                Console.WriteLine("Login Successful");
            }
        }

        public bool IsValid(String username, String password)
        {
            for(int i = 0; i < data.Count; i++)
            {
                if (data[i][0]==username && data[i][1] == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
