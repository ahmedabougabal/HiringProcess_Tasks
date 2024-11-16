using Demo.BLL.Interfaces;

using Dr_GreicheTask.PL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected readonly InsuranceDbContext _dbcontext;
        public GenericRepository(InsuranceDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }




        public void Add(T item)

        
           => _dbcontext.Set<T>().Add(item);
           
        

            public void Delete(T item)
         => _dbcontext.Set<T>().Remove(item);

        public T Get(int id)

       => _dbcontext.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
     =>  _dbcontext.Set<T>().ToList();

        public void Update(T item)

      => _dbcontext.Set<T>().Update(item);

     
    }
}