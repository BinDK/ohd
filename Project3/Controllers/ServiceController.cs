using Microsoft.AspNetCore.Mvc;
using Project3.Models;
using Project3.Services;
using System;
using System.Diagnostics;

namespace Project3.Controllers
{
    [Route("api/service")]
    public class ServiceController : Controller
    {
        private ServiceService serviceService;

        public ServiceController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Service service)
        {
            try
            {
                return Ok(serviceService.Create(service));
            }
            catch (Exception)
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
                serviceService.delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }





        [HttpGet("find/{id}")]
        [Produces("application/json")]
        public IActionResult find(int id)
        {
            try
            {
                dynamic a = serviceService.find(id);
                if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        [Produces("application/json")]
        public IActionResult update([FromBody] Service ac)
        {
            try
            {
                    dynamic a = serviceService.update(ac);
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

    }
}
