﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RegistarApi.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult( from c in User.Claims select  new {c.Type, c.Value});
            
        }
        
    }
}
