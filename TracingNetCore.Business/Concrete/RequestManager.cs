using System.Collections.Generic;
using System.Linq;
using TacingNetCore.DataAccess.Abstractions;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Constants;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Concrete
{
    public class RequestManager : IRequestService
    {
        private IRequestDal requestDal;

        public RequestManager(IRequestDal requestDal)
        {
            this.requestDal = requestDal;
        }

        public IResult Add(Request request)
        {
            requestDal.Add(request);
            return new SuccessResult(DataMessages.AddRequest);
        }

        public IResult Update(Request request)
        {
            requestDal.Update(request);
            return new SuccessResult(DataMessages.UpdateRequest);
        }

        public IDataResult<Request> GetById(int requestId)
        {
            return new SuccessDataResult<Request>(requestDal.Get(x => x.Id == requestId));
        }

        public IDataResult<List<Request>> GetByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<Request>>(requestDal.GetList(x => x.EmployeeId == employeeId).ToList());
                
        }

        public IDataResult<List<Request>> GetByDeviceId(int deviceId)
        {
            return new SuccessDataResult<List<Request>>(requestDal.GetList(x => x.DeviceId == deviceId).ToList());
        }

        public IDataResult<List<Request>> GetList()
        {
            return new SuccessDataResult<List<Request>>(requestDal.GetList().ToList());
        }


    }
}
