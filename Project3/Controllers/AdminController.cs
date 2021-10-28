using Microsoft.AspNetCore.Mvc;
using Project3.Models;
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
            return Ok(adminService.listAccount());
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


        [HttpGet("account/find/{id}")]
        [Produces("application/json")]
        public IActionResult findAcount(int id)
        {
            try
            {
                dynamic a = adminService.findAccount(id);
                if(a == null) return BadRequest();
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("account/update")]
        [Produces("application/json")]
        public IActionResult updateAcount([FromBody] Account ac)
        {
            try
            {
                ac.Status = true;
                dynamic a = adminService.updateAccount(ac);
                if (a == false) return BadRequest("Id of account not exists");
                else if (a == null) return BadRequest();
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }


    }

}
