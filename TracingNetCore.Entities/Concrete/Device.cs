using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Device : EntityBase, IEntity
    {
        public string DeviceIdentity { get; set; }
        public int RegionId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceName { get; set; }
        public bool Maintenance { get; set; }
        public string DeviceStatus { get; set; }

    }
}