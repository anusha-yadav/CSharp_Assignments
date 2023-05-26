/* This is a program to generate largest product of
   four adjancent digits in a number
*/
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Main method of a program class
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.WriteLine("Enter a number");
            String num = Console.ReadLine();
            Validation obj = new Validation();
            if (obj.IsValid(num) == false)
            {
                Console.WriteLine("Please enter valid input of minimum size of 4 digits.");
            }
            else
            {
                GreatestProduct product = new GreatestProduct();
                List<int> digits = product.GetDigits(num);
                int maxProduct = product.GetProduct(digits);
                string outputResult = product.Display(digits, maxProduct);
                Console.WriteLine(outputResult);
            }
        }
    }
}
