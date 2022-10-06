using HotelSystem.Domain.Common;
using HotelSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Type { get; set; }
        public string Mail { get; set; }
        public PersonName UserName {get; set;}
        public string Password { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
