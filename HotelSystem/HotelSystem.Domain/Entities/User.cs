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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumner { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
