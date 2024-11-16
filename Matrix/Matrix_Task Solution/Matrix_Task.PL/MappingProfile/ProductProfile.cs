using AutoMapper;


using Matrix_Task.PL.ViewModels;
using MAtrixTask.DAL.Models;

namespace Demo.PL.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
