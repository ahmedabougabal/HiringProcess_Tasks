namespace Dr_GreicheTask.PL.Models
{
    public class InsuranceRenewal
    {
        public int InsuranceRenewalId { get; set; }
        public int InsurancePaperId { get; set; }
        public DateTime RenewalDate { get; set; }
        public string RenewalDocument { get; set; }
        public InsurancePaper InsurancePaper { get; set; }
    }
}
