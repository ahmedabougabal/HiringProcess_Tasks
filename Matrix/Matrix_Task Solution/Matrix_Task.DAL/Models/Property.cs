using MAtrixTask.DAL.Models;

namespace Matrix_Task.DAL.Models
{
    public class Property
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductProperty> ProductProperties { get; set; }
    }
}
