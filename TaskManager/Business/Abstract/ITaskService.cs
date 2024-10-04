namespace TaskManagerClass.Business.Abstract
{
    public interface ITaskService
    {
        List<Task> GetAll();

        void Add(Task task);
        Task GetById(int id);
        Task Update(Task task);
        Task DeleteById(int id);

        List<Task> GetByCategoryId(int categoryId);
    }
}
