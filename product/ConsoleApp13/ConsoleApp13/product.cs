using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class product
    {
        public string s;
        public product(string str)
        {
            s = str;
        } 
        public void Product()
        {
            List<int>l = new List<int>();
            int c = 1, ans = int.MinValue;
            for(int i=0;i<=s.Length-4;i++)
            {
                c = c * (s[i] - '0') * (s[i + 1] - '0') * (s[i + 2] - '0') * (s[i + 3] - '0');
                if(c > ans)
                {
                    ans = c;
                    l.Add(s[i]-'0');
                    l.Add(s[i + 1]- '0');
                    l.Add(s[i + 2] - '0');
                    l.Add(s[i + 3] - '0');
                }
                c = 1;
            }
            int size = l.Count();
            for(int i = l.Count - 4; i < size; i++)
            {
                if(i==size-1)
                    Console.Write(l[i]);
                else
                    Console.Write(l[i] + "*");
            }
            Console.WriteLine("=" + ans);
        }
    }
}
