using System.Collections.Generic;
using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Employee : EntityBase, IEntity
    {
        public string Identity { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePhoto { get; set; }

        public bool IsRevicer { get; set; }

        public string MobileDeviceImei { get; set; }

        public int RoleId { get; set; }

        //public ICollection<EmployeeDevice> EmployeeDevices { get; set; }
        //public ICollection<Request> Requests { get; set; }
    }
}