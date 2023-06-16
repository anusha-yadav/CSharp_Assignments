using BusinessLayer;
using BusinessModels;

namespace ConsoleApplication
{
    /// <summary>
    /// LogMessages class
    /// </summary>
    public class LogMessages
    {
        /// <summary>
        /// Login display method
        /// </summary>
        public void Login()
        {
            User user = new User();
            Authentication authentication = new Authentication();
            Literals.DisplayWrite((Literals.username));
            user.username = Console.ReadLine();
            Literals.DisplayWrite((Literals.password));
            user.password = Console.ReadLine();

            if (authentication.IsLogin(user))
            {
                Literals.DisplayWriteLine((Literals.loginSucess));
                Literals.DisplayWriteLine((Literals.logout));
                string choice = Console.ReadLine();
                if(choice == "Q")
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Literals.DisplayWriteLine((Literals.invalidPasswdCredentials));
                Literals.DisplayWriteLine((Literals.forgotPasswdChoice));
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    ForgotPassword();
                }
            }
        }

        /// <summary>
        /// Register display method
        /// </summary>
        /// <returns></returns>
        public int Register()
        {
            User user = new User();
            int flag = 0;
            BALValidation validation = new BALValidation();
            Authentication auth = new Authentication();
            Literals.DisplayWriteLine((Literals.details));
            Literals.DisplayWrite((Literals.username));
            user.username = Console.ReadLine();
            Literals.DisplayWrite((Literals.password));
            user.password = Console.ReadLine();
            bool tempOne = true;
            while (tempOne)
            {
                if (validation.IsValidPasswd(user.password))
                {
                    tempOne = false;
                    break;
                }
                else
                {
                    Literals.DisplayWriteLine((Literals.invalidPasswd));
                    user.password = Console.ReadLine();
                }
            }
            Literals.DisplayWrite((Literals.phonenumber));
            user.phoneNumber = Console.ReadLine();
            bool tempTwo = true;
            while (tempTwo)
            {
                if (validation.IsValidPhoneNo(user.phoneNumber))
                {
                    tempTwo = false;
                    break;
                }
                else
                {
                    Literals.DisplayWriteLine((Literals.invalidPhonenumber));
                    user.phoneNumber = Console.ReadLine();
                }
            }
            Literals.DisplayWrite((Literals.email));
            user.email = Console.ReadLine();
            bool tempThree = true;
            while (tempThree)
            {
                if (validation.IsValidEmail(user.email))
                {
                    tempThree = false;
                    break;
                }
                else
                {
                    Literals.DisplayWriteLine((Literals.invalidEmail));
                    user.email = Console.ReadLine();
                }
            }
            if (auth.IsRegistered(user))
            {
                flag = 1;
                Literals.DisplayWriteLine((Literals.signupSuccess));
            }
            else
            {
                Literals.DisplayWriteLine((Literals.detailsPresent));
            }
            return flag;
        }

        /// <summary>
        /// Forgot password display method
        /// </summary>
        public void ForgotPassword()
        {
            User user = new User();
            Authentication authentication = new Authentication();
            Literals.DisplayWrite((Literals.username));
            user.username = Console.ReadLine();
            Literals.DisplayWrite((Literals.newPasswd));
            user.new_passwd = Console.ReadLine();
            Literals.DisplayWrite((Literals.confirmPasswd));
            user.confirm_passwd = Console.ReadLine();

            if (authentication.IsCorrectPasswd(user))
            {
                Literals.DisplayWriteLine((Literals.passwdUpdatedSuccess));
            }
            else
            {
                Literals.DisplayWriteLine((Literals.passwdUpdatedFailure));
            }
        }
    }
}
