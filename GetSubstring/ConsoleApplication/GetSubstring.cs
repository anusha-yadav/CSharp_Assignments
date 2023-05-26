using System;
using System.Collections.Generic;

/// <summary>
/// GetSubstring class will check for the occurences of a substring in a string and displaying the output
/// </summary>
class GetSubstring
{
    /// <summary>
    /// GetIndexes will check for the occurences of a substring in a string
    /// </summary>
    /// <param name="actualString"></param>
    /// <param name="subString"></param>
    /// <returns></returns>
    public List<int> GetIndexes(string actualString, string subString)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < actualString.Length; i++)
        {
            int index = -1;
            for (int j = 0; j < subString.Length; j++)
            {
                if (actualString[i + j] != subString[j])  // checking for every ith occurence of a string
                {
                    index = -1;
                    break;
                }
                index = i;
            }
            if (index != -1)
            {
                indexes.Add(index);
            }
        }
        return indexes;
    }
}


