namespace E_Commerce_WebApplication.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string RecipientName { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
