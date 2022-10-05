using HotelSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Type).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Mail).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.OwnsOne(p => p.UserName).Property(p => p.FirstName).HasMaxLength(30).HasColumnType("FirstName").IsRequired();
            builder.OwnsOne(p => p.UserName).Property(p => p.LastName).HasMaxLength(30).HasColumnType("LastName").IsRequired();
        }
    }
}
