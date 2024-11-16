using AutoMapper;
using Demo.BLL;
using Demo.BLL.Interfaces;
using Dr_GreicheTask.BLL.Repositories;
using Dr_GreicheTask.PL.Data;
using Dr_GreicheTask.PL.Helpers;
using Dr_GreicheTask.PL.Models;
using Dr_GreicheTask.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dr_GreicheTask.PL.Controllers
{
    public class InsurancePaperController : Controller
    {
        private readonly InsurancePaperRepository insurancePaperRepository;
        private readonly IUintOfWork _uintOfWork;
        private readonly IMapper _mapper;
        private readonly InsuranceDbContext _dbcontext;

        public InsurancePaperController(IMapper mapper, IUintOfWork uintOfWork, InsuranceDbContext dbContext)
        {

            _mapper = mapper;
            _uintOfWork = uintOfWork;
            _dbcontext = dbContext; // this just for work around and solve the problem of select dousnt work with list<>
                                    // but after implementing all repo and interfaces .. will depend totally on iunitofwork 

        }

        // Create operation 
        [HttpGet]
        public IActionResult Create()
        {

            var employees = _dbcontext.Employees.ToList();


            var employeeList = employees.Select(e => new SelectListItem
            {
                Text = e.Name,                  // Display text in the dropdown
                Value = e.EmployeeId.ToString() // Value to be sent to the server when selected
            }).ToList();

            // Pass the employeeList to your view
            ViewBag.EmployeeList = employeeList;


            return View();
        }
        [HttpPost]
        public IActionResult Create(int employeeId, InsurancePaperViewModel paperVM)
        {
            if (ModelState.IsValid)
            {

                paperVM.EmploymentContract = DocumentSettings.Upload(paperVM.EmploymentContractFile, "Images");
                paperVM.Q1Insurances = DocumentSettings.Upload(paperVM.Q1InsurancesFile, "Images");
                paperVM.Q6Insurances = DocumentSettings.Upload(paperVM.Q6InsurancesFile, "Images");


                InsurancePaper paper = _mapper.Map<InsurancePaperViewModel, InsurancePaper>(paperVM);
                //   _uintOfWork.insurancePaperRepository.Add(paper);
                //_uintOfWork.Complete();

                _dbcontext.InsurancePapers.Add(paper);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // Read operation 
        public IActionResult Index()
        {
            List<InsurancePaper> insurancePapers = _dbcontext.InsurancePapers
                .Include(p => p.Employee)
                .ToList();


            return View(insurancePapers);
        }

        // Update operation 
        [HttpGet]
        public IActionResult Update(int id)
        {
            var employees = _dbcontext.Employees.ToList(); // same problem

            // Create a projection to convert Employee objects to SelectListItem
            var employeeList = employees.Select(e => new SelectListItem
            {
                Text = e.Name,    // Display text in the dropdown
                Value = e.EmployeeId.ToString() // Value to be sent to the server when selected
            }).ToList();

            // Pass the employeeList to your view
            ViewBag.EmployeeList = employeeList;

            var insurancePaper = _dbcontext.InsurancePapers.Find(id);
            //var insurancePaper = _uintOfWork.insurancePaperRepository.Get(id); 


            InsurancePaperViewModel x = new InsurancePaperViewModel();

            return View(x);
        }

        [HttpPost] // it should be httpPut
        public IActionResult Update(int id, InsurancePaperViewModel updatedPaper)
        {
            if (ModelState.IsValid)
            {
                updatedPaper.EmploymentContract = DocumentSettings.Upload(updatedPaper.EmploymentContractFile, "Images");
                updatedPaper.Q1Insurances = DocumentSettings.Upload(updatedPaper.Q1InsurancesFile, "Images");
                updatedPaper.Q6Insurances = DocumentSettings.Upload(updatedPaper.Q6InsurancesFile, "Images");

                InsurancePaper paper = _dbcontext.InsurancePapers.Find(id);

                InsurancePaper newpaper = _mapper.Map<InsurancePaperViewModel, InsurancePaper>(updatedPaper);

                //_uintOfWork.insurancePaperRepository.Delete(paper);
                //_uintOfWork.insurancePaperRepository.Add(newpaper);
                //_uintOfWork.Complete();
                _dbcontext.InsurancePapers.Remove(paper);
                _dbcontext.InsurancePapers.Add(newpaper);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // Delete operation 
        public IActionResult Delete(int id)
        {
            var paper = _dbcontext.InsurancePapers.Find(id);
            if (paper == null)
            {
                return NotFound();
            }

            _dbcontext.InsurancePapers.Remove(paper);
            _dbcontext.SaveChangesAsync();
            //_uintOfWork.insurancePaperRepository.Delete(paper);

            //_uintOfWork.Complete();

            return RedirectToAction("Index");
        }
        public IActionResult DashBoardView()
        {
            List<Employee> dashboardcompleted = _dbcontext.Employees.Include(i => i.InsurancePapers)
                .Include(i => i.Department)
             .Where(e => e.InsurancePapers.Q1Insurances != null || e.InsurancePapers.Q6Insurances != null || e.InsurancePapers.EmploymentContract != null).ToList();

            List<Employee> dashboardUncompleted = _dbcontext.Employees.Include(i => i.InsurancePapers)
                .Include(i => i.Department)
                .Where(e => e.InsurancePapers.Q1Insurances == null || e.InsurancePapers.Q6Insurances == null || e.InsurancePapers.EmploymentContract == null).ToList();
            ViewBag.DashboardUnCompleted = dashboardUncompleted;

            return View(dashboardcompleted); // This assumes the view is named "MyDashboard.cshtml"
        }



    }
}
