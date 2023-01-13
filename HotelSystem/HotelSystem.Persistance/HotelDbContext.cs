using HotelSystem.Application.Interfaces;
using HotelSystem.Domain.Common;
using HotelSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Persistance
{
    public class HotelDbContext : DbContext, IHotelDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _userService;

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public HotelDbContext(DbContextOptions<HotelDbContext> options, IDateTime dateTime, ICurrentUserService userService) : base(options)
        {
            _dateTime = dateTime;
            _userService = userService;
        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.ModifiedBy = string.Empty;                       
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
