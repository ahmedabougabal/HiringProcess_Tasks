using Dr_GreicheTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUintOfWork: IDisposable
    {
        //public IEmployeeRepository EmployeeRepository { get; set; }
        //public IDepartmentRepository DepartmentRepository { get; set; }
       public IinsurancePaperRepository insurancePaperRepository { get; set; }
       

        Task<int> Complete();
      


    }
}
