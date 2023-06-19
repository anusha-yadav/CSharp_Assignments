namespace DataLayer
{
    /// <summary>
    /// DataFactory class
    /// </summary>
    public class DataFactory
    {
        /// <summary>
        /// Creating objects for DataAuthentication classes
        /// </summary>
        /// <returns></returns>
        public IDataAuthentication GetDataObj()
        {
            return new DataAuthentication();    
        }
    }
}
