using DemoApp.SharedKernel.Domain.Device;
using DemoApp.SharedKernel.Domain.User;
using DemoApp.SharedKernel.Infrastructure.Data.Configurations.Core;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.SharedKernel.Infrastructure.Data
{
    public partial class DemoAppDbContext : DbContext
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeviceEntityTypeConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}