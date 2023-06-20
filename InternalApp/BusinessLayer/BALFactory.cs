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
        public IBALAuthentication GetBALAuthObj()
        {
            return new BALAuthentication();
        }

        /// <summary>
        /// Returning object for IBALValidation interface
        /// </summary>
        /// <returns></returns>
        public IBALValidation GetBALValidObj()
        {
            return new BALValidation();
        }
    }
}
