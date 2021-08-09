using System.Collections.Generic;
using TracingNetCore.Core.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        void Add(User user);

        User GetByEmail(string email);


    }
}
