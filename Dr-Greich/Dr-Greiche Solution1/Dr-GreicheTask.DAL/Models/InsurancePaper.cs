
using Microsoft.AspNetCore.Http;
namespace Dr_GreicheTask.PL.Models
{
    public class InsurancePaper 
    {
        public int InsurancePaperId { get; set; }
        public int EmployeeId { get; set; }
        public string EmploymentContract { get; set; } 
        public string Q1Insurances { get; set; } 
        public DateTime Q1InsurancesExpireDate { get; set; }
        public string Q6Insurances { get; set; } 
        public DateTime RenewalDate { get; set; }
        public Employee Employee { get; set; }
    }
}
