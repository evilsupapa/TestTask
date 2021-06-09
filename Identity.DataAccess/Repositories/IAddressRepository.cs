using Identity.Domain;
using System.Threading.Tasks;

namespace Identity.DataAccess.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressEntity> Create(AddressEntity address);
    }
}