using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IResult Add(Device device);
        IResult Update(Device device);
        IResult Delete(Device device);
    }
}
