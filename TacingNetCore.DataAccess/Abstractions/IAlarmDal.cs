using TacingNetCore.Core.DataAccess;
using TracingNetCore.Entities.Concrete;

namespace TacingNetCore.DataAccess.Abstractions
{
    public interface IAlarmDal : IEntityRepository<Alarm>
    {
    }
}
