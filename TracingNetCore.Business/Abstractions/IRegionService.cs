using System.Collections.Generic;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Entities.Concrete;

namespace TracingNetCore.Business.Abstractions
{
    public interface IRegionService
    {
        IDataResult<Region> GetById(int regionId);
        IDataResult<List<Region>> GetList();
        IDataResult<List<Device>> GetByDevices(int regionId);
        IResult Add(Region region);
        IResult Update(Region region);
        IResult Delete(Region region);
    }
}
