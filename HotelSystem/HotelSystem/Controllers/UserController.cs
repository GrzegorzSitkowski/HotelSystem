using HotelSystem.Application.Users.Commands.CreateUser;
using HotelSystem.Application.Users.Commands.DeleteUser;
using HotelSystem.Application.Users.Commands.UpdateUser;
using HotelSystem.Application.Users.Queries.GetUserDetail;
using HotelSystem.Application.Users.Queries.GetUsers;
using HotelSystem.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Api.Controllers
{
    [Route("api/users")]
    public class RegistrationUserController : BaseController
    {    

        private readonly HotelDbContext _context;

        public RegistrationUserController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailVm>> GetUserDetail(int id)
        {
            var vm = await Mediator.Send(new GetUserDetailQuery() { Id = id });
            return vm;
        }

        [HttpGet]
        public async Task<ActionResult<UsersVm>> GetUsers()
        {
            var users = await _context.Users.AsNoTracking().Where(p => p.StatusId == 1).ToListAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await Mediator.Send(new DeleteUserCommand() { Id = id });
            return Ok(user);
        }
    }
}
