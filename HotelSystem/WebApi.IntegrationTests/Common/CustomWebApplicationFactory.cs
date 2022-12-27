using HotelSystem.Application.Interfaces;
using HotelSystem.Persistance;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            try
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                    services.AddDbContext<HotelDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDatabase");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    services.AddScoped<IHotelDbContext>(provider => provider.GetService<HotelDbContext>());

                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();
                    var scopedService = scope.ServiceProvider;
                    var context = scopedService.GetRequiredService<HotelDbContext>();
                    var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error accurred seeding the" +
                            $"database with test messages. Error: {ex.Message}");
                    }
                })
                    .UseSerilog()
                    .UseEnvironment("Test");

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<HttpClient> GetAuthenticatedClientAsync()
        {
            var client = CreateClient();

            var token = await GetAccessTokenAsync(client, "alice", "Pass123$");
            client.SetBearerToken(token);
            return client;
        }

        private async Task<string> GetAccessTokenAsync(HttpClient client, string userName, string password)
        {
            var disco = await client.GetDiscoveryDocumentAsync();

            if(disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "openid profile HotelSystem.ApiAPI api1",
                UserName = userName,
                Password = password
            });

            if(response.IsError)
            {
                throw new Exception(response.Error);
            }

            return response.AccessToken;
        }
    }
}
