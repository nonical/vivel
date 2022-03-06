using System.Threading.Tasks;
using Duende.IdentityServer.Configuration;
using Duende.IdentityServer.ResponseHandling;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace Vivel.Identity.Extensions
{
    public class VivelAuthorizeInteractionResponseGenerator : AuthorizeInteractionResponseGenerator
    {
        public VivelAuthorizeInteractionResponseGenerator(IdentityServerOptions options, ISystemClock clock, ILogger<AuthorizeInteractionResponseGenerator> logger, IConsentService consent, IProfileService profile) : base(options, clock, logger, consent, profile) { }

        protected async override Task<InteractionResponse> ProcessLoginAsync(ValidatedAuthorizeRequest request)
        {
            var result = await base.ProcessLoginAsync(request);
            var user = request.Subject;

            if (!user.Identity.IsAuthenticated) return result;

            switch (request.Client.ClientId)
            {
                case "vivel.desktop":
                    if (!user.IsInRole("admin")) result.Error = "Only the admin role can use the desktop client!"; break;
                case "vivel.web":
                    if (!user.IsInRole("staff")) result.Error = "Only the staff role can use the web client!"; break;
                case "vivel.mobile":
                    if (!user.IsInRole("user")) result.Error = "Only the user role can use the mobile client!"; break;
            }

            return result;
        }
    }
}
