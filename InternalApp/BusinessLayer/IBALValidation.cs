namespace BusinessLayer
{
    /// <summary>
    /// Interface for BALVAlidation class
    /// </summary>
    public interface IBALValidation
    {
        public bool IsValidUsername(string username);
        public bool IsValidPasswd(string password);
        public bool IsValidEmail(string email);
        public bool IsValidPhoneNo(string phoneNumber);
    }
}
