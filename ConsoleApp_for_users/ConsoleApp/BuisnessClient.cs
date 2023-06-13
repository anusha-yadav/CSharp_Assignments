using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class BuisnessClient : DataLayer
    {
        public void AddData()
        {
            DataLayer obj = new DataLayer();
            int f = 0;
            Console.WriteLine("Please enter username, password and email");
            string uname = Console.ReadLine();
            string passwd = Console.ReadLine();
            string email = Console.ReadLine();
            List<string>l1 = new List<string>();
            l1.Add(uname);
            l1.Add(passwd);
            l1.Add(email);
            for(int i = 0; i < data.Count; i++)
            {
                if (data[i][0] == uname && data[i][1] == passwd && data[i][2] == email)
                {
                    f = 1;
                    break;
                }
            }
            if(f == 0) 
                data.Add(l1);
        }

        public void DisplayDB()
        {
            for(int i=0;i<data.Count;i++)
            {
                Console.WriteLine(data[i][0] + "\n" + data[i][1] +"\n"+ data[i][2]);
            }
        }
    }
}
