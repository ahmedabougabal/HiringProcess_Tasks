using MAtrixTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using XceedTask.BLL.Interfaces;
using XceedTask.DAL.Contexts;

namespace XceedTask.BLL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        private readonly TaskDbContext _dbcontext;

        public ProductRepository(TaskDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Product>> GetAllAvailable()
        {

            return (IEnumerable<Product>)await _dbcontext.Products.Where(E => E.EndDate < DateTime.Now).Include(E => E.Category).ToListAsync();
         
        }

      
    }
}
