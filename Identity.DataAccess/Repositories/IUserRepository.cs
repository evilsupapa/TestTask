using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Identity.Domain.User;

namespace Identity.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByCondition(Expression<Func<UserEntity, bool>> filter);
        Task<IEnumerable<UserEntity>> FindByCondition(Expression<Func<UserEntity, bool>> filter);

        Task<UserEntity> Create(UserEntity user);
    }
}