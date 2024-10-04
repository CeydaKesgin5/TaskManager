using Microsoft.AspNetCore.Mvc;
using TaskManagerClass.Business.Abstract;
using TaskManagerClass.DataAccess.Concrete;

namespace TaskManagerClass.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TaskManagerController : ControllerBase
    {

        private readonly ITaskService _taskService;
  
        public TaskManagerController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost(Name = "CreateTask")]
        public async Task<IActionResult> CreateTask(Task task)
        {
            _taskService.Add(task);
            return Ok(task);
            
        }

        [HttpGet(Name = "GetAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            try
            {

                List<Task> tasks = _taskService.GetAll();
       
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("[action]/{id}", Name = "GetTask")]
        public async Task<IActionResult> GetTask(int id)
        {

            Task task= _taskService.GetById(id);
            if (task == null)
            {
                return NotFound($"Task with Id = {id} not found.");
            }

            return Ok(task);
        }



        [HttpGet("[action]/{CategoryID}", Name = "GetTasksByCategory")]
        public async Task<IActionResult> GetTasksByCategory(int CategoryID)
        {

            var task = _taskService.GetByCategoryId(CategoryID);

            if (task == null)
            {
                return NotFound($"No tasks found for CategoryID = {CategoryID}");
            }

            return Ok(task);
        }



        [HttpPut("{id}", Name = "UpdateTask")]
        public async Task<IActionResult> UpdateTask(int id,Task updatedTask)
        {

            var task = _taskService.GetById(id);

            if (task == null)
            {
                return NotFound($"Task with Id = {id} not found.");
            }
            updatedTask.Id = id;

            var updated = _taskService.Update(updatedTask);
            return Ok(updated);
        }


        [HttpDelete("{id}", Name = "DeleteTask")]
        public async Task <IActionResult> DeleteTask(int id)
        {

            Task task=_taskService.DeleteById(id);
            if (task == null)
            {
                return NotFound($"Task with Id = {id} not found.");
            }

            return Ok(id);
        }


    }
}

