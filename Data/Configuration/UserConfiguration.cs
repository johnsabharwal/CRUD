using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).HasDefaultValueSql("('')");
            builder.Property(p => p.Email).HasMaxLength(100).HasDefaultValueSql("('')");
            builder.Property(p => p.Status).HasMaxLength(100).HasDefaultValueSql("('')");
            builder.Property(p => p.RoleType).HasMaxLength(100).HasDefaultValueSql("('')");

        }
    }
}
