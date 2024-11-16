using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using XceedTask.BLL;
using XceedTask.BLL.Interfaces;
using XceedTask.DAL.Models;
using XceedTask.PL.ViewModels;

namespace XceedTask.PL.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUintOfWork _uintOfWork;
        UserManager<User> _UserManager;

        public ProductController(IUintOfWork uintOfWork, UserManager<User> UserManager)
        {
            _UserManager = UserManager;
            _uintOfWork = uintOfWork;
        }

        // GET: ProductController
        [Authorize]
        public async Task<ActionResult> IndexAsync()
        {
            var user = await _UserManager.GetUserAsync(User);
            var userRoles = await _UserManager.GetRolesAsync(user);
            if (userRoles.Contains("Admin"))
            {
                var products = await _uintOfWork.ProductRepository.GetAll();
                return View("Index", products);
            }
            else
            {
                var products = await _uintOfWork.ProductRepository.GetAllAvailable();
                return View("UserIndex", products);

            }
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var product = await _uintOfWork.ProductRepository.Get(id.Value);

            if (product is null)
                return NotFound();

            return View(product);
        }

        // GET: ProductController/Create
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {

            ViewBag.category = (await _uintOfWork.CategoryRepository.GetAll())

            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
                //  Selected = a.Id.ToString() == Value
            });

            return View();

        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.GetUserAsync(User);
                product.CreatedByUserId = user.Id;
                await _uintOfWork.ProductRepository.Add(product);
                await _uintOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.category = (await _uintOfWork.CategoryRepository.GetAll())

                             .Select(a => new SelectListItem
                             {
                                 Value = a.Id.ToString(),
                                 Text = a.Name
                                 //  Selected = a.Id.ToString() == Value
                             });

            return View(product);
        }

        // GET: ProductController/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var product = await _uintOfWork.ProductRepository.Get(id.Value);


            if (product is null)
                return NotFound();


            ViewBag.category = (await _uintOfWork.CategoryRepository.GetAll())

                             .Select(a => new SelectListItem
                             {
                                 Value = a.Id.ToString(),
                                 Text = a.Name
                                 //  Selected = a.Id.ToString() == Value
                             });

            return View(product);

        }

        // POST: ProductController/Edit/5
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit([FromRoute] int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _UserManager.GetUserAsync(User);
                    product.CreatedByUserId = user.Id;

                    _uintOfWork.ProductRepository.Update(product);
                    await _uintOfWork.Complete();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewBag.category = (await _uintOfWork.CategoryRepository.GetAll())

                            .Select(a => new SelectListItem
                            {
                                Value = a.Id.ToString(),
                                Text = a.Name
                                //  Selected = a.Id.ToString() == Value
                            });
            return View(product);
        }



        // Get: ProductController/Delete/5
        // 
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            

            try
            {
                var product = await _uintOfWork.ProductRepository.Get(id);
                if (id != product.Id)
                {
                    return BadRequest();
                }
                _uintOfWork.ProductRepository.Delete(product);
                await _uintOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
        public async Task <IActionResult> Filter(int? id)
        {
            ViewBag.category = (await _uintOfWork.CategoryRepository.GetAll())

                           .Select(a => new SelectListItem
                           {
                               Value = a.Id.ToString(),
                               Text = a.Name
                               //  Selected = a.Id.ToString() == Value
                           });

            ViewBag.categoryID = id;


            if (id == null)
            {
                IEnumerable<Product> filteredProducts = await _uintOfWork.ProductRepository.GetAllAvailable();
                // Filter products by the selected category
                return View("Filter", filteredProducts);
            }
            else
            {
                IEnumerable<Product> filteredProducts = ( await _uintOfWork.ProductRepository.GetAllAvailable()).Where(p => p.Category.Id == id);

                return View("Filter", filteredProducts);
            }

         
           
        }
    }
}
