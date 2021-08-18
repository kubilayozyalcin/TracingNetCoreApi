using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.BusinessAspect.AutoFac;
using TracingNetCore.Business.Constants;
using TracingNetCore.Business.ValidationRules.FluentValidation;
using TracingNetCore.Core.Aspects.AutoFac.Validation;
using TracingNetCore.Core.Utilities.Business;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        private IDeviceDal deviceDal;
        // Dont use it (IRequestDal) if you want use other service you must add example; IRequestService and your processes must 
        // added in services
        private IRequestDal requestDal;


        public DeviceManager(IDeviceDal deviceDal, IRequestDal requestDal)
        {
            this.deviceDal = deviceDal;
            this.requestDal = requestDal;
        }

        // [TransactionScopeAspect] // When you use it if your transactions not Commit your transactions is Rollback

        // [CacheRemoveAspect("IDeviceService.Get")] if you add new device you must remove cache and re-loading cache for new
        // device add cache and if you want remove another business manager cache you will must change interface name in this manager
        // code block

        // [CacheAspect(duration:1)] if you want invoke caching any processes you must add this [CacheAspect] header processes
        // and then you can set the duration in minutes.

        // [SecuredOperation("Device.List, Admin")] for authorization aspect cross cutting all project with claim roles and
        // operation claims

        // [PerformanceAspect(5)] check for performance duration if you want check define a time in seconds to test how
        // long it takes to list

        // [ValidationAspect(typeof(DeviceValidator), Priority = 1)] if you write validation you will add validation check for add, 
        // edit field areas 

        //[LogAspect(typeof(JsonFileLogger))] if you want get log you add this and select logger type DatabaseLogger or JsonFileLogger

        // if you want add new result for check something you will add like this comma ( , ) and than write methoda name and
        // parameters ---> Start Code """ IResult result = BusinessRules.Run(CheckIfDeviceIdentityExist(device.DeviceIdentity)
        // , <!-- Check Something Method Name) """ End Code --!> For Example Add Check Add Method


        [ValidationAspect(typeof(DeviceValidator), Priority = 1)]
        public IResult Add(Device device)
        {
            IResult result = BusinessRules.Run(CheckIfDeviceIdentityExist(device.DeviceIdentity));
            deviceDal.Add(device);
            return new SuccessResult(DataMessages.AddDevice);
        }

        // Check DeviceIdentity : If already exist return errorResult else return null
        private IResult CheckIfDeviceIdentityExist(string deviceIdentity)
        {
            if (deviceDal.GetList(x => x.DeviceIdentity == deviceIdentity) != null)
                return new ErrorResult(DataMessages.DeviceAlreadyExist);
            return new SuccessResult();
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

        [SecuredOperation("Admin")]
        public IDataResult<List<Device>> GetList()
        {
            return new SuccessDataResult<List<Device>>(deviceDal.GetList().ToList());
        }

        public IDataResult<List<Request>> GetRequests(int deviceId)
        {
            return new SuccessDataResult<List<Request>>(requestDal.GetList(x => x.DeviceId == deviceId).ToList());
        }
    }
}
