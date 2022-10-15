using HotelSystem.Application.Rooms.Commands.CreateRoom;
using HotelSystem.Application.Rooms.Queries.GetRoomDetail;
using HotelSystem.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : BaseController
    {
        private readonly HotelDbContext _context;

        public RoomsController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetailVm>> GetRoom(int id)
        {
            var vm = await Mediator.Send(new GetRoomDetailQuery() { Id = id });
            return vm;
        }
    }
}
