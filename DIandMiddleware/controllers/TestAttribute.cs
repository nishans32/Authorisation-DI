using DIandMiddleware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace DIandMiddleware.controllers
{
    public  class AuthorizeViewValues : Attribute, IAuthorizationFilter
    {
        public int MyProperty { get; set; }
        private readonly string permissions;

        public AuthorizeViewValues(string permissions)
        {
            this.permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorisation = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
            if (!authorisation.HasPermission(permissions))
            { 
                context.Result = new UnauthorizedResult();
            }




        }
    }
}