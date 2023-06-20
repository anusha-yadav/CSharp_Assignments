using BusinessLayer;
using BusinessModels;

namespace ConsoleApplication
{
    /// <summary>
    /// Authentication class to check the inputs
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Authenticating Login user
        /// </summary>
        public void Login()
        {
            User user = new User();
            BALFactory balFactory = new();
            IBALAuthentication authObj = balFactory.GetBALAuthObj();

            Console.Write(Literals.username);
            user.username = Console.ReadLine();
            Console.Write(Literals.password);
            user.password = Console.ReadLine();

            if (authObj.IsLogin(user))
            {
                Console.WriteLine(Literals.loginSucess);
                Console.WriteLine(Literals.logout);
                string choice = Console.ReadLine();
                if (choice == "Q")
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
        /// Authenticating register user
        /// </summary>
        /// <param name="user"></param>
        public void Register()
        {
            User user = new User();

            BALFactory factory = new BALFactory();
            IBALValidation validation = factory.GetBALValidObj();
            IBALAuthentication authObj = factory.GetBALAuthObj();

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

            if (authObj.IsRegistered(user))
            {
                Console.WriteLine(Literals.signupSuccess);
            }
            else
            {
                Console.WriteLine(Literals.detailsPresent);
            }
        }

        /// <summary>
        /// Forgot password display method
        /// </summary>
        public void ForgotPassword()
        {
            BALFactory balFactory = new();
            IBALAuthentication authObj = balFactory.GetBALAuthObj();
            IBALValidation validObj = balFactory.GetBALValidObj();

            User user = new User();

            Console.Write(Literals.username);
            user.username = Console.ReadLine();
            Console.Write(Literals.newPasswd);
            user.new_passwd = Console.ReadLine();
            Console.Write(Literals.confirmPasswd);
            user.confirm_passwd = Console.ReadLine();

            if (authObj.IsValidPasswd(user))
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
