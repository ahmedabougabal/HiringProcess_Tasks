
using Dr_GreicheTask.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void Update(T item);
        T Get(int id);
        void Delete(T item);

    }
}
