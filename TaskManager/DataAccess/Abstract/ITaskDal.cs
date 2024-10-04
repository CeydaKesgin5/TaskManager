using TaskManagerClass.Core.DataAccess;

namespace TaskManagerClass.DataAccess.Abstract
{
    public interface ITaskDal : IEntityRepository<Task>
    {
        List<Task> GetByCategoryId(int categoryId);
    }
}
