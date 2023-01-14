using HotelSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Domain.Entities
{
    public class Room : AuditableEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public bool Avability { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; }
        public User User { get; set; }
        public Reservation Reservation { get; set; }
    }
}
