using System.ComponentModel.DataAnnotations;

namespace Web_App.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string Street { get;set; }   
        public string City { get;set; } 
        public string PostalCode { get;set; }
        public int UserId { get;set; }
        public virtual User User { get;set; }
    }
}
