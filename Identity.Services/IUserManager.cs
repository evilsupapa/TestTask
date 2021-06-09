using Identity.Service.Commands;
using Identity.Service.Models;
using Identity.Service.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Service.Managers
{
    public interface IUserManager
    {
        Task<User> GetById(GetUserByIdQuery query);
        Task<User> GetByLogin(GetUserByLoginQuery query);
        
        Task<IEnumerable<User>> FindByCountry(FindUsersByCountryQuery query);
        
        Task<User> Create(CreateUserCommand command);
    }
}