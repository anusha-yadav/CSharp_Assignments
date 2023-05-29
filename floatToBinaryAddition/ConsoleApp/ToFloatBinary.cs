using System;
using System.Collections.Generic;

/// <summary>
/// The following class will convert float number to binary string
/// </summary>
class ToFloatBinary
{
    /// <summary>
    /// To reverse string characters in a string
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string RevString(string str)
    {
        string revStr = string.Empty;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            revStr += str[i];
        }
        return revStr;
    }

    /// <summary>
    /// ToBinary method will convert the integer part of float to binary
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public string ToBinary(float m)
    {
        int n = (int)m;
        if (n == 0)
        {
            return "0";
        }
        else
        {
            string getBinary = string.Empty;
            while (n != 0)
            {
                getBinary += (char)n % 2;
                n /= 2;
            }
            return getBinary;
        }
    }

    /// <summary>
    /// ToDecimalBinary method will convert the fractional part of a number to binary
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public string ToDecimalBinary(float m)
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

    /// <summary>
    /// getTotal method will concatenate results of ToBinary and ToDecimal methods
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public string GetTotal(string s1, string s2)
    {
        string total = s1 + "." + s2;
        return total;
    }

    /// <summary>
    /// Creating tuple of string and integer which stores the decimal point adjusting string and exponent value in integer
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public Tuple<string, int> PointAdjustment(string str)
    {
        int index = 0, point = 0, temp;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == 1)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '.')
            {
                point = i;
                break;
            }
        }
        temp = point - index - 1;
        string pointRemStr = str.Remove(point, 1);
        string res = pointRemStr.Insert(index + 1, ".");
        Tuple<string, int> tp = new Tuple<string, int>(res, temp);
        return tp;
    }
}

