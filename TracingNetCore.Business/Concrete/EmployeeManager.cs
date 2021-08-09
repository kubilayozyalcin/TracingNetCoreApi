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

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            this.employeeDal = employeeDal;
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
 
    }
}
