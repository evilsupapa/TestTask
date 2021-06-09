using Identity.Domain.User;
using Identity.Service.Models;

namespace Identity.Service.Extensions
{
    public static class UserExtension
    {
        public static User ToModel(this UserEntity userEntity)
        {
            return new User
            {
                Address = userEntity.Address?.ToModel(),
                FirstName = userEntity.FirstName,
                Id = userEntity.Id,
                LastName = userEntity.LastName,
                Login = userEntity.Login
            };
        }
    }
}
