using System.Threading.Tasks;
using Identity.API.Entities;

namespace Identity.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public AddressEntity Save(AddressEntity address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }
    }
}