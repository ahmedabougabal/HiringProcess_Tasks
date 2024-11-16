namespace Dr_GreicheTask.PL.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public InsurancePaper InsurancePapers { get; set; }
    }
}
