using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Persistance
{
    public class HotelDbContextFactory : DesignTimeDbContextFactoryBase<HotelDbContext>
    {
        protected override HotelDbContext CreateNewInstance(DbContextOptions<HotelDbContext> options)
        {
            return new HotelDbContext(options);
        }
    }
}
