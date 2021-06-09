using Identity.API.Models;
using Identity.Service.Commands;

namespace Identity.API.Extensions
{
    public static class UserExtensions
    {
        public static CreateUserCommand ToCreateUserCommand(this CreateUserRequest userRequest)
        {
            return new CreateUserCommand
            {
                City = userRequest.City,
                Country = userRequest.Country,
                FirstName = userRequest.FirstName,
                FlatNumber = userRequest.FlatNumber,
                LastName = userRequest.LastName,
                Login = userRequest.Login,
                Password = userRequest.Password,
                PostalCode = userRequest.PostalCode,
                State = userRequest.State,
                Street = userRequest.Street,
                StreetNumber = userRequest.StreetNumber
            };
        }
    }
}
