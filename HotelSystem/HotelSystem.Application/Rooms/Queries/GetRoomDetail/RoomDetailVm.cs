using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Queries.GetRoomDetail
{
    public class RoomDetailVm : IMapFrom<Room>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public bool Avability { get; set; }
        public string Amenities { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomDetailVm>();
        }
    }
}
