using System;
using System.Collections.Generic;

/// <summary>
/// LogMessages class for displaying the messages and output on the console
/// </summary>
class LogMessages
{
    /// <summary>
    /// Display method for validation class
    /// </summary>
    /// <param name="msg"></param>
    public void ValidationDisplay(bool msg)
    {
        if (!msg)
        {
            Console.WriteLine("Please enter valid lengths for actual string and substring");
        }
    }

    /// <summary>
    /// GetIndexes Display method for displaying the output on the console
    /// </summary>
    /// <param name="indexes"></param>
    public void GetIndexesDisplay(List<int> indexes)
    {
        if (indexes.Count == 0)
        {
            Console.WriteLine("Substring is not present in actual string");
        }
        else
        {
            Console.WriteLine("No. of times occured = " + indexes.Count);
            Console.Write("Index positions = ");
            for (int i = 0; i < indexes.Count; i++)
            {
                Console.Write(indexes[i] + " ");
            }
        }
    }
}


