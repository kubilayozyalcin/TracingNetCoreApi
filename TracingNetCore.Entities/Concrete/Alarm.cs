using System;
using TracingNetCore.Core.Abstractions;

namespace TracingNetCore.Entities.Concrete
{
    public class Alarm : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}