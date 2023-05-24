/* This is a program to generate largest product of
   four adjancent digits in a number
*/
using System;

namespace ConsoleApp
{
    class Program
    {
        //Main class of a program
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            String num = Console.ReadLine();
            Validation obj = new Validation(); // Creating object for validation class and calling its corresponding methods
            obj.IsValid(num);
            obj.Display(num);
        }
    }
}
