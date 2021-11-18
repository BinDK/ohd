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

        public AdminController(AdminService _adminService)
        {
            this.adminService = _adminService;
        }

        [Produces("application/json")]
        [HttpGet("account/findByName/{name}")]
        public IActionResult Finds(string name)
        {
            try
            {
                return Ok(adminService.FindAllByName(name));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("account/findByUser/{username}/{name}/{email}")]
        public IActionResult FindByUser(string username,string name,string email)
        {
            try
            {
                return Ok(adminService.FindAllByUser(username,name,email));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("account/findByRole/{role}")]
        public IActionResult FindById(int role)
        {
            try
            {
                return Ok(adminService.FindAllByRoles(role));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("account/findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(adminService.listAccount());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Produces("application/json")]
        [HttpGet("role/findall")]
        public IActionResult getRoles()
        {
            return Ok(adminService.listRole());
        }

        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public IActionResult Finds(int id)
        {
            try
            {
                return Ok(adminService.findAccount(id));
            }
            catch
            {
                return BadRequest();
            }
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("account/create")]
        public IActionResult Create([FromBody] Account account)
        {
            try
            {
                return Ok(adminService.addAccount(account));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                if (Object.ReferenceEquals(null, a))
                    return BadRequest();
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
                if (a == false)
                    return BadRequest("Id of account not exists");
                else if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }




        [Produces("application/json")]
        [HttpGet("account/findallhead")]
        public IActionResult FindAllHead()
        {
            try
            {
                return Ok(adminService.FindAllHead());
            }
            catch
            {
                return BadRequest();
            }

        }

    }

}
