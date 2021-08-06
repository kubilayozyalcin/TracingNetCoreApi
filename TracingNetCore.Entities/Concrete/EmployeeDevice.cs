using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class EmployeeDevice : EntityBase, IEntity
    {
        public string DeviceIdentity { get; set; }
        public string DeviceName { get; set; }

        public int EmployeeId { get; set; }

        public int DeviceId { get; set; }
    }
}