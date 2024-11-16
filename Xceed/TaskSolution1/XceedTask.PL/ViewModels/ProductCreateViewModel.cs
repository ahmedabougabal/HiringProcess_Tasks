using Microsoft.AspNetCore.Mvc.Rendering;
using XceedTask.DAL.Models;

namespace XceedTask.PL.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }

    }
}
