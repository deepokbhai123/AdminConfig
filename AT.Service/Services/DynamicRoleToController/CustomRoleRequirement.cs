using AT.Data.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Service.DynamicRoleToController
{
    public class CustomRoleRequirement : AuthorizationHandler<CustomRoleRequirement>, IAuthorizationRequirement
    {

        //private readonly ATContext _aTContext;
        //public CustomRoleRequirement(ATContext aTContext)
        //{
        //    _aTContext = aTContext;
        //}
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRoleRequirement requirement)
        {
            var roles = new[] { "Admin", "Admin2", "Admin3" };  //Get From DB.
            var userIsInRole = roles.Any(role => context.User.IsInRole(role));
            //var userclaim = roles.Any(role => context.User.Claims.Contains(roles));
            //if (!userIsInRole)
            //{
            //    context.Fail();

            //    return Task.CompletedTask;
            //}

            //context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
