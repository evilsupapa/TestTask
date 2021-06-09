using Identity.Domain;
using Identity.Service.Models;

namespace Identity.Service.Extensions
{
    public static class AddressExtension
    {
        public static Address ToModel(this AddressEntity addressEntity)
        {
            return new Address
            {
                City = addressEntity.City,
                Country = addressEntity.Country,
                FlatNumber = addressEntity.FlatNumber,
                Id = addressEntity.Id,
                PostalCode = addressEntity.PostalCode,
                State = addressEntity.State,
                Street = addressEntity.Street,
                StreetNumber = addressEntity.StreetNumber
            };
        }
    }
}
