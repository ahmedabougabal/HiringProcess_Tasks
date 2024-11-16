using MAtrixTask.DAL.Models;

namespace XceedTask.BLL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
       Task<IEnumerable<Product>> GetAllAvailable();
       

    }
}
