namespace BusinessModels
{
    /// <summary>
    /// Literals class which has string logs
    /// </summary>
    public static class Literals
    {
        public static string input = "Please enter the option\n1. Login\n2. Registration";
        public static string pattern = "-----------------------";
        public static string noDatabase = "No Database\nPlease register yourself";
        public static string invalidOption = "Invalid Option";
        public static string username = "Enter username : ";
        public static string password = "Enter password : ";
        public static string phonenumber = "Enter phoneNumber : ";
        public static string email = "Enter email : ";
        public static string loginSucess = "Login Successfull !!!";
        public static string logout = "Press 'Q' to logout";
        public static string invalidPasswdCredentials = "Invalid username or password";
        public static string forgotPasswdChoice = "Press 1 for forgot password";
        public static string details = "Please enter username, password, phonenumber details..";
        public static string invalidUser = "Please enter valid username of atleast 6 characters\nwhich consists only lower case charcaters";
        public static string invalidPasswd = "Please enter valid password of atleast 8 characters\nwhich consists of atleast one uppercase";
        public static string invalidPhonenumber = "Please enter valid phone number of 10 digits";
        public static string invalidEmail = "Please enter valid email address";
        public static string signupSuccess = "Registration Sucessfull!!!";
        public static string detailsPresent = "User is already present, Please enter new details";
        public static string passwdUpdatedSuccess = "Password updated sucessfully";
        public static string passwdUpdatedFailure = "Invalid credentials";
        public static string newPasswd = "Enter new password : ";
        public static string confirmPasswd = "Confirm password : ";

        public static void DisplayObjDetails(User user)
        {
            Console.WriteLine(user.ToString());
        }
    }
}
