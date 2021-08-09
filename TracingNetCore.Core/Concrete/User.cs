using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Core.Concrete
{
    public class User : CoreEntityBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public bool IsStatus { get; set; }
    }
}
