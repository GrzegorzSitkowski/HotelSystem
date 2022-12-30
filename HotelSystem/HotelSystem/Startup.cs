using HotelSystem.Api;
using HotelSystem.Api.Service;
using HotelSystem.Application;
using HotelSystem.Application.Interfaces;
using HotelSystem.Infrastructure;
using HotelSystem.Infrastructure.Identity;
using HotelSystem.Persistance;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin());
            });

            if (Environment.IsEnvironment("Test"))
            {

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HotelDatabase")));
                services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();
                services.AddIdentityServer()
                        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                        {
                            options.ApiResources.Add(new IdentityServer4.Models.ApiResource("api1"));
                            options.ApiScopes.Add(new IdentityServer4.Models.ApiScope("api1"));
                            options.Clients.Add(new IdentityServer4.Models.Client
                            {
                                ClientId = "client",
                                AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                                ClientSecrets = { new IdentityServer4.Models.Secret("secret".Sha256()) },
                                AllowedScopes = { "openid", "profile", "HotelSystem.ApiAPI", "api1" }
                            });
                        }).AddTestUsers(new List<TestUser>
                        {
                            new TestUser
                        {
                            SubjectId = "4B434A88-212D-4A4D-A17C-F35102D73CBB",
                            Username = "alice",
                            Password = "Pass123$",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "alice@user.com"),
                                new Claim(ClaimTypes.Name, "alice")
                            }
                        }
                        });
                services.AddAuthentication("Bearer").AddIdentityServerJwt();
            }
            else
            {
                 services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("ApiScope", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope", "api1");
                    });
                });
            }

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api1", "Full access" },
                                {"user", "User info" }
                            }
                        }
                    }
                });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "HotelSystem",
                    Version = "v1",
                    Description = "A simple web application.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Grzegorz Sitkowski",
                        Url = new Uri("https://dev-grzegorz.pl/"),
                    }
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "HotelSystem.mxl");
                c.IncludeXmlComments(filePath);
            });

            services.AddHealthChecks();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelSystem v1");
                    c.OAuthClientId("swagger");
                    c.OAuth2RedirectUrl("https://localhost:44321/swagger/oauth2-redirect.html");
                    c.OAuthUsePkce();
                });
            }                      
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseSerilogRequestLogging();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("ApiScope");
            });
        }
    }
}
