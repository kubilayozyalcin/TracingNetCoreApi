using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IRequestService
    {
        IDataResult<Request> GetById(int deviceId);
        IDataResult<List<Request>> GetList();
        IDataResult<List<Request>> GetByEmployeeId(int employeeId);
        IDataResult<List<Request>> GetByDeviceId(int deviceId);
        IResult Add(Request device);
        IResult Update(Request device);
        //IResult Delete(Request device);
    }
}
