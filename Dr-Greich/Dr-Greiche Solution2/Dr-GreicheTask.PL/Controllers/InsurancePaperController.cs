using AutoMapper;
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
        private readonly InsuranceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public InsurancePaperController(IMapper mapper, InsuranceDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env; 
        }



        // Create operation 
        [HttpGet]
        public IActionResult Create()
        {
            // Assuming you have an Employee DbSet in your DbContext (InsuranceDbContext)
            var employees = _context.Employees.ToList();

            // Create a projection to convert Employee objects to SelectListItem
            var employeeList = employees.Select(e => new SelectListItem
            {
                Text = e.Name,    // Display text in the dropdown
                Value = e.EmployeeId.ToString() // Value to be sent to the server when selected
            }).ToList();

            // Pass the employeeList to your view
            ViewBag.EmployeeList = employeeList;
           

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int employeeId, InsurancePaperViewModel paperVM)
        {

           
            paperVM.EmploymentContract = DocumentSettings.Upload(paperVM.EmploymentContractFile,"Images");
            paperVM.Q1Insurances = DocumentSettings.Upload(paperVM.Q1InsurancesFile,"Images");
            paperVM.Q6Insurances = DocumentSettings.Upload(paperVM.Q6InsurancesFile,"Images");
           

            InsurancePaper paper = _mapper.Map<InsurancePaperViewModel,InsurancePaper>(paperVM);


            Console.WriteLine("dd");

            _context.InsurancePapers.Add(paper);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Read operation 
        public  IActionResult Index()
        {
            List<InsurancePaper> insurancePapers =  _context.InsurancePapers
                .Include(p => p.Employee)
                .ToList();

            // var paper = _mapper.Map<List<InsurancePaper>, List<InsurancePaperViewModel>>(insurancePapers);
            //var webRootPath = _env.WebRootPath;
            //var contentRootPath = _env.ContentRootPath;
            //var uploadPath = Path.Combine(_env.WebRootPath, "Images");
            //var configFile = Path.Combine(_env.ContentRootPath, "appsettings.json");




            return View(insurancePapers);
        }

        // Update operation 
        [HttpGet]
        public IActionResult Update(int? id)
        {
            var employees = _context.Employees.ToList();

            // Create a projection to convert Employee objects to SelectListItem
            var employeeList = employees.Select(e => new SelectListItem
            {
                Text = e.Name,    // Display text in the dropdown
                Value = e.EmployeeId.ToString() // Value to be sent to the server when selected
            }).ToList();

            // Pass the employeeList to your view
            ViewBag.EmployeeList = employeeList;

            var insurancePaper = _context.InsurancePapers.Find(id);
            if (insurancePaper == null)
            {
                return NotFound();
            }

            // var paper = _mapper.Map<InsurancePaper, InsurancePaperViewModel>(insurancePaper);
            InsurancePaperViewModel x = new InsurancePaperViewModel();

            return View(x);
        }
    
    [HttpPost] // it should be httpPut
        public async Task<IActionResult> Update(int id, InsurancePaperViewModel updatedPaper)
        {
            updatedPaper.EmploymentContract = DocumentSettings.Upload(updatedPaper.EmploymentContractFile,"Images");
            updatedPaper.Q1Insurances = DocumentSettings.Upload(updatedPaper.Q1InsurancesFile,"Images");
            updatedPaper.Q6Insurances = DocumentSettings.Upload(updatedPaper.Q6InsurancesFile,"Images");



            InsurancePaper paper = await _context.InsurancePapers.FindAsync(id);

            InsurancePaper newpaper = _mapper.Map<InsurancePaperViewModel, InsurancePaper>(updatedPaper);
            //if (paper == null)
            //{
            //    return NotFound();
            //}
            //if (updatedPaper.EmploymentContract != null )
            //{
            //    paper.EmploymentContract = updatedPaper.EmploymentContract;

            //}
            //if (updatedPaper.Q1Insurances != null)
            //{
            //    paper.Q1Insurances = updatedPaper.Q1Insurances;

            //}
            //if (updatedPaper.Q6Insurances != null)
            //{
            //    paper.Q6Insurances = updatedPaper.Q6Insurances;

            //}





            _context.InsurancePapers.Remove(paper);
            _context.InsurancePapers.Add(newpaper);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Delete operation 
        public async Task<IActionResult> Delete(int id)
        {
            var paper = await _context.InsurancePapers.FindAsync(id);
            if (paper == null)
            {
                return NotFound();
            }

            _context.InsurancePapers.Remove(paper);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult DashBoardView()
        {
            List<Employee> dashboardcompleted = _context.Employees.Include(i => i.InsurancePapers)
                .Include(i=>i.Department)
             .Where(e => e.InsurancePapers.Q1Insurances != null || e.InsurancePapers.Q6Insurances != null || e.InsurancePapers.EmploymentContract != null).ToList();

            List<Employee> dashboardUncompleted = _context.Employees.Include(i=>i.InsurancePapers)
                .Include(i => i.Department)
                .Where(e =>e.InsurancePapers.Q1Insurances == null || e.InsurancePapers.Q6Insurances == null || e.InsurancePapers.EmploymentContract == null).ToList();
            ViewBag.DashboardUnCompleted = dashboardUncompleted;

            return View(dashboardcompleted); // This assumes the view is named "MyDashboard.cshtml"
        }
     


    }
}
