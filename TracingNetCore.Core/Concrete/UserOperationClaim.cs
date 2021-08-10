using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Core.Concrete
{
    public class UserOperationClaim : CoreEntityBase, IEntity
    {
        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
    }
}
