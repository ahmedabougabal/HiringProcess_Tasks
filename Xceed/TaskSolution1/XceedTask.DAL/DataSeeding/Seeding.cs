using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using XceedTask.DAL.Models;

namespace XceedTask.DAL.DataSeeding
{
    public static class Seeding
    {

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Category>()
              .HasData(new Category { Id = 1, Name = "Mobile" },
                       new Category { Id = 2, Name = "Laptop" },
                       new Category { Id = 3, Name = "Accessories" });

        }
    }
}
