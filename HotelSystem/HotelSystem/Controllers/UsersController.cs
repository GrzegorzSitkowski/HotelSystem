using HotelSystem.Application.Users.Commands.CreateUser;
using HotelSystem.Application.Users.Commands.DeleteUser;
using HotelSystem.Application.Users.Commands.UpdateUser;
using HotelSystem.Application.Users.Queries.GetUserDetail;
using HotelSystem.Application.Users.Queries.GetUserDetailByMail;
using HotelSystem.Application.Users.Queries.GetUsers;
using HotelSystem.Domain.Entities;
using HotelSystem.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : BaseController
    {    

        private readonly HotelDbContext _context;
        private readonly IConfiguration _config;

        public UsersController(HotelDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDetailVm>> GetUserDetail(int id)
        {
            var vm = await Mediator.Send(new GetUserDetailQuery() { Id = id });
            return vm;
        }

        [AllowAnonymous]
        [HttpGet("{mail}")]
        public async Task<ActionResult<UserDetailByMailVm>> GetUserDetailByMail(string mail)
        {
            var vm = await Mediator.Send(new GetUserDetailQueryByMail() { Mail = mail });
            return vm;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<UsersVm>> GetUsers()
        {
            var users = await _context.Users.AsNoTracking().Where(p => p.StatusId == 1).ToListAsync();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await Mediator.Send(new DeleteUserCommand() { Id = id });
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(LoginUser user)
        {
            var userAvailable = _context.Users.Where(u => u.Mail == user.Email && u.Password == user.Password).FirstOrDefault();
            if(userAvailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userAvailable.Id.ToString(),
                    userAvailable.FirstName,
                    userAvailable.LastName,
                    userAvailable.Mail,
                    userAvailable.PhoneNumner
                        )
                    );
            }
            return Ok("Failure");
        }
    }
}
