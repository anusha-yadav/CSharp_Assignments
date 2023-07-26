namespace BusinessLayer
{
    public class BALFactory
    {
        public BALAuthentication GetBALAuthenticationObj()
        {
            return new BALAuthentication();
        }
    }
}
