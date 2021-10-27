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

        [HttpGet("account/findall")]
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

        [Produces("application/json")]
        [HttpGet("finds/{id}")]
        public IActionResult Finds(int id)
        {
            try
            {
                return Ok(adminService.Finds(id));
            }
            catch
            {
                return BadRequest();
            }
        }



        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                adminService.deleteAccount(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
