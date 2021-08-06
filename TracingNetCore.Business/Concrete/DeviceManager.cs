using System;
using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Constants;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        private IDeviceDal deviceDal;

        public DeviceManager(IDeviceDal deviceDal)
        {
            this.deviceDal = deviceDal;
        }

        public IResult Add(Device device)
        {
            deviceDal.Add(device);
            return new SuccessResult(DataMessages.AddDevice);
        }

        public IResult Update(Device device)
        {
            deviceDal.Update(device);
            return new SuccessResult(DataMessages.UpdateDevice);
        }

        public IResult Delete(Device device)
        {
            deviceDal.Delete(device);
            return new SuccessResult(DataMessages.DeleteDevice);
        }

        public IDataResult<Device> GetById(int deviceId)
        {
            return new SuccessDataResult<Device>(deviceDal.Get(x => x.Id == deviceId));
        }

        public IDataResult<List<Device>> GetByRegionId(int regionId)
        {
            return new SuccessDataResult<List<Device>>(deviceDal.GetList(x => x.RegionId == regionId).ToList());
                
        }

        public IDataResult<List<Device>> GetByTypeId(int typeId)
        {
            return new SuccessDataResult<List<Device>>(deviceDal.GetList(x => x.DeviceTypeId == typeId).ToList());
        }

        public IDataResult<List<Device>> GetList()
        {
            return new SuccessDataResult<List<Device>>(deviceDal.GetList().ToList());
        }


    }
}
