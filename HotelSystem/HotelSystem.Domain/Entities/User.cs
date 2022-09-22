﻿using HotelSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Mail { get; set; }
        public PersonName UserName {get; set;}
        public string LastName { get; set; }
        public string Password { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
