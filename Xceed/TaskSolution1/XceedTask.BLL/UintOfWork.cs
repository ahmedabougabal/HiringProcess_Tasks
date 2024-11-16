using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XceedTask.BLL.Interfaces;
using XceedTask.BLL.Repositories;
using XceedTask.DAL.Contexts;

namespace XceedTask.BLL
{
    public class UintOfWork : IUintOfWork
    {
        private readonly TaskDbContext _dbcontext;

        public IProductRepository ProductRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public UintOfWork(TaskDbContext dbcontext)
        {
            ProductRepository = new ProductRepository(dbcontext);
            CategoryRepository = new CategoryRepository(dbcontext);
            _dbcontext = dbcontext;
        }

        public async Task<int> Complete()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

    }

}
