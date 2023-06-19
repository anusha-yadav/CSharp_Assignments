namespace BusinessLayer
{
    /// <summary>
    /// BALFactory class which implements factory pattern
    /// </summary>
    public class BALFactory
    {
        /// <summary>
        /// Returning object for IBALAuthentication interface
        /// </summary>
        /// <returns></returns>
        public IBALAuthentication GetBALAuthenticationObj()
        {
            return new BALAuthentication();
        }

        /// <summary>
        /// Returning object for IBALValidation interface
        /// </summary>
        /// <returns></returns>
        public IBALValidation GetBALValidationObj()
        {
            return new BALValidation();
        }
    }
}
