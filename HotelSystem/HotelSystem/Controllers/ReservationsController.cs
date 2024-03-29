﻿using HotelSystem.Application.Reservations.Commands.CreateReservation;
using HotelSystem.Application.Reservations.Commands.DeleteReservation;
using HotelSystem.Application.Reservations.Commands.UpdateReservation;
using HotelSystem.Application.Reservations.Queries.GetReservationDetail;
using HotelSystem.Application.Reservations.Queries.GetReservations;
using HotelSystem.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Api.Controllers
{
    [Route("api/reservations")]
    //[Authorize]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDetailVm>> GetReservationDetail (int id)
        {
            var vm = await Mediator.Send(new GetReservationDetailQuery() { Id = id });
            return vm;
        }

        [HttpGet]
        public async Task<ActionResult<ReservationsVm>> GetReseravtions()
        {
            var reservations = await _context.Reservations.AsNoTracking().Where(p => p.StatusId == 1).ToListAsync();
            return Ok(reservations);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReseravtion(UpdateReservationCommand command)
        {
            var reservation = await Mediator.Send(command);
            return Ok(reservation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var reservation = await Mediator.Send(new DeleteReservationCommand() { Id = id });
            return Ok(reservation);
        }
        
    }
}
