using Microsoft.AspNetCore.Mvc;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3
{
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }

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

        [HttpGet("role/findall")]
        [Produces("application/json")]
        public IActionResult getRoles()
        {
            return Ok(adminService.listRole());
        }

    }
}
