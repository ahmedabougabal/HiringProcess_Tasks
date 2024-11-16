using MAtrixTask.DAL.Models;
using XceedTask.BLL.Interfaces;
using XceedTask.DAL.Contexts;

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
