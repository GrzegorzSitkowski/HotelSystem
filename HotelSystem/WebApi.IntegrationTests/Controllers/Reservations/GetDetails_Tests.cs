using HotelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.IntegrationTests.Common;
using Xunit;

namespace WebApi.IntegrationTests.Controllers.Reservations
{
    public class GetDetails_Tests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetDetails_Tests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenReservationsId_ReturnsReservationsDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "2";
            var response = await client.GetAsync($"/api/reservations/{id}");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContext<ReservationDetailVm>(response);
            vm.ShouldNotBeNull();
        }
    }
}
