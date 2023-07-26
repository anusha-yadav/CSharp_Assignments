using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public static class Literals
    {
        public static string usernameExists = "Username already exists.\\nPlease choose a different username.";
        public static string emailExists = "Supplied email address has already been used.";
        public static string registrationSuccess = "Registration successfull.\\nUser Id: ";
        public static string encodeMsg = "Error in base64Encode";
        public static string userExistsQuery = "Select username from Info_DB where username = @username";
        public static string updatePasswdQuery = "UPDATE Info_DB SET Password = @newpasswd WHERE Username = @username";
        public static string databaseError = "database authentication problem ";
        public static string loginUserQuery = "select * from Info_DB where Username = @username and Password = @password";
    }


    
}
