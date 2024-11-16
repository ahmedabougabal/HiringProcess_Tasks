using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XceedTask.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedByUserId { get; set; } = " "; // User Info (Token to identify user info)
        public DateTime StartDate { get; set; }

        // public DateTime Duration { get; set; } // I replaced it with EndDate because I do not know the number. It consists of months, years, or days
        //                                           instead of using subtraction and addition to find out the end date.
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
