namespace BusinessModels
{
    /// <summary>
    /// User class has properties
    /// </summary>
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string new_passwd { get; set; }
        public string confirm_passwd { get; set; }
    }
}