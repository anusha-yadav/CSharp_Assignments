namespace BusinessLayer
{
    /// <summary>
    /// BAL Factory Class
    /// </summary>
    public class BALFactory
    {
        /// <summary>
        /// Creating Object for BAL Authentication Class
        /// </summary>
        /// <returns></returns>
        public BALAuthentication GetBALAuthenticationObj()
        {
            return new BALAuthentication();
        }
    }
}
