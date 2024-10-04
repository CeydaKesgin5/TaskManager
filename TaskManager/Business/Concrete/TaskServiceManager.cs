using Microsoft.EntityFrameworkCore;
using TaskManagerClass.Business.Abstract;
using TaskManagerClass.DataAccess.Abstract;

namespace TaskManagerClass.Business.Concrete
{
    public class TaskServiceManager : ITaskService
    {
        private readonly ITaskDal _taskDal;

        public TaskServiceManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        public void Add(Task task)
        {
            _taskDal.Add(task);
        }

        public Task DeleteById(int id)
        {
            var taskToDelete = _taskDal.Get(id);
            if (taskToDelete != null)
            {
                _taskDal.Delete(taskToDelete);
            }
            return taskToDelete;
        }

        public List<Task> GetAll()
        {
            return _taskDal.GetAll();
        }

        public List<Task> GetByCategoryId(int categoryId)
        {
            return _taskDal.GetByCategoryId(categoryId);

            
        }

        public Task GetById(int id)
        {
            return _taskDal.Get( id);
        }

        public Task Update(Task task)
        {
            var updatedTask = _taskDal.Get(task.Id);


            if (updatedTask != null)
            {
                updatedTask.TaskName = task.TaskName;
                updatedTask.Status = task.Status;
                updatedTask.PriorityLevel = task.PriorityLevel;
                updatedTask.ProjectName = task.ProjectName;
                updatedTask.CategoryID = task.CategoryID;
                updatedTask.Description = task.Description;

                _taskDal.Update(updatedTask);
            }
           
            return updatedTask;
        }
    }
}
