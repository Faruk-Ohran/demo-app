using DemoApp.SharedKernel.Domain.Device;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DemoApp.SharedKernel.Infrastructure.Data.Configurations.Core
{
    public class DeviceEntityTypeConfiguration : BaseEntityTypeConfiguration<Device>
    {
        public override void Configure(EntityTypeBuilder<Device> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Manufacturer)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithMany(d => d.Devices)
                .HasForeignKey(u => u.UserId);
            
            builder
                .HasData(new List<Device>
            {
                new Device { Id = 1, Name = "Device1", Manufacturer = "Manufacturer1", UserId = 10 },
                new Device { Id = 2, Name = "Device2", Manufacturer = "Manufacturer2", UserId = 10 },
                new Device { Id = 3, Name = "Device3", Manufacturer = "Manufacturer3", UserId = 10 },
            });
        }
    }
}