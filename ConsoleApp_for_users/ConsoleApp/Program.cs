using ConsoleApp;
using System;
using System.Text;


class App
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter\n1 for login\n2 for registration");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Login obj = new Login();
                    obj.Display();
                    break;
                case "2":
                    BuisnessClient bl = new BuisnessClient();
                    bl.AddData();
                    bl.DisplayDB();
                    break;
                default:
                    Console.ReadKey();
                    break;
            }
        }
    }
}
