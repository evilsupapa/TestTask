using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.API.Entities;

namespace Identity.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> Get();

        UserEntity Save(UserEntity user);
    }
}