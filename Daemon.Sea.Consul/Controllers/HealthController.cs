using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daemon.Sea.Consul.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        public virtual IActionResult Get()
        {
            return Ok();
        }
    }
}
