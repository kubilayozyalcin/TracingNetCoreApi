using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Constants;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal employeeDal;
        private IEmployeeDeviceDal employeeDeviceDal;
        private IRequestDal requestDal;

        public EmployeeManager(IEmployeeDal employeeDal, IEmployeeDeviceDal employeeDeviceDal, IRequestDal requestDal)
        {
            this.employeeDal = employeeDal;
            this.employeeDeviceDal = employeeDeviceDal;
            this.requestDal = requestDal;
        }

        public IResult Add(Employee employee)
        {
            employeeDal.Add(employee);
            return new SuccessResult(DataMessages.AddEmployee);
        }

        public IResult Update(Employee employee)
        {
            employeeDal.Update(employee);
            return new SuccessResult(DataMessages.UpdateEmployee);
        }

        public IResult Delete(Employee employee)
        {
            employeeDal.Delete(employee);
            return new SuccessResult(DataMessages.DeleteDevice);
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(employeeDal.Get(x => x.Id == employeeId));
        }

        public IDataResult<List<Employee>> GetList()
        {
            return new SuccessDataResult<List<Employee>>(employeeDal.GetList().ToList());
        }

        public IDataResult<List<EmployeeDevice>> GetEmployeeDevices(int employeeId)
        {
            return new SuccessDataResult<List<EmployeeDevice>>(employeeDeviceDal.GetList(x => x.EmployeeId == employeeId).ToList());
        }


        public IDataResult<List<Request>> GetRequests(int employeeId)
        {
            return new SuccessDataResult<List<Request>>(requestDal.GetList(x => x.EmployeeId == employeeId).ToList());
        }

    }
}
