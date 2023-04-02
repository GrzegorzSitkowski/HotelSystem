using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Queries.GetReservationDetail
{
    public class ReservationDetailVm : IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Payment { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        //public Room Room { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, ReservationDetailVm>();
        }
    }
}
