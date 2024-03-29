﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Queries.GetRoomDetail
{
    public class GetRoomDetailQuery : IRequest<RoomDetailVm>
    {
        public int Id { get; set; }
    }
}
