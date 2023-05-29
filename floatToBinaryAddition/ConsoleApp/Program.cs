/*
 To convert float inputs to binary and perform addition and convert 
 the result back to float.
*/

using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    /// <summary>
    /// Main class of a program which creates different objects to implement the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method of a program
        /// </summary>
        static void Main()
        {
            Console.Write("Enter first float : ");
            float firstNum = float.Parse(Console.ReadLine());
            Console.Write("Enter second float : ");
            float secondNum = float.Parse(Console.ReadLine());
            ToFloatBinary obj = new ToFloatBinary();
            string firstFloatBinary = obj.getTotal(obj.RevString(obj.ToBinary(firstNum)), obj.ToDecimal(firstNum));
            //Tuple to store string binary and exponent value
            Tuple<string, int> firstTuple = obj.PointAdjustment(firstFloatBinary);
            string secondFloatBinary = obj.getTotal(obj.RevString(obj.ToBinary(secondNum)), obj.ToDecimal(secondNum));
            Tuple<string, int> secondTuple = obj.PointAdjustment(secondFloatBinary);
            BinaryAddition add = new BinaryAddition();
            if(secondTuple.Item2 > firstTuple.Item2)
            {
                string strAdjustDecimal = add.AdjustDecimalPoint(firstTuple, secondTuple.Item2, secondTuple.Item1.Length);
                string strFloatToBinary = add.AddBinary(strAdjustDecimal,secondTuple.Item1);
                float outputResult = add.BinaryToFloat(strFloatToBinary,secondTuple.Item2); 
                Console.WriteLine("Resultant of binary addition in float is "+outputResult);
            }
            else
            {
                string strAdjustDecimal = add.AdjustDecimalPoint(secondTuple, firstTuple.Item2, firstTuple.Item1.Length);
                string strFloatToBinary = add.AddBinary(strAdjustDecimal, firstTuple.Item1);
                float outputResult = add.BinaryToFloat(strFloatToBinary, firstTuple.Item2);
                Console.WriteLine("Resultant of binary addition in float is "+outputResult);
            }
        }
    }
}

