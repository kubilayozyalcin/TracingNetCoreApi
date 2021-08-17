using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Employee : EntityBase, IEntity
    {
        public string Identity { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsRevicer { get; set; }
        public bool IsStatus { get; set; }
        public string MobileDeviceImei { get; set; }

    }
}