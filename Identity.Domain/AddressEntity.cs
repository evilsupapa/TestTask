using System;

namespace Identity.Domain
{
    public class AddressEntity
    {
        public long Id { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string FlatNumber { get; set; }

        public string PostalCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}