using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IEmployeeService
    {
        IDataResult<Employee> GetById(int employeeId);
        IDataResult<List<Employee>> GetList();
        IDataResult<List<EmployeeDevice>> GetEmployeeDevices(int employeeId);
        IDataResult<List<Request>> GetRequests(int employeeId);
        IResult Add(Employee employee);
        IResult Update(Employee employee);
        IResult Delete(Employee employee);

    }
}
