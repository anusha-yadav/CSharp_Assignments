using System;
using System.Text;
using BusinessTier;
class PresentationLayer
{
    public static void Main()
    {
        UserBL bL = new UserBL();
        while (true)
        {
            Console.WriteLine("Please enter\n1. Login\n2. For Registeration");
            string choice = Console.ReadLine();
            int flag = 0;
            switch (choice)
            {
                case "1":
                    bL.LoginDisplay();
                    break;
                case "2":
                    bL.Registration_Display();
                    break;
                default:
                    break;
            }
        }
    }
}