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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Mail).IsRequired();
            builder.Property(p => p.CheckIn).IsRequired();
            builder.Property(p => p.CheckOut).IsRequired();
            builder.Property(p => p.Payment).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RoomId).IsRequired();
        }
    }
}
