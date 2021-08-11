using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacingNetCore.Core.DataAccess;
using TracingNetCore.Entities.Concrete;

namespace TacingNetCore.DataAccess.Abstractions
{
    public interface IAlarmDal : IEntityRepository<Alarm>
    {
    }
}
