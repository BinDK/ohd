using Microsoft.AspNetCore.Mvc;
using Project3.Models;
using Project3.Services;
using System;
using System.Diagnostics;

namespace Project3.Controllers
{
    [Route("api/myrequests")]
    public class MyRequestController : Controller
    {
        private MyRequestService myRequestService;

        public MyRequestController(MyRequestService myRequestService)
        {
            this.myRequestService = myRequestService;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] createRequestByUserReq req)
        {
            try
            {
                return Ok(myRequestService.Create(req));
            }
            catch (Exception)
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
                dynamic a = myRequestService.find(id);
                if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);

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
                return Ok(myRequestService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("close")]
        [Produces("application/json")]
        public IActionResult close([FromBody] CloseRequest req)
        {
            try
            {
                dynamic a = myRequestService.close(req);
                if (a == false)
                    return BadRequest("Id of request by user not exists");
                else if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("myassignment/findall")]
        [Produces("application/json")]
        public IActionResult FindAllLog()
        {
            try
            {
                return Ok(myRequestService.FindAllAssign());
            }
            catch
            {
                return BadRequest();
            }
        }
       
        /*Find request in head task*/

        [HttpGet("myassignment/find/{id}")]
        [Produces("application/json")]
        public IActionResult findHeadTask(int id)
        {
            try
            {
                dynamic a = myRequestService.findHeadTask(id);
                if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);

            }
            catch
            {
                return BadRequest();
            }
        }

    }


    public class createRequestByUserReq
    {
        private int request_priority_id;
        private int request_status_id;
        private string content;
        private int service_id;
        private Facility facility;
        private int account_id;

        public int Request_priority_id { get => request_priority_id; set => request_priority_id = value; }
        public int Request_status_id { get => request_status_id; set => request_status_id = value; }
        public string Content { get => content; set => content = value; }
        public int Service_id { get => service_id; set => service_id = value; }
      
        public int Account_id { get => account_id; set => account_id = value; }
        public Facility Facility { get => facility; set => facility = value; }
    }

    public class CloseRequest
    {
        private int request_by_user_id;
        private string reason;

        public int Request_by_user_id { get => request_by_user_id; set => request_by_user_id = value; }
        public string Reason { get => reason; set => reason = value; }
    }


}
