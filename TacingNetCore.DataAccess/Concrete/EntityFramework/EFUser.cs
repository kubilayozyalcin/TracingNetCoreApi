using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TacingNetCore.DataAccess.Concrete.EntityFramework.Contexts;
using TracingNetCore.Core.Concrete;
using TracingNetCore.Core.DataAccess.EntityFramework;

namespace TacingNetCore.DataAccess.Concrete.EntityFramework
{
    public class EFUser : EFEntityRepositoryBase<User, TracingContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TracingContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}
