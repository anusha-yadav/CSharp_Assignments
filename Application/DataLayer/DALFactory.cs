namespace DataLayer
{
    /// <summary>
    /// DAL Factory Class 
    /// </summary>
    public class DALFactory
    {
        /// <summary>
        /// Creating Objects for DAL Authentication
        /// </summary>
        /// <returns></returns>
        public IDALAuthentication GetDALObject()
        {
            return new DALAuthentication();
        }
    }
}
