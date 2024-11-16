using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XceedTask.BLL.Interfaces
{
    public interface IUintOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }


        Task<int> Complete();
    }
}
