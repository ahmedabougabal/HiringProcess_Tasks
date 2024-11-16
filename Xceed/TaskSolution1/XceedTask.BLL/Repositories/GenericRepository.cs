using Microsoft.EntityFrameworkCore;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected readonly TaskDbContext _dbcontext;
        public GenericRepository(TaskDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Add(T item)
           => await _dbcontext.Set<T>().AddAsync(item);


        public void Delete(T item)
           => _dbcontext.Set<T>().Remove(item);


        public async Task<T> Get(int id)
          => await _dbcontext.Set<T>().FindAsync(id);


        public async Task<IEnumerable<T>> GetAll() // I can use specification design pattern 
        {
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>)await _dbcontext.Products.Include(E => E.Category).ToListAsync();
            else
                return await _dbcontext.Set<T>().ToListAsync();
        }


        public void Update(T item)
            => _dbcontext.Set<T>().Update(item);

    }
}
