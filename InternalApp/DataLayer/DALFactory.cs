namespace DataLayer
{
    /// <summary>
    /// DataFactory class which implements factory pattern
    /// </summary>
    public class DALFactory
    {
        /// <summary>
        /// Creating object for DataAuthentication classes
        /// </summary>
        /// <returns></returns>
        public IDataAuthentication GetDataAuthObj()
        {
            return new DataAuthentication();    
        }
    }
}
