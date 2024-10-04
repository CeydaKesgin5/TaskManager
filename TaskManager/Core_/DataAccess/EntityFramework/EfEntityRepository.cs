using Microsoft.EntityFrameworkCore;
using TaskManagerClass.Core.Entities;

namespace TaskManagerClass.Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new() //TEntity class olmalı, IEntity türünde olup newlenebilmeli
        where TContext: DbContext,new()

    {
      
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())//using içindeki context garbage collector yardımıyla belleği hızlıca temizler.Performans için yazıldı.
            {
                context.Add(entity);
                context.SaveChangesAsync();

               
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetAll()
        {


            using (TContext context = new TContext())
            {           
                return context.Set<TEntity>().ToList();

            }
        }


        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                
                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        List<Task> IEntityRepository<TEntity>.GetByCategoryId(int categoryId)
        {
            using (TContext context = new TContext())
            {
                return context.Set<Task>()
                .Where(e => EF.Property<int>(e, "CategoryID") == categoryId)
                .ToList();
            }
        }

    
    }
}
