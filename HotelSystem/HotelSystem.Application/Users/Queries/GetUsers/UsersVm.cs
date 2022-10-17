using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Queries.GetUsers
{
    public class UsersVm : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Mail { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UsersVm>();
        }
    }
}
