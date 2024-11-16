using Matrix_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixTask.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductProperty> ProductProperties { get; set; }
    }
}
