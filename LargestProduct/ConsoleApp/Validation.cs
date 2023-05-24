using System;

namespace ConsoleApp
{
    //Validation class for checking the inputs
    class Validation
    {
        //Checking if the input is of correct size
        public bool IsValid(string s)
        {
            if (s.Length == 4 && s[0] == '-')
            {
                return false;
            }
            if (s.Length < 4 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Displaying the messages and creating the object for product class
        public void Display(string s)
        {
            if (IsValid(s) == false)
            {
                Console.WriteLine("Please enter valid input of minimum size of 4 digits.");
            }
            else
            {
                Product obj = new Product();
                int res = obj.GetProduct(s);
                obj.Display(res);
            }
        }
    }
}
