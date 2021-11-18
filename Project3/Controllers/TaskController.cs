using Microsoft.AspNetCore.Mvc;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Controllers
{
    [Route("api/mytask")]
    public class TaskController : Controller
    {
        private TaskService taskService;

        public TaskController(TaskService _taskService)
        {
            this.taskService = _taskService;
        }

        public IActionResult FindAllTask()
        {
            try
            {
                return Ok(taskService.FindAllTask());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public IActionResult Finds(int id)
        {
            try
            {
                return Ok(taskService.Find(id));
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}
