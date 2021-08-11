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
    public class RegionManager : IRegionService
    {
        private IRegionDal regionDal;
        private IDeviceDal deviceDal;

        public RegionManager(IRegionDal regionDal, IDeviceDal deviceDal)
        {
            this.regionDal = regionDal;
            this.deviceDal = deviceDal;
        }

        // [TransactionScopeAspect] // When you use it if your transactions not Commit your transactions is Rollback

        // [CacheRemoveAspect("IDeviceService.Get")] if you add new device you must remove cache and re-loading cache for new device add cache 
        // and if you want remove another business manager cache you will must change interface name in this manager code block
        // [ValidationAspect(typeof(DeviceValidator), Priority = 1)]

        // [CacheAspect(duration:1)] if you want invoke caching any processes you must add this [CacheAspect] header processes
        // and then you can set the duration in minutes.
        // [CacheAspect(duration: 1)]

        public IResult Add(Region region)
        {
            regionDal.Update(region);
            return new SuccessResult(DataMessages.UpdateRegion);
        }

        public IResult Update(Region region)
        {
            regionDal.Delete(region);
            return new SuccessResult(DataMessages.DeleteRegion);
        }

        public IResult Delete(Region region)
        {
            regionDal.Add(region);
            return new SuccessResult(DataMessages.AddRegion);
        }

        public IDataResult<Region> GetById(int regionId)
        {
            return new SuccessDataResult<Region>(regionDal.Get(x => x.Id == regionId));
        }

        public IDataResult<List<Device>> GetByDevices(int regionId)
        {
            return new SuccessDataResult<List<Device>>(deviceDal.GetList(x => x.RegionId == regionId).ToList());

        }

        public IDataResult<List<Region>> GetList()
        {
            return new SuccessDataResult<List<Region>>(regionDal.GetList().ToList());
        }

    }
}
