using Data.Infracstructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Sercurity
{
    public class AuthorizationCustom : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly IDbFactory _dbFactory;
        public AuthorizationCustom(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            bool found = true;
            if (context.User == null || !context.User.Identity!.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
