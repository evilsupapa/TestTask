using Identity.DataAccess.Repositories;
using Identity.Domain;
using Identity.Domain.User;
using Identity.Service;
using Identity.Service.Commands;
using Identity.Service.Extensions;
using Identity.Service.Managers;
using Identity.Service.Models;
using Identity.Service.Queries;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Managers
{
    public class UserManager : IUserManager
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;

        public UserManager(IUserRepository userRepository, IHashService hashService, ILogger logger)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _logger = logger;
        }

        public async Task<User> GetById(GetUserByIdQuery query)
        {
            var userEntity = await _userRepository.GetByCondition(x => x.Id == query.Id);
            return userEntity?.ToModel();
        }

        public async Task<User> GetByLogin(GetUserByLoginQuery query)
        {
            var userEntity = await _userRepository.GetByCondition(x => x.Login.ToLower().Equals(query.Login.ToLower()));
            return userEntity?.ToModel();
        }

        public async Task<IEnumerable<User>> FindByCountry(FindUsersByCountryQuery query)
        {
            var userEntities = await _userRepository.FindByCondition(x => x.Address.Country.ToLower().Equals(query.Country.ToLower()));
            return userEntities.Select(u => u.ToModel());
        }

        public async Task<User> Create(CreateUserCommand command)
        {
            try
            {
                var userEntity = await _userRepository.Create(new UserEntity
                {
                    Address = new AddressEntity
                    {
                        City = command.City,
                        Country = command.Country,
                        FlatNumber = command.FlatNumber,
                        PostalCode = command.PostalCode,
                        State = command.State,
                        Street = command.Street,
                        StreetNumber = command.StreetNumber
                    },
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Login = command.Login,
                    PasswordHash = _hashService.Hash(command.Password)
                });

                return userEntity.ToModel();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception while creating user: {@message}", ex.Message);
                return null;
            }
        }
    }
}