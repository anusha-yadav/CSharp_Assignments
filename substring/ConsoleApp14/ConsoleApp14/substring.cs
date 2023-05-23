using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Substring
    {
        public string s1, s2;
        public Substring(string s1, string s2) {
            this.s1 = s1;
            this.s2 = s2;
        }

        public void GetOccurencesAndIndexes()
        {
            List<int> l = new List<int>();
            int c = 0;
            for (int i = 0; i <= s1.Length - s2.Length; i++)
            {
                if (s1.Substring(i, s2.Length) == s2)
                {
                    l.Add(i);
                    c++;
                }
            }
            Console.WriteLine("No.of times occurred = " + c);
            Console.Write("Index positions = ");
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i] + " ");
            }
        }
    }
}
