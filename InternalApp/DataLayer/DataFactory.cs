namespace DataLayer
{
    /// <summary>
    /// DataFactory class which implements factory pattern
    /// </summary>
    public class DataFactory
    {
        /// <summary>
        /// Creating object for DataAuthentication classes
        /// </summary>
        /// <returns></returns>
        public IDataAuthentication GetDataObj()
        {
            return new DataAuthentication();    
        }
    }
}
