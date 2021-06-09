using Identity.Data;
using Identity.Domain;
using System.Threading.Tasks;

namespace Identity.DataAccess.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<AddressEntity> Create(AddressEntity address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }
    }
}