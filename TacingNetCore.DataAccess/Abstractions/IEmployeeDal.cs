using System.Collections.Generic;
using TacingNetCore.Core.DataAccess;
using TracingNetCore.Core.Concrete;
using TracingNetCore.Entities.Concrete;

namespace TacingNetCore.DataAccess.Abstractions
{
    public interface IEmployeeDal : IEntityRepository<Employee> 
    {
      

    }
}
