using System;
using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Constants;
using TracingNetCore.Business.ValidationRules.FluentValidation;
using TracingNetCore.Core.Aspects.AutoFac.Caching;
using TracingNetCore.Core.Aspects.AutoFac.Transaction;
using TracingNetCore.Core.Aspects.AutoFac.Validation;
using TracingNetCore.Core.CrossCuttingConcerns.Validation.FluentValidation;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Concrete
{
    public class DeviceTypeManager : IDeviceTypeService
    {
        private IDeviceTypeDal deviceTypeDal;
        private IDeviceDal deviceDal;

        public DeviceTypeManager(IDeviceTypeDal deviceTypeDal)
        {
            this.deviceTypeDal = deviceTypeDal;
            this.deviceDal = deviceDal;
        }

        // [TransactionScopeAspect] // When you use it if your transactions not Commit your transactions is Rollback

        // [CacheRemoveAspect("IDeviceService.Get")] if you add new device you must remove cache and re-loading cache for new device add cache 
        // and if you want remove another business manager cache you will must change interface name in this manager code block
        // [ValidationAspect(typeof(DeviceValidator), Priority = 1)]

        // [CacheAspect(duration:1)] if you want invoke caching any processes you must add this [CacheAspect] header processes
        // and then you can set the duration in minutes.
        // [CacheAspect(duration: 1)]

        public IResult Add(DeviceType deviceType)
        {
            deviceTypeDal.Add(deviceType);
            return new SuccessResult(DataMessages.AddDeviceType);
        }

        public IResult Update(DeviceType deviceType)
        {
            deviceTypeDal.Update(deviceType);
            return new SuccessResult(DataMessages.UpdateDeviceType);
        }

        public IResult Delete(DeviceType deviceType)
        {
            deviceTypeDal.Delete(deviceType);
            return new SuccessResult(DataMessages.DeleteDeviceType);
        }

        public IDataResult<DeviceType> GetById(int deviceTypeId)
        {
            return new SuccessDataResult<DeviceType>(deviceTypeDal.Get(x => x.Id == deviceTypeId));
        }

        public IDataResult<List<DeviceType>> GetList()
        {
            return new SuccessDataResult<List<DeviceType>>(deviceTypeDal.GetList().ToList());
        }

        public IDataResult<List<Device>> GetDevices(int deviceTypeId)
        {
            return new SuccessDataResult<List<Device>>(deviceDal.GetList(x => x.DeviceTypeId == deviceTypeId).ToList());
        }
    }
}
