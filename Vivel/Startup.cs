using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Vivel.Database;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Services;

namespace Vivel
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
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{Configuration["Authority"]}/connect/authorize"),
                            TokenUrl = new Uri($"{Configuration["Authority"]}/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"scope1", "scope1"}
                            },
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<VivelContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), options => options.UseNetTopologySuite());
            }, ServiceLifetime.Transient);

            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IPresetBadgeService, PresetBadgeService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDriveService, DriveService>();
            services.AddScoped<IDonationService, DonationService>();

            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = Configuration["Authority"];
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.ValidateIssuer = false;
                options.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "scope1");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<VivelContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.OAuthClientId("vivel.swagger");
                    options.OAuthClientSecret("88d7eaf8-08a0-48a5-ae3b-02d46db9cc73"); // TODO: Move this to environment
                    options.OAuthScopes(new string[] { "scope1" });
                    options.OAuthUsePkce();
                });

            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
