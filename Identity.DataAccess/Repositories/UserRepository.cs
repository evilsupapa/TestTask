using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Identity.Data;
using Identity.Domain.User;
using Microsoft.EntityFrameworkCore;


namespace Identity.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<UserEntity> GetByCondition(Expression<Func<UserEntity, bool>> filter)
        {
             return await _context.Users.Include(u => u.Address).Where(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserEntity>> FindByCondition(Expression<Func<UserEntity, bool>> filter)
        {
            return await _context.Users.Include(u => u.Address).Where(filter).ToListAsync();
        }

        public async Task<UserEntity> Create(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}