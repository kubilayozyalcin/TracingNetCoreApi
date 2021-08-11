using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IAlarmService
    {
        IDataResult<Alarm> GetById(int alarmId);
        IDataResult<List<Alarm>> GetList();
        IDataResult<List<Alarm>> GetByEmployee(int employeeId);
        IResult Add(Alarm alarm);
    }
}
