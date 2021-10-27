using Microsoft.AspNetCore.Mvc;
using Project3.Services;

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

    }
}
