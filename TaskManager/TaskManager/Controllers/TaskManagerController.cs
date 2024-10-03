using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskManager.Context;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TaskManagerController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public TaskManagerController(TaskManagerContext context)
        {
            _context = context;
        }


        [HttpPost(Name = "CreateTask")]
        public async Task<IActionResult> CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpGet(Name = "GetAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            try
            {
            //TaskManagerContext context = new();

                List<Task> tasks =await _context.Tasks.ToListAsync();
       
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
            Task task = await _context.Tasks.Where(t => t.Id == id).SingleOrDefaultAsync();
           // TaskManager task = await _context.TaskManager.SingleOrDefaultAsync(t => t.Id == id);


            //await context.TaskManager.ToListAsync();
            if (task == null)
            {
                return NotFound($"Task with Id = {id} not found.");
            }

            return Ok(task);
        }



        [HttpGet("[action]/{CategoryID}", Name = "GetTasksByCategory")]
        public async Task<IActionResult> GetTasksByCategory(int CategoryID)
        {
            //TaskManager tasks = await _context.TaskManager.FirstOrDefaultAsync(t => t.CategoryID == CategoryID);

            List<Task> tasks = await _context.Tasks.Where(t => t.CategoryID == CategoryID).ToListAsync();



            //await context.TaskManager.ToListAsync();
            if (tasks == null)
            {
                return NotFound($"No tasks found for CategoryID = {CategoryID}");
            }

            return Ok(tasks);
        }



        [HttpPut("{id}", Name = "UpdateTask")]
        public async Task<IActionResult> UpdateTask(int id,Task updatedTask)
        {
            Task task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
         

            if (task == null)
            {
                return NotFound($"Task with Id = {id} not found.");
            }

            task.TaskName = updatedTask.TaskName;
            task.Status= updatedTask.Status;
            task.PriorityLevel= updatedTask.PriorityLevel;
            task.ProjectName= updatedTask.ProjectName;
            task.CategoryID= updatedTask.CategoryID;
            task.Description= updatedTask.Description;

           _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return Ok(id);
        }


        [HttpDelete("{id}", Name = "DeleteTask")]
        public async Task <IActionResult> DeleteTask(int id)
        {
            Task task= await _context.Tasks.FirstOrDefaultAsync(t=>t.Id == id);

            if (task == null)
            {
                return NotFound($"Task with Id = {id} not found.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(id);
        }


    }
}
