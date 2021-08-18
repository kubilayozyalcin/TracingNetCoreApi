using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Constants;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Concrete
{
    public class EmployeeDeviceManager : IEmployeeDeviceService
    {
        private IEmployeeDeviceDal employeeDeviceDal;

        public EmployeeDeviceManager(IEmployeeDeviceDal employeeDeviceDal)
        {
            this.employeeDeviceDal = employeeDeviceDal;
        }

        public IResult Add(EmployeeDevice employeeDevice)
        {
            employeeDeviceDal.Add(employeeDevice);
            return new SuccessResult(DataMessages.AddEmployeeDevice);
        }

        public IResult Delete(EmployeeDevice employeeDevice)
        {
            employeeDeviceDal.Delete(employeeDevice);
            return new SuccessResult(DataMessages.DeleteEmployeeDevice);
        }

        public IDataResult<EmployeeDevice> GetById(int employeeDeviceId)
        {
            return new SuccessDataResult<EmployeeDevice>(employeeDeviceDal.Get(x => x.Id == employeeDeviceId));
        }

        public IDataResult<List<EmployeeDevice>> GetList()
        {
            return new SuccessDataResult<List<EmployeeDevice>>(employeeDeviceDal.GetList().ToList());
        }

        public IDataResult<List<EmployeeDevice>> GetByDevice(int deviceId)
        {
            return new SuccessDataResult<List<EmployeeDevice>>(employeeDeviceDal.GetList(x => x.DeviceId == deviceId).ToList());
        }

        public IDataResult<List<EmployeeDevice>> GetByEmployeeDevice(int employeeId)
        {
            return new SuccessDataResult<List<EmployeeDevice>>(employeeDeviceDal.GetList(x => x.EmployeeId == employeeId).ToList());
        }

    }
}
