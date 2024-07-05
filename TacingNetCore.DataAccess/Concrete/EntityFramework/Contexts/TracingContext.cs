using Microsoft.EntityFrameworkCore;
using TracingNetCore.Core.Concrete;
using TracingNetCore.Entities.Concrete;

namespace TacingNetCore.DataAccess.Concrete.EntityFramework.Contexts
{
    public class TracingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=ApiTracing;Trusted_Connection=True");
        }

        // Tables Map
        public DbSet<Device> Devices { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<DeviceType> DeviceType { get; set; }
        public DbSet<EmployeeDevice> EmployeeDevices { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        // Create Table Just For Logging
        public DbSet<Log> Logs { get; set; }

    }
}
