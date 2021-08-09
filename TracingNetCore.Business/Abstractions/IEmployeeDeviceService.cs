using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IEmployeeDeviceService
    {
        IDataResult<EmployeeDevice> GetById(int employeeDeviceId);
        IDataResult<List<EmployeeDevice>> GetList();
        IResult Add(EmployeeDevice employeeDevice);
        IResult Delete(EmployeeDevice employeeDevice);
        IDataResult<List<EmployeeDevice>> GetByEmployeeDevice(int employeeId);
        IDataResult<List<EmployeeDevice>> GetByDevice(int deviceId);
    }
}
