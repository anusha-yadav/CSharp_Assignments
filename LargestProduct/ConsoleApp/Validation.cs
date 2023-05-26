using System;
using System.Collections.Generic;

/// <summary>
/// Validation class for checking the inputs
/// </summary>
class Validation
{
    /// <summary>
    /// Checking if the input is of correct size and checking if any characters are present
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsValid(string num)
    {
        if ((num.Length == 4 && num[0] == '-') || num.Length < 4)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '-' || num[i] > 57)
                {
                    return false;
                }
            }
            return true;
        }
    }
}



