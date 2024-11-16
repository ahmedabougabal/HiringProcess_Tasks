using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class Context :DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context>options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SampleGlasses;Integrated Security=True;TrustServerCertificate=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Routes>().
                HasKey(e => e.Code);
            modelBuilder.Entity<Sample>().
                HasKey(e => e.Code);
        }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Sample> samples { get; set; }
        public DbSet<SamplesRoutes> samplesRoutes { get; set; }
    }
}
