using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class DeviceType : EntityBase, IEntity
    {
        public string DeviceTypeName { get; set; }
    }
}