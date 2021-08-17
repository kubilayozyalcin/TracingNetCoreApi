using System.Collections.Generic;
using TacingNetCore.Core.DataAccess;
using TracingNetCore.Core.Concrete;

namespace TacingNetCore.DataAccess.Abstractions
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
