using System;

namespace TracingNetCore.Entities.Concrete
{
    public class Log : EntityBase
    {
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
