using Dr_GreicheTask.PL.Models;
using Microsoft.EntityFrameworkCore;

namespace Dr_GreicheTask.PL.Data
{
    public class InsuranceDbContext : DbContext
    {
     

        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
            : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<InsurancePaper> InsurancePapers { get; set; }
        public DbSet<InsuranceRenewal> InsuranceRenewals { get; set; }
        public DbSet<Department> Departments { get; set; }
        
    }
}
