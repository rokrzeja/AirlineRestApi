using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> getClients()
        {
            var context = new MainDbContext();
            var clients = context.Clients;
            return Ok(clients);
        }


       
    }
}
