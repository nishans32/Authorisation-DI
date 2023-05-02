using System;

namespace DIandMiddleware.Services
{
    public  interface IPermissionService
    {
        bool HasPermission(string permission);
    }
    public  class PermissionService: IPermissionService
    {
        public bool HasPermission(string permission)
        {
            var viewpermissionFromService = "CanViewValues";
            return viewpermissionFromService == permission;
        }
    }
}