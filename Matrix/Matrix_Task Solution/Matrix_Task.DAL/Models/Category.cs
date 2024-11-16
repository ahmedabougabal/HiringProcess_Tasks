using Matrix_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixTask.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> Subcategories { get; set; }
        public List<CategoryProperty> CategoryProperties { get; set; }
    }
}
