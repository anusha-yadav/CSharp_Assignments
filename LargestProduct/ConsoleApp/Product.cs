using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    //Product class is to find out the max product 4 adjacent digits in a number 
    class Product
    {
        List<int>arr = new List<int>();

        //GetProduct will calculate the max product of 4 adjacent digits in a number
        public int GetProduct(string s)
        {
            int c = 0;
            //Checking if a number is negative or positive
            if (s[0] == '-')
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
            int ans = 1, res = int.MinValue;
            for (int i = c; i <= s.Length - 4; i++)
            {
                ans = ans * (s[i] - '0') * (s[i + 1] - '0') * (s[i + 2] - '0') * (s[i + 3] - '0');
                if (ans > res)
                {
                    arr.Clear();
                    res = ans;
                    arr.Add(s[i] - '0');
                    arr.Add(s[i + 1] - '0');
                    arr.Add(s[i + 2] - '0');
                    arr.Add(s[i + 3] - '0');
                }
                ans = 1;
            }
            return res;
        }

        //Display method is used to print the max product result and its corresponding numbers
        public void Display(int res)
        {
            int size = arr.Count;
            for (int i = 0; i < size; i++)
            {
                if (i == size - 1)
                    Console.Write(arr[i]);
                else
                    Console.Write(arr[i] + "*");
            }
            Console.WriteLine("=" + res);
        }
    }
}
