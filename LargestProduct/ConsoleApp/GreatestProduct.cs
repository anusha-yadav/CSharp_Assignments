using System;
using System.Collections.Generic;


/// <summary>
/// Product class is to find out the max product 4 adjacent digits in a number 
/// </summary>
class GreatestProduct
{
    /// <summary>
    /// GetProduct method will calculate the max product of 4 adjacent digits in a number
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public List<int> GetDigits(string num)
    {
        List<int> digits = new List<int>();
        int ans = 1, res = 0;
        for (int i = 0; i <= num.Length - 4; i++)
        {
            ans = ans * (num[i] - '0') * (num[i + 1] - '0') * (num[i + 2] - '0') * (num[i + 3] - '0');
            if (ans > res)
            {
                digits.Clear();
                res = ans;
                digits.Add(num[i] - '0');
                digits.Add(num[i + 1] - '0');
                digits.Add(num[i + 2] - '0');
                digits.Add(num[i + 3] - '0');
            }
            ans = 1;
        }
        return digits;
    }

    /// <summary>
    /// Display method is used to print the max product result and its corresponding numbers
    /// </summary>
    /// <param name="arr"></param>
    public int GetProduct(List<int> digits)
    {
        int size = digits.Count, ans = 1;
        for (int i = 0; i < size; i++)
        {
            ans = ans * digits[i];
        }
        return ans;
    }

    /// <summary>
    /// Displaying the output resultant of greatest product of 4 adjacent digits
    /// </summary>
    /// <param name="digits"></param>
    /// <param name="ans"></param>
    /// <returns></returns>
    public string Display(List<int> digits, int ans)
    {
        string result = digits[0] + "*" + digits[1] + "*" + digits[2] + "*" + digits[3] + "=" + ans;
        return result;
    }
}
