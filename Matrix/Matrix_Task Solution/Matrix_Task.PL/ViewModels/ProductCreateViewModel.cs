using MAtrixTask.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace XceedTask.PL.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }

    }
}
