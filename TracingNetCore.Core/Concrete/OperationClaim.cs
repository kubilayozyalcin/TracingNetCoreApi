using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Core.Concrete
{
    public class OperationClaim : CoreEntityBase, IEntity
    {
        public string Name { get; set; }
    }
}
