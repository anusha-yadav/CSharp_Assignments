/*
 * Console Application which implements three tire architecture
 */
using ConsoleApplication;
using BusinessModels;

/// <summary>
/// Presentation layer of application
/// </summary>
class Program
{
    /// <summary>
    /// Main method of the class
    /// </summary>
    public static void Main()
    { 
        LogMessages log = new LogMessages();
        int flag = 0;
        while (true)
        {
            Literals.DisplayWriteLine((Literals.input));
            Literals.DisplayWriteLine((Literals.pattern));
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (flag == 0)
                    {
                    Literals.DisplayWriteLine((Literals.noDB));
                        break;
                    }
                    log.Login();
                    break;
                case "2":
                    flag = log.Register();
                    break;
                default:
                    Literals.DisplayWriteLine((Literals.invalidOption));
                    break;
            }
        }
    }
}



