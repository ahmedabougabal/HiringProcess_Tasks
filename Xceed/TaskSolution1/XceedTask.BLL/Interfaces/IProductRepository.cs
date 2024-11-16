﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XceedTask.DAL.Models;

namespace XceedTask.BLL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
       Task<IEnumerable<Product>> GetAllAvailable();
       

    }
}
