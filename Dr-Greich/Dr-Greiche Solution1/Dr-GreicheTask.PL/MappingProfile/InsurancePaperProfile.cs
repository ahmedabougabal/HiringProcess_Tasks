using AutoMapper;
using Dr_GreicheTask.PL.Models;
using Dr_GreicheTask.PL.ViewModels;

namespace Demo.PL.MappingProfile
{
    public class InsurancePaperProfile : Profile
    {
        public InsurancePaperProfile()
        {
            CreateMap<InsurancePaperViewModel, InsurancePaper>();
            // .ForMember(d => d.EmploymentContract, o => o.MapFrom(s => s.EmploymentContractFile));



        }
    }

}
