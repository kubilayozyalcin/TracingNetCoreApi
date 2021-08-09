using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IEmployeeService
    {
        IDataResult<Employee> GetById(int employeeId);
        IDataResult<List<Employee>> GetList();
        IResult Add(Employee employee);
        IResult Update(Employee employee);
        IResult Delete(Employee employee);
      
    }
}
