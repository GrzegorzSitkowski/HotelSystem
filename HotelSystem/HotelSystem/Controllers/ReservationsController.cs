using HotelSystem.Application.Reservations.Commands.CreateReservation;
using HotelSystem.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Api.Controllers
{
    [Route("api/reservations")]
    public class ReservationsController : BaseController
    {
        private readonly HotelDbContext _context;

        public ReservationsController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateReservationCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        
    }
}
