using Microsoft.AspNetCore.Mvc;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Controllers
{
    [Route("api/myrequests")]
    public class ReqLogController : Controller
    {
        private ReqLogService reqLogService;

        public ReqLogController(ReqLogService _reqLogService)
        {
            this.reqLogService = _reqLogService;
        }


        [Produces("application/json")]
        [HttpGet("req_log/findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(reqLogService.FindAllReg());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    }
}
