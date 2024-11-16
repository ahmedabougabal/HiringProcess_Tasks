using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XceedTask.BLL.Interfaces;
using XceedTask.DAL.Contexts;
using XceedTask.DAL.Models;

namespace XceedTask.BLL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly TaskDbContext _dbcontext;

        public CategoryRepository(TaskDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

    }
}
