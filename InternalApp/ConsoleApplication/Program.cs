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
    /// enum Option set for login and sigup cases
    /// </summary>
    public enum Option
    {
        LOGIN = 1 , SIGNUP
    }

    public static void Main()
    { 
        LogMessages log = new LogMessages();
        int flag = 0;
        while (true)
        {
            Console.WriteLine(Literals.input);
            Console.WriteLine(Literals.pattern);
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case (int)Option.LOGIN:
                    if (flag == 0)
                    {
                    Console.WriteLine(Literals.noDatabase);
                        break;
                    }
                    log.Login();
                    break;
                case (int)Option.SIGNUP:
                    flag = log.Register();
                    break;
                default:
                    Console.WriteLine(Literals.invalidOption);
                    break;
            }
        }
    }
}



