namespace BusinessModels
{
    /// <summary>
    /// User class which has properties
    /// </summary>
    public class User
    {
        public string name { get; set; }
        public string mobile { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string new_passwd { get; set; }
        public string confirm_passwd { get; set; }
    }
}
