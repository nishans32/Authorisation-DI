using DIandMiddleware.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIandMiddleware.controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public ValuesController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [AuthorizeViewValues("CanViewValues")]
        public IActionResult Get()
        {
            return Ok("Test");
        }
    }
}
