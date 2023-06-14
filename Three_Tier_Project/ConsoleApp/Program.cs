using System;
using System.Text;
using BusinessTier;
class PresentationLayer
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter\n1. Login\n2. For Registeration");
            string choice = Console.ReadLine();
            int flag = 0;
            switch (choice)
            {
                case "1":
                    UserBL bl = new UserBL();
                    bl.LoginDisplay();
                    break;
                case "2":
                    UserBL bL = new UserBL();
                    bL.Registration_Display();
                    break;
                default:
                    break;
            }
        }
    }
}