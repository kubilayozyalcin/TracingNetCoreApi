using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IDeviceTypeService
    {
        IDataResult<DeviceType> GetById(int deviceTypeId);
        IDataResult<List<Device>> GetDevices(int deviceTypeId);
        IDataResult<List<DeviceType>> GetList();
        IResult Add(DeviceType deviceType);
        IResult Update(DeviceType deviceType);
        IResult Delete(DeviceType deviceType);
    }
}
