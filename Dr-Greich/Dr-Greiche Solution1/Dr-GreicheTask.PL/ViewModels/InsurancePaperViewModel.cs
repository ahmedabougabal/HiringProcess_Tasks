using Dr_GreicheTask.PL.Models;

namespace Dr_GreicheTask.PL.ViewModels
{
    public class InsurancePaperViewModel
    {
        public int InsurancePaperId { get; set; }
        public int EmployeeId { get; set; }
        public string EmploymentContract { get; set; }
        public IFormFile EmploymentContractFile { get; set; }
        public string Q1Insurances { get; set; }
        public IFormFile Q1InsurancesFile { get; set; } 
        public DateTime Q1InsurancesExpireDate { get; set; }
        public string Q6Insurances { get; set; }
        
        public IFormFile Q6InsurancesFile { get; set; } 
        public DateTime RenewalDate { get; set; }

        public Employee Employee { get; set; }

    }
}
