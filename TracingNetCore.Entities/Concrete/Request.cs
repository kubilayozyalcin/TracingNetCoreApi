using System;
using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Request : EntityBase, IEntity
    {
        public string RequestCode { get; set; }

        public string DeviceIdentity { get; set; }

        public int EmployeeId { get; set; }

        public int DeviceId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsDataSend { get; set; }

        public string Response { get; set; }

    }
}