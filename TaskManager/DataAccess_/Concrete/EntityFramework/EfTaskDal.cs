using TaskManagerClass.Core.DataAccess.EntityFramework;
using TaskManagerClass.DataAccess.Abstract;
using TaskManagerClass.DataAccess.Concrete;

namespace TaskManager.DataAccess.Concrete.EntityFramework
{
    public class EfTaskDal: EfEntityRepository<Task,TaskManagerContext>,ITaskDal
    {
    }
}
