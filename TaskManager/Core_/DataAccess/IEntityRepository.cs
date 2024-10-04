using System.Linq.Expressions;
using TaskManagerClass.Core.Entities;

namespace TaskManagerClass.Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity,new()
    {

        List<T> GetAll();
        T Get(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<Task> GetByCategoryId(int categoryId);
    }
}
