using HotelSystem.Application.Rooms.Commands.CreateRoom;
using HotelSystem.Application.Rooms.Commands.DeleteRoom;
using HotelSystem.Application.Rooms.Commands.UpdateRoom;
using HotelSystem.Application.Rooms.Queries.GetRoomDetail;
using HotelSystem.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

       [HttpGet]
       public async Task<ActionResult<RoomDetailVm>> GetRooms()
        {
            var rooms = await _context.Rooms.AsNoTracking().Where(p => p.StatusId == 1 && p.Avability == true).ToListAsync();
            return Ok(rooms);
        }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateRoom(UpdateRoomCommand command)
        {
            var room = await Mediator.Send(command);
            return Ok(room);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            var room = await Mediator.Send(new DeleteRoomCommand() {Id = id});
            return Ok(room);
        }
    }
}
