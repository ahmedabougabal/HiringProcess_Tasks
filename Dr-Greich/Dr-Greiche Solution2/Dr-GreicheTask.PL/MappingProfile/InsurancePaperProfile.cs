using AutoMapper;
using Dr_GreicheTask.PL.MappingProfile;
using Dr_GreicheTask.PL.Models;
using Dr_GreicheTask.PL.ViewModels;

namespace Demo.PL.MappingProfile
{
    public class InsurancePaperProfile:Profile
    {
        public InsurancePaperProfile()
        {
            CreateMap<InsurancePaperViewModel, InsurancePaper>();
            // .ForMember(d => d.EmploymentContract, o => o.MapFrom(s => s.EmploymentContractFile));


          //  CreateMap<InsurancePaperViewModel, InsurancePaper>();
            // .ForMember(d => d.Q1Insurances, o => o.MapFrom(s => s.Q1InsurancesFile)).ReverseMap();

           // CreateMap<InsurancePaperViewModel, InsurancePaper>();
          //  .ForMember(d => d.Q6Insurances, o => o.MapFrom(s => s.Q6InsurancesFile)).ReverseMap();



            //CreateMap<InsurancePaperViewModel, InsurancePaper>()
            //       .ForMember(d => d.Employee, o => o.MapFrom(s => s.Employee)).ReverseMap();
            //CreateMap<InsurancePaperViewModel, InsurancePaper>()
            //   .ForMember(d => d.EmployeeId, o => o.MapFrom(s => s.EmployeeId)).ReverseMap();
            //CreateMap<InsurancePaperViewModel, InsurancePaper>()
            //.ForMember(d => d.InsurancePaperId, o => o.MapFrom(s => s.InsurancePaperId)).ReverseMap();
            //CreateMap<InsurancePaperViewModel, InsurancePaper>()
            // .ForMember(d => d.Q1InsurancesExpireDate, o => o.MapFrom(s => s.Q1InsurancesExpireDate)).ReverseMap();
            //CreateMap<InsurancePaperViewModel, InsurancePaper>()
            //.ForMember(d => d.RenewalDate, o => o.MapFrom(s => s.RenewalDate)).ReverseMap();

        }
    }
    
}
