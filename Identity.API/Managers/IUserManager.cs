using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.API.Entities;
using Identity.API.Models;

namespace Identity.API.Managers
{
    public interface IUserManager
    {
        Task<UserEntity> GetByLogin(string login);
        
        Task<IEnumerable<UserEntity>> GetByCountry(string country);
        
        Task Create(UserRequest request);
    }
}