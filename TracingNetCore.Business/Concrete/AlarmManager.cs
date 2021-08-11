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
    public class AlarmManager : IAlarmService
    {
        private IAlarmDal alarmDal;

        public AlarmManager(IAlarmDal alarmDal)
        {
            this.alarmDal = alarmDal;
        }

        // [TransactionScopeAspect] // When you use it if your transactions not Commit your transactions is Rollback

        // [CacheRemoveAspect("IDeviceService.Get")] if you add new device you must remove cache and re-loading cache for new device add cache 
        // and if you want remove another business manager cache you will must change interface name in this manager code block
        // [ValidationAspect(typeof(DeviceValidator), Priority = 1)]

        // [CacheAspect(duration:1)] if you want invoke caching any processes you must add this [CacheAspect] header processes
        // and then you can set the duration in minutes.
        // [CacheAspect(duration: 1)]

        public IResult Add(Alarm alarm)
        {
            alarmDal.Add(alarm);
            return new SuccessResult(DataMessages.AddAlarm);
        }

        public IDataResult<Alarm> GetById(int alarmId)
        {
            return new SuccessDataResult<Alarm>(alarmDal.Get(x => x.Id == alarmId));
        }

        public IDataResult<List<Alarm>> GetByEmployee(int employeeId)
        {
            return new SuccessDataResult<List<Alarm>>(alarmDal.GetList(x => x.EmployeeId == employeeId).ToList());

        }

        public IDataResult<List<Alarm>> GetList()
        {
            return new SuccessDataResult<List<Alarm>>(alarmDal.GetList().ToList());
        }

    }
}
