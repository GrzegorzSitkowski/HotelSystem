using HotelSystem.Api;
using HotelSystem.Api.Service;
using HotelSystem.Application;
using HotelSystem.Application.Interfaces;
using HotelSystem.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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
using System.Threading.Tasks;

namespace HotelSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            options.AddPolicy(name: "MyAllowSpecificOrigins",
            builder =>
            {
                builder.AllowAnyOrigin();
                //builder.WithOrigins("https://frontend.com");
            }));

            services.AddApplication();
            services.AddPersistance(Configuration);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin());
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateAudience = false
                    };
                });
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
