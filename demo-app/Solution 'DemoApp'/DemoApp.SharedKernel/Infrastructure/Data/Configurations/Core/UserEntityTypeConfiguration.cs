using DemoApp.SharedKernel.Domain.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DemoApp.SharedKernel.Infrastructure.Data.Configurations.Core
{
    public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.FirstName)
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .IsRequired();

            builder
                .HasMany(d => d.Devices)
                .WithOne(u => u.User)
                .HasForeignKey(d => d.UserId);

            builder
                .HasData(new List<User>
            {
                new User { Id = 10, FirstName = "Faruk", LastName = "Ohran" }
            });
        }
    }
}
