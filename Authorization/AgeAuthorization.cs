using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UsuariosApi.Authorization.Policies;

namespace UsuariosApi.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAgePolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgePolicy requirement)
        {
            Claim? birthDateClaim = context
                .User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (birthDateClaim is null)
                return Task.CompletedTask;

            DateTime? birthDate = Convert.ToDateTime(birthDateClaim.Value);

            int userAge = DateTime.Now.Year - birthDate.Value.Year;

            if (birthDate > DateTime.Today.AddYears(-userAge))
                userAge--;

            if (userAge >= requirement.MinimumAge)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
