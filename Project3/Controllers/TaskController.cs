using Microsoft.AspNetCore.Mvc;
using Project3.Models;
using Project3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [Produces("application/json")]
        [HttpGet("findAllTask/{id}")]
        public IActionResult FindAllTask(int id)
        {
            try
            {
                return Ok(taskService.FindAllTask(id));
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
                return Ok(taskService.Finds(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update1/{id}")]
        public IActionResult updateTask1(string id, [FromBody] UserTask userTask)
        {
            try
            {
                var updateTask = taskService.FindTaskById(id);
                updateTask.RequestByUserId = userTask.RequestByUserId;
                updateTask.UserTaskStatus = userTask.UserTaskStatus;
                updateTask.Note = userTask.Note;
                updateTask.StartDate = userTask.StartDate;
                updateTask.EndDate = DateTime.Now;
                updateTask.HeadTaskId = userTask.HeadTaskId;
                updateTask.UserAccountId = updateTask.UserAccountId;
                taskService.UpdateTask1(updateTask);
                return Ok(new
                {
                    id = updateTask.Id,
                    request_by_user_id = updateTask.RequestByUserId,
                    user_task_status = updateTask.UserTaskStatus,
                    note = updateTask.Note,
                    start_date = updateTask.StartDate,
                    end_date = DateTime.Now,
                    head_task_id = updateTask.HeadTaskId,
                    user_account_id = updateTask.UserAccountId
                });

            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update2")]
        public IActionResult updateTask2([FromBody] UserTask userTask)
        {
            try
            {

                dynamic a = taskService.UpdateTask2(userTask);
                if (a == false)
                    return BadRequest("Id of task not exists");
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
        [HttpPut("changeimplementor")]
        public IActionResult update([FromBody] UserTask userTask)
        {
            try
            {

                dynamic a = taskService.UpdateImplementor(userTask);
                if (a == false)
                    return BadRequest("Fail");
                else if (Object.ReferenceEquals(null, a))
                    return BadRequest();
                return Ok(a);
            }
            catch
            {
                return BadRequest();
            }
        }

        //abc

    }
}
