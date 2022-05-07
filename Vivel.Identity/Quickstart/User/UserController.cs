using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer;
using IdentityServerHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vivel.Identity.Data;
using Vivel.Identity.Data.Entities;

namespace Vivel.Identity.Quickstart.User
{
    public class BaseUserInputModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
    public class CreateUserInputModel : BaseUserInputModel
    {
        public string Role { get; set; }
    }

    public class UpdateUserInputModel : BaseUserInputModel
    {
        public bool? Verified { get; set; }
    }

    [ApiController]
    [Route("[Controller]")]
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class UserController : Controller
    {
        private readonly CoreDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(CoreDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserInputModel model)
        {
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                return NotFound(new[] {
                    new {
                        code = "RoleNotFound", description = $"Role {model.Role} not found!"
                    }
                });
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, model.Role);

            if (model.Claims != null)
                await _userManager.AddClaimsAsync(user, model.Claims.Select(x => new Claim(x.Key, x.Value)));

            if (model.Role.ToLower() == "user")
            {
                _context.Add(new CoreUser
                {
                    UserId = Guid.Parse(user.Id),
                    UserName = user.UserName
                });

                await _context.SaveChangesAsync();
            }

            return Json(user);
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid userId, [FromBody] UpdateUserInputModel model)
        {
            dynamic result;
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
            {
                return NotFound(new[] {
                    new {
                        code = "UserNotFound", description = $"User with ID {userId} not found!"
                    }
                });
            }

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                result = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }

            if (model.Claims != null)
            {
                await _userManager.RemoveClaimsAsync(user, await _userManager.GetClaimsAsync(user));
                await _userManager.AddClaimsAsync(user, model.Claims.Select(x => new Claim(x.Key, x.Value)));
            }

            if (!string.IsNullOrWhiteSpace(model.Username))
            {
                user.UserName = model.Username;
            }

            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                user.Email = model.Email;
            }

            result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            if (await _userManager.IsInRoleAsync(user, "user"))
            {
                var coreUser = await _context.Users.FindAsync(Guid.Parse(user.Id));

                coreUser.UserName = user.UserName;
                coreUser.Verified = model.Verified ?? coreUser.Verified;

                _context.Update(coreUser);
                await _context.SaveChangesAsync();
            }

            return Json(user);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            dynamic result;
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
            {
                return NotFound(new[] {
                    new {
                        code = "UserNotFound", description = $"User with ID {userId} not found!"
                    }
                });
            }

            if (await _userManager.IsInRoleAsync(user, "user"))
            {
                result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                var coreUser = await _context.Users.FindAsync(Guid.Parse(user.Id));

                _context.Remove(coreUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }

            return Json(user);
        }
    }
}
