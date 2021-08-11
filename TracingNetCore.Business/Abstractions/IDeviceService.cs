using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IDeviceService
    {
        IDataResult<Device> GetById(int deviceId);
        IDataResult<List<Device>> GetList();
        IDataResult<List<Device>> GetByRegionId(int regionId);
        IDataResult<List<Device>> GetByTypeId(int typeId);
        IDataResult<List<Request>> GetRequests(int deviceId);
        IResult Add(Device device);
        IResult Update(Device device);
        IResult Delete(Device device);
    }
}
