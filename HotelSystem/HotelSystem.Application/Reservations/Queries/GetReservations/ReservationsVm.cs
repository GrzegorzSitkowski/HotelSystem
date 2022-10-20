using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Queries.GetReservations
{
    public class ReservationsVm : IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Payment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, ReservationsVm>();
        }
    }
}
