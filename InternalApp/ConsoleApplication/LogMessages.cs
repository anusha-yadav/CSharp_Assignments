using BusinessLayer;
using BusinessModels;

namespace ConsoleApplication
{
    /// <summary>
    /// LogMessages class for login, signup and forgot password methods
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
            Console.Write(Literals.username);
            user.username = Console.ReadLine();
            Console.Write(Literals.password);
            user.password = Console.ReadLine();

            if (authentication.IsLogin(user))
            {
                Console.WriteLine(Literals.loginSucess);
                Console.WriteLine(Literals.logout);
                string choice = Console.ReadLine();
                if(choice == "Q")
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine(Literals.invalidPasswdCredentials);
                Console.WriteLine(Literals.forgotPasswdChoice);
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
            BALFactory factory = new BALFactory();
            IBALValidation validation = factory.GetBALValidationObj();
            Authentication auth = new Authentication();

            Console.WriteLine(Literals.details);
            Console.Write(Literals.username);
            user.username = Console.ReadLine();
            bool isUser = true;
            while (isUser)
            {
                if (validation.IsValidUsername(user.username))
                {
                    isUser = false;
                    break;
                }
                else
                {
                    Console.WriteLine(Literals.invalidUser);
                    user.username = Console.ReadLine();
                }
            }

            Console.Write(Literals.password);
            user.password = Console.ReadLine();
            bool isCorrectPasswd = true;
            while (isCorrectPasswd)
            {
                if (validation.IsValidPasswd(user.password))
                {
                    isCorrectPasswd = false;
                    break;
                }
                else
                {
                    Console.WriteLine(Literals.invalidPasswd);
                    user.password = Console.ReadLine();
                }
            }

            Console.Write(Literals.phonenumber);
            user.phoneNumber = Console.ReadLine();
            bool isCorrectPhoneNo = true;
            while (isCorrectPhoneNo)
            {
                if (validation.IsValidPhoneNo(user.phoneNumber))
                {
                    isCorrectPhoneNo = false;
                    break;
                }
                else
                {
                    Console.WriteLine(Literals.invalidPhonenumber);
                    user.phoneNumber = Console.ReadLine();
                }
            }

            Console.Write(Literals.email);
            user.email = Console.ReadLine();
            bool isCorrectEmail = true;
            while (isCorrectEmail)
            {
                if (validation.IsValidEmail(user.email))
                {
                    isCorrectEmail = false;
                    break;
                }
                else
                {
                    Console.WriteLine(Literals.invalidEmail);
                    user.email = Console.ReadLine();
                }
            }

            if (auth.IsRegistered(user))
            {
                flag = 1;
                Console.WriteLine(Literals.signupSuccess);
            }
            else
            {
                Console.WriteLine(Literals.detailsPresent);
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
            Console.Write(Literals.username);
            user.username = Console.ReadLine();
            Console.Write(Literals.newPasswd);
            user.new_passwd = Console.ReadLine();
            Console.Write(Literals.confirmPasswd);
            user.confirm_passwd = Console.ReadLine();

            if (authentication.IsCorrectPasswd(user))
            {
                Console.WriteLine(Literals.passwdUpdatedSuccess);
            }
            else
            {
                Console.WriteLine(Literals.passwdUpdatedFailure);
            }
        }
    }
}
