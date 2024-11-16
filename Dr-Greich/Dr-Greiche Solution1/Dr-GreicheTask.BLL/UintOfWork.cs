using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Dr_GreicheTask.BLL.Interfaces;
using Dr_GreicheTask.BLL.Repositories;
using Dr_GreicheTask.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    public class UintOfWork : IUintOfWork
    {
        private readonly InsuranceDbContext _dbcontext;
        public IinsurancePaperRepository insurancePaperRepository { get ; set ; }
      //  public IEmployeeRepository iemployeeRepository { get; set; }



        public UintOfWork(InsuranceDbContext dbcontext)
        {
          
           insurancePaperRepository = new InsurancePaperRepository(dbcontext);
          //  iemployeeRepository = new EmployeeRepository(dbcontext);

            _dbcontext = dbcontext;
        }


        public async Task<int> Complete()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

   
    }
}
