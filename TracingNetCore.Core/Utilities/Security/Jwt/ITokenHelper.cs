using System.Collections.Generic;
using TracingNetCore.Core.Concrete;

namespace TracingNetCore.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
