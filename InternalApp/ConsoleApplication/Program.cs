/*
 * Console Application which implements three tire architecture
 */
using ConsoleApplication;
using BusinessModels;
using System.Text.RegularExpressions;

/// <summary>
/// Presentation layer of application
/// </summary>
class Program 
{
    public static void Main()
    { 
        Authentication auth = new Authentication();
        while (true)
        {
            Console.WriteLine(Literals.input);
            Console.WriteLine(Literals.pattern);

            string choice = Console.ReadLine();

            if (!Regex.IsMatch(choice, "[1-2]"))
            {
                Console.WriteLine(Literals.invalidOption);
            }
            else
            {
                int option = Int32.Parse(choice);
                switch (option)
                {
                    case (int)Option.LOGIN:
                        auth.Login();
                        break;
                    case (int)Option.REGISTER:
                        auth.Register();
                        break;
                    default:
                        Console.WriteLine(Literals.invalidOption);
                        break;
                }
            }
        }
    }
}



