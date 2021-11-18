using Microsoft.AspNetCore.Mvc;
using Project3.Models;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Controllers
{
    [Route("api/priority")]
    public class PriorityController : Controller
    {

        private PriorityService priorityService;

        public PriorityController(PriorityService _priorityService)
        {
            this.priorityService = _priorityService;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] RequestPriority requestPriority)
        {
            try
            {
                return Ok(priorityService.CreatePriority(requestPriority));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        [Produces("application/json")]
        public IActionResult updateFacility([FromBody] RequestPriority requestPriority)
        {
            try
            {
                dynamic a = priorityService.updatePriority(requestPriority);
                if (a == false)
                    return BadRequest("Id of Request Priority not exists");
                else if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);
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
                priorityService.deletePriority(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("findall")]
        [Produces("application/json")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(priorityService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("find/{id}")]
        [Produces("application/json")]
        public IActionResult findPriority(int id)
        {
            try
            {
                object head = priorityService.Finds(id);

                if (Object.ReferenceEquals(null, head))
                    return BadRequest();
                return Ok(head);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
