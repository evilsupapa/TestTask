using System;

namespace Identity.Domain.User
{
    public class UserEntity
    {
        public long Id { get; set; }
   
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string Login { get; set; }
        
        public AddressEntity Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}