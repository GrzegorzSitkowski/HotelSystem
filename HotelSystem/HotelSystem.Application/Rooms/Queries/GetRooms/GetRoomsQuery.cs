using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQuery : IRequest<RoomsVm>
    {
    }
}
