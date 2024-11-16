using Demo.BLL.Repositories;
using Dr_GreicheTask.BLL.Interfaces;
using Dr_GreicheTask.PL.Data;
using Dr_GreicheTask.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr_GreicheTask.BLL.Repositories
{
    public class InsurancePaperRepository : GenericRepository<InsurancePaper> , IinsurancePaperRepository
    {
       private readonly InsuranceDbContext _dbcontext;

        public InsurancePaperRepository(InsuranceDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }



    }
}
