using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using XceedTask.DAL.DataSeeding;
using XceedTask.DAL.Models;

namespace XceedTask.DAL.Contexts
{
    public class TaskDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        // data seeding (default data )
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder); 
        }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }

    }
}
