using Microsoft.AspNetCore.Mvc;
using Project3.Services;
using System;
using System.Diagnostics;

namespace Project3.Controllers
{
    [Route("api/facility")]
    public class FacilityController : Controller
    {
        private FacilityService facilityService;

        public FacilityController(FacilityService _facilityService)
        {
            facilityService = _facilityService;
        }

        [HttpGet("findall")]
        [Produces("application/json")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(facilityService.FindAll());
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
                facilityService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find/{id}")]
        [Produces("application/json")]
        public IActionResult findFacility(int id)
        {
            try
            {
                object head = facilityService.find(id);
               
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
