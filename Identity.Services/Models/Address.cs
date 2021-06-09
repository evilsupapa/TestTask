namespace Identity.Service.Models
{
    public class Address
    {
        public long Id { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string FlatNumber { get; set; }

        public string PostalCode { get; set; }
    }
}
