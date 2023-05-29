using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class ToFloatBinary
    {
        public string RevString(string str)
        {
            string revStr = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                revStr += str[i];
            }
            return revStr;
        }
        public string ToBinary(float m)
        {
            int n = (int)m;
            string getBinary = string.Empty;
            while (n != 0)
            {
                getBinary += (char)n % 2;
                n /= 2;
            }
            return getBinary;
        }

        public string ToDecimal(float m)
        {
            string getDecimal = string.Empty;
            double n = m - (int)m;
            while (n != 0)
            {
                n = n * 2;
                int temp = (int)n;
                if (temp == 1)
                {
                    n = n - temp;
                    getDecimal += '1';
                }
                else
                {
                    getDecimal += '0';
                }
            }
            return getDecimal;
        }

        public string getTotal(string s1,string s2)
        {
            string total = s1 + "." + s2;
            return total;
        }

        public Tuple<string,int> PointAdjustment(string str)
        {
            int index=0,point=0,temp;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == 1)
                {
                    index = i;
                    break;
                }
            }
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                {
                    point = i;
                    break;
                }
            }
            //Console.Write(point + " " + index);
            temp = point - index - 1;
            string s2 = str.Remove(point, 1);
            string s3 = s2.Insert(index+1, ".");
            Tuple<string, int> tp = new Tuple<string, int>(s3, temp);
            return tp;
        }
    }
}
