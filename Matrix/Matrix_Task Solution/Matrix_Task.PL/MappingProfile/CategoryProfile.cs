using AutoMapper;
using Matrix_Task.PL.ViewModels;
using MAtrixTask.DAL.Models;

namespace Demo.PL.MappingProfile
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, Category>().ReverseMap();
        }
    }
}
