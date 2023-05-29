using System;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class BinaryAddition
    {
        public string AdjustDecimalPoint(Tuple<string,int>tp,int x,int len)
        {
            int diff = x - tp.Item2;
            string s5;
            string s2 = tp.Item1.PadLeft(diff+tp.Item1.Length,'0');
            int idx = 0;
            for(int i = 0; i < s2.Length; i++)
            {
                if (s2[i] == '.')
                {
                    idx = i;
                }
            }
            string s3 = s2.Remove(idx, 1);
            string s4 = s3.Insert(diff, ".");
            int lendiff = len - s4.Length;
            if (lendiff > 0)
            {
                s5=s4.PadRight(len, '0');
                return s5;
            }
            return s4;
        }

        public string AddBinary(string s1, string s2)
        {
            string a = s1.Substring(2);
            string b = s2.Substring(2);
            string c = s1.Substring(0, 1);
            string d = s2.Substring(0, 1);
            string result = string.Empty;
            //Console.Write(a + " " + b);
            string s = string.Empty;
            StringBuilder res = new StringBuilder(s);
            char carry = '0';
            for(int i = a.Length-1; i >= 0; i--)
            {
                if (a[i] == '1' && b[i] == '1')
                {
                    if (carry == '1')
                    {
                        res.Append('1');
                        carry = '1';
                    }
                    else
                    {
                        res.Append('0');
                        carry = '1';
                    }
                }
                else if (a[i]=='0' && b[i] == '0')
                {
                    if (carry == '1')
                    {
                        res.Append('1');
                        carry = '0';
                    }
                    else
                    {
                        res.Append('0');
                        carry = '0';
                    }
                }
                else if (a[i] != b[i])
                {
                    if (carry == '1')
                    {
                        res.Append('0');
                        carry = '1';
                    }
                    else
                    {
                        res.Append('1');
                        carry = '0';
                    }
                }
            }
            s = res.ToString();
            string revStr = string.Empty;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                revStr += s[i];
            }
            if(c=="0" && d == "0")
            {
                if (carry == '1')
                {
                    result = carry + "." + revStr;
                }
                else
                {
                    result = "0" + "." + revStr;
                }
            }
            else if(c!=d)
            {
                if (carry == '1')
                {
                    result = "10" + "." + revStr;
                }
                else
                {
                    result = "1" + "." + revStr;
                }
            }
            else if(c=="1"&& d == "1")
            {
                if (carry == '1')
                {
                    result = "11" + "." + revStr;
                }
                else
                {
                    result = "10" + "." + revStr;
                }
            }
            return result;
        }

        public float BinaryToFloat(string s,int x)
        {
            string res;
            int index = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    index = i;
                }
            }
            string s1 = s.Insert(index + 1 + x, ".");
            string s2 = s1.Remove(index, 1);
            string a = s2.Substring(0, s2.IndexOf('.'));
            int ans=0;
            float result = 0f;
            int power1 = 0, power2 = -1;
            for(int i = a.Length - 1; i >= 0; i--)
            {
                ans += (a[i] - '0') * (int)Math.Pow(2, power1);
                power1++;
            }
            for(int i = a.Length + 1; i < s2.Length; i++)
            {
                result += (s2[i] - '0') * (float)Math.Pow(2, power2);
                power2--;
                
            }
            return ans + result;
        }
    }
}
