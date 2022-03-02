using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using IdentityServerHost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Vivel.Identity.Data;

namespace Vivel.Identity
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString, o => o.MigrationsAssembly(typeof(Startup).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    var adminRole = roleMgr.FindByNameAsync("admin").Result;
                    if (adminRole == null)
                    {
                        adminRole = new IdentityRole
                        {
                            Id = "ccb43d5d-9fab-446f-9567-461976d3ff64",
                            Name = "admin"
                        };

                        var result = roleMgr.CreateAsync(adminRole).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("admin role created");
                    }

                    var userRole = roleMgr.FindByNameAsync("user").Result;
                    if (userRole == null)
                    {
                        userRole = new IdentityRole
                        {
                            Id = "45cb0615-1045-4631-b6ad-83b3545f7cc1",
                            Name = "user"
                        };

                        var result = roleMgr.CreateAsync(userRole).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("user role created");
                    }

                    var staffRole = roleMgr.FindByNameAsync("staff").Result;
                    if (staffRole == null)
                    {
                        staffRole = new IdentityRole
                        {
                            Id = "6416fa15-6409-4dbe-90bd-df8e486de212",
                            Name = "staff"
                        };

                        var result = roleMgr.CreateAsync(staffRole).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("staff role created");
                    }

                    var alice = userMgr.FindByNameAsync("alice").Result;
                    if (alice == null)
                    {
                        alice = new ApplicationUser
                        {
                            Id = "e093aaec-8cf0-4359-972a-0a62f0191083",
                            UserName = "alice",
                            Email = "AliceSmith@email.com",
                            EmailConfirmed = true,
                        };
                        var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddToRoleAsync(alice, "user").Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("alice created");
                    }
                    else
                    {
                        Log.Debug("alice already exists");
                    }

                    var bob = userMgr.FindByNameAsync("bob").Result;
                    if (bob == null)
                    {
                        bob = new ApplicationUser
                        {
                            Id = "6e0884d7-c18f-4c8f-bce7-968e2cc33571",
                            UserName = "bob",
                            Email = "BobSmith@email.com",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddToRoleAsync(bob, "user").Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("bob created");
                    }
                    else
                    {
                        Log.Debug("bob already exists");
                    }
                }
            }
        }
    }
}
