using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        public string RoleName { get; set; }
    }
}