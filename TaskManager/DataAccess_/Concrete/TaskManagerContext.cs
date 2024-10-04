using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerClass.DataAccess.Concrete
{

    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() { }
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
          : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        //yapılandırma
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5HSEV6B\\SQLEXPRESS;Database=taskmanager;Trusted_Connection=True; TrustServerCertificate=True");
        }
    }



}
