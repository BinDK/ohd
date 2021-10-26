using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3
{
    [Route("api/admin")]
    public class AdminController : Controller
    {

        [HttpGet("list_account")]
        [Produces("application/json")]
        public IActionResult Index()
        {
            return Ok(new
            {
                id = "1",
                name="dat"
            }) ;
        }

    }
}
