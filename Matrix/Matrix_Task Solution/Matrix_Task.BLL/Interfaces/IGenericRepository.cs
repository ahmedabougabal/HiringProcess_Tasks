﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XceedTask.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T item);
        void Update(T item);
        Task<T> Get(int id);
        void Delete(T item);

    }
}
