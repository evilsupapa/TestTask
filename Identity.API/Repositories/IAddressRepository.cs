using Identity.API.Entities;

namespace Identity.API.Repositories
{
    public interface IAddressRepository
    {
        AddressEntity Save(AddressEntity address);
    }
}