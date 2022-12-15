using HotelSystem.Application.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelSystem.Api.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public string userName { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var _userName = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Name);

            userName = _userName;

            IsAuthenticated = !string.IsNullOrEmpty(_userName);
        }
    }
}
