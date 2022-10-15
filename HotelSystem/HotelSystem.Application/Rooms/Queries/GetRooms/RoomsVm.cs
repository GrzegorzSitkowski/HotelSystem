using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Queries.GetRooms
{
    public class RoomsVm : IMapFrom<Room>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public bool Avability { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomsVm>();
        }
    }
}
