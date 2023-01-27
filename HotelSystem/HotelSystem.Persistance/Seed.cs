using HotelSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation()
                {
                    Id = 1,
                    Mail = "example@mail.com",
                    Payment = true,
                    UserId = 1,
                    RoomId = 1
                });

            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    Id = 1,
                    Name = "Double Room",
                    Capacity = 30,
                    Price = 450,
                    Avability = false,
                    Description = "Room for two."
                });

            modelBuilder.Entity<User>(u =>
            {
                u.HasData(new User()
                {
                    Id = 1,
                    Type = "Customer",
                    Mail = "example@mail.com",
                    Password = "password"
                });
                //u.OwnsOne(u => u.UserName).HasData(new { UserId = 1, FirstName = "Grzegorz", LastName = "Sitkowski" });
            });
                   
        }
    }
}
