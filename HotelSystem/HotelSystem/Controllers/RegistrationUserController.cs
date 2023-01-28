﻿using HotelSystem.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Api.Controllers
{
    public class RegistrationUserController : BaseController
    {
        [Route("api/registration")]
        
        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
