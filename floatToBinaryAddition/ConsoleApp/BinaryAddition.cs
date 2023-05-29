using System;
using System.Text;

/// <summary>
/// BinaryAddition class will perform binary additions and converts the resultant to float
/// </summary>
class BinaryAddition
{
    /// <summary>
    /// AdjustDecimalPoint method will adjust the decimal point in a string
    /// </summary>
    /// <param name="tp"></param>
    /// <param name="x"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public string AdjustDecimalPoint(Tuple<string, int> tp, int x, int len)
    {
        int diff = x - tp.Item2;
        string padStr = tp.Item1.PadLeft(diff + tp.Item1.Length, '0');
        int idx = 0;
        for (int i = 0; i < padStr.Length; i++)
        {
            if (padStr[i] == '.')
            {
                idx = i;
            }
        }
        string remStr = padStr.Remove(idx, 1);
        string insPointStr = remStr.Insert(1, ".");
        int lendiff = len - insPointStr.Length;
        if (lendiff > 0)
        {
            string res = insPointStr.PadRight(len, '0');
            return res;
        }
        return insPointStr;
    }

    /// <summary>
    /// AddBinary method will do addition of two binaries
    /// </summary>
    /// <param name="firstBinary"></param>
    /// <param name="secondBinary"></param>
    /// <returns></returns>
    public string AddBinary(string firstBinary, string secondBinary)
    {
        if (firstBinary.Length > secondBinary.Length)
        {
            secondBinary = secondBinary.PadRight(firstBinary.Length, '0');
        }
        if (firstBinary.Length < secondBinary.Length)
        {
            firstBinary = firstBinary.PadRight(secondBinary.Length, '0');
        }


        string a = firstBinary.Substring(2);
        string b = secondBinary.Substring(2);
        string c = firstBinary.Substring(0, 1);
        string d = secondBinary.Substring(0, 1);
        string result = string.Empty;
        string s = string.Empty;
        StringBuilder res = new StringBuilder(s);
        char carry = '0';
        for (int i = a.Length - 1; i >= 0; i--)
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
            else if (a[i] == '0' && b[i] == '0')
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
        for (int i = s.Length - 1; i >= 0; i--)
        {
            revStr += s[i];
        }
        if (c == "0" && d == "0")
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
        else if (c != d)
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
        else if (c == "1" && d == "1")
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

    /// <summary>
    /// BinaryToFloat method will convert final binary string to float
    /// </summary>
    /// <param name="s"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public float BinaryToFloat(string s, int x)
    {
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '.')
            {
                index = i;
            }
        }
        string insStr = s.Insert(index + 1 + x, ".");
        string remStr = insStr.Remove(index, 1);
        string finalStr = remStr.Substring(0, remStr.IndexOf('.'));
        int ans = 0;
        float result = 0f;
        int power1 = 0, power2 = -1;
        for (int i = finalStr.Length - 1; i >= 0; i--)
        {
            ans += (finalStr[i] - '0') * (int)Math.Pow(2, power1);
            power1++;
        }
        for (int i = finalStr.Length + 1; i < remStr.Length; i++)
        {
            result += (remStr[i] - '0') * (float)Math.Pow(2, power2);
            power2--;

        }
        return ans + result;
    }
}

