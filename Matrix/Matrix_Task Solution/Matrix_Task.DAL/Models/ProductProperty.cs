using MAtrixTask.DAL.Models;

namespace Matrix_Task.DAL.Models
{
    public class ProductProperty
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryPropertyId { get; set; }
        public CategoryProperty CategoryProperty { get; set; }
        public string Value { get; set; }
    }
}
