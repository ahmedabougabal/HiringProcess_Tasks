using Matrix_Task.DAL.Models;
using MAtrixTask.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XceedTask.DAL.DataSeeding;

namespace XceedTask.DAL.Contexts
{
    public class TaskDbContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }

        // data seeding (default data )
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }

    }
}
