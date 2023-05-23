using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two strings.");
            String s1 = Console.ReadLine();
            String s2 = Console.ReadLine();
            Substring obj = new Substring(s1,s2);
            obj.GetOccurencesAndIndexes();
        }
    }
}
