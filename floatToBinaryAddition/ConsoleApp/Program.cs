using System;
using System.Collections.Generic;


namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter first float: ");
            string FirstString = Console.ReadLine();
            Console.Write("Enter second float: ");
            string SecondString = Console.ReadLine();
            float FirstFloat = float.Parse(FirstString);
            float SecondFloat = float.Parse(SecondString);
            ToFloatBinary obj = new ToFloatBinary();
            string s1 = obj.RevString(obj.ToBinary(FirstFloat));
            string s2 = obj.RevString(obj.ToDecimal(FirstFloat));
            string str = obj.getTotal(s1, s2);
            //Console.WriteLine(obj.getTotal(s1, s2));
            Tuple<string, int> tp = obj.PointAdjustment(str);
            string s3 = obj.RevString(obj.ToBinary(SecondFloat));
            string s4 = obj.RevString(obj.ToDecimal(SecondFloat));
            string str1 = obj.getTotal(s3, s4);
            //Console.WriteLine(obj.getTotal(s1, s2));
            Tuple<string, int> tp1 = obj.PointAdjustment(str1);
            BinaryAddition add = new BinaryAddition();
            if(tp1.Item2 > tp.Item2)
            {
                string s5 = add.AdjustDecimalPoint(tp, tp1.Item2,tp1.Item1.Length);
                string s6 = add.AddBinary(s5, tp1.Item1);
                float s7 = add.BinaryToFloat(s6, tp1.Item2);
                Console.WriteLine(s7);
            }
            else
            {
                string s6 = add.AdjustDecimalPoint(tp1, tp.Item2,tp.Item1.Length);
                Console.WriteLine(s6);
            }
        }
    }
}

