using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Identity.API.Entities;
using Identity.API.Managers;
using Identity.API.Models;
using Identity.API.Repositories;

namespace Identity.API.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IUserRepository _userRepository;

        public UsersController(IUserManager userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        
        [HttpGet("GetUserById")]
        public UserEntity GetById(long id)
        {
            return _userRepository.Get().Result.First(u => u.Id == id);
        }   

        [HttpGet("GetUserByLogin")]
        public UserEntity GetByLogin(string login)
        {
             return _userManager.GetByLogin(login).Result;
        }

        [HttpGet("GetUsersByCountry")]
        public IEnumerable<UserEntity> GetByCountry(string country)
        {
            return _userManager.GetByCountry(country).Result;
        }

        [HttpPost("CreateUser")]
        public void Create([FromQuery] UserRequest request)
        {
            _userManager.Create(request);
        }
    }
}