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
    public class DeviceManager : IDeviceService
    {
        private IDeviceDal deviceDal;
        private IRequestDal requestDal;

        public DeviceManager(IDeviceDal deviceDal, IRequestDal requestDal)
        {
            this.deviceDal = deviceDal;
            this.requestDal = requestDal;
        }

        // [TransactionScopeAspect] // When you use it if your transactions not Commit your transactions is Rollback

        // [CacheRemoveAspect("IDeviceService.Get")] if you add new device you must remove cache and re-loading cache for new device add cache 
        // and if you want remove another business manager cache you will must change interface name in this manager code block

        [ValidationAspect(typeof(DeviceValidator), Priority = 1)]
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


        // [CacheAspect(duration:1)] if you want invoke caching any processes you must add this [CacheAspect] header processes
        // and then you can set the duration in minutes.
        [CacheAspect(duration: 1)]
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

        public IDataResult<List<Request>> GetRequests(int employeeId)
        {
            return new SuccessDataResult<List<Request>>(requestDal.GetList(x => x.EmployeeId == employeeId).ToList());
        }
    }
}
