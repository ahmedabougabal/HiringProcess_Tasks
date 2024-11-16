using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Task.Models;
using Task.Reposatory;

namespace Task.Controllers
{
   

    public class RouteController : Controller
    {
        private readonly IRoute _route;
        private readonly EmailService emailService;

        public RouteController(IRoute _route, EmailService emailService)
        {
            this._route = _route;
            this.emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Routes routes)
        {
            if(ModelState.IsValid)
            {
                _route.insert(routes);
                _route.save();
                if (Request.Form.ContainsKey("sendEmail"))
                {
                    string to = routes.Email;
                    string subject = "Create Route";
                    string body = "Route is created";

                    emailService.SendEmail(to, subject, body);
                }

                return RedirectToAction("read");
            }
            return View(routes);
        }

        public IActionResult Read()
        {
            var query = new Expression<Func<Routes, object>>[]
            {
                e=>e.samplesRoutes,

            };
            List<Routes> routes = _route.GetAll(query);
            List<Sample> samples = _route.GetSamples();
               return View(routes);
        }
        public IActionResult Edite(int Code)
        {   
            Routes routes=_route.GetById(Code);
            ViewData["samples"]=_route.GetSamples();
            return View(routes);
        }
        [HttpPost]
        public IActionResult Edite(Routes routes)
        {
            if (routes != null)
            {
                _route.update(routes);
                _route.save();
                return RedirectToAction("read");
            }
            ViewData["samples"] = _route.GetSamples();
            return View(routes);
        }

        public IActionResult Delete(int Code)
        {
            _route.Delete(Code);
            _route.save();
            return RedirectToAction("read");
        }
    }
}
