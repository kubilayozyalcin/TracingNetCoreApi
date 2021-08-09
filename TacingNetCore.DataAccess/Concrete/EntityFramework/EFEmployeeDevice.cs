﻿using TacingNetCore.DataAccess.Abstractions;
using TacingNetCore.DataAccess.Concrete.EntityFramework.Contexts;
using TracingNetCore.Core.DataAccess.EntityFramework;
using TracingNetCore.Entities.Concrete;

namespace TacingNetCore.DataAccess.Concrete.EntityFramework
{
    public class EFEmployeeDevice : EFEntityRepositoryBase<EmployeeDevice, TracingContext>, IEmployeeDeviceDal
    {
    }
}
