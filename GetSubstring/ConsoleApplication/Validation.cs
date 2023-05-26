using System;

/// <summary>
/// Validation class for checking the inputs and displaying the output
/// </summary>
class Validation
{
    /// <summary>
    /// Checking if the input strings are of correct length
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public bool IsValid(string actualString, string subString)
    {
        if (actualString.Length < subString.Length || actualString.Length == 0 && subString.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
