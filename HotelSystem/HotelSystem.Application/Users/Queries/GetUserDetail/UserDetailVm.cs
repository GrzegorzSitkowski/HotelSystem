using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Queries.GetUserDetail
{
    public class UserDetailVm : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Mail { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailVm>()
                .ForMember(u => u.FullName, map => map.MapFrom(src => src.UserName.ToString()));
        }
    }
}
