namespace Identity.Service.Models
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public Address Address { get; set; }
    }
}
