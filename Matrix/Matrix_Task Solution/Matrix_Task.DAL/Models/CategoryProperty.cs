using MAtrixTask.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Matrix_Task.DAL.Models
{
    public class CategoryProperty
    {
        public int CategoryPropertyId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public DataType DataType { get; set; } // Enum representing data types
        public bool IsRequired { get; set; }
        // Add more properties for validation rules as needed
    }
}
