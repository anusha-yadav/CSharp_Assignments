using System;
using System.Collections.Generic;

/*
This program is to generate the index positions of a substring in the actual
string and displaying the index positions and count of all the occurences
*/

namespace ConsoleApplication
{
    /// <summary>
    /// Main Program class for implementing objects
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method of a program
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter a string and its corresponding substring");
            string actualString = Console.ReadLine();
            string subString = Console.ReadLine();
            Validation val = new Validation();
            LogMessages log = new LogMessages();
            log.ValidationDisplay(val.IsValid(actualString, subString));
            GetSubstring substr = new GetSubstring();
            List<int> indexes = substr.GetIndexes(actualString, subString);
            log.GetIndexesDisplay(indexes);
        }
    }
}
