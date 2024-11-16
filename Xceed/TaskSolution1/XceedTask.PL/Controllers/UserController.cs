using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Net;
using XceedTask.DAL.Models;
using XceedTask.PL.ViewModels;

namespace XceedTask.PL.Controllers
{


    public class UserController : Controller
    {
        //identity
        //class using in create 
        UserManager<User> UserManager;

        //Class using Signin and SignOut
        SignInManager<User> SignInManager;
        RoleManager<IdentityRole> RoleManager;

        public UserController(UserManager<User> _UserManager,
            SignInManager<User> _SignInManager,
            RoleManager<IdentityRole> roleManager)
        {

            UserManager = _UserManager;
            SignInManager = _SignInManager;
            RoleManager = roleManager;

        }

        [HttpGet]
        //Go to sign up
        public IActionResult SignUp()
        {
            ViewBag.Roles = RoleManager.Roles
              .Select(i => new SelectListItem(i.Name, i.Name));

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            //Vaildate UserCreate IS False
            if (ModelState.IsValid == false)
                return View(); //Go to view/user/signup
            else
            {
                //Vaildate UserCreate IS True
                //Add  User to Object from Class User
                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                //threating 
                //Add User to database and hash password 
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                //Create is false return messange to view description
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);
                    });
                    return View();
                }
                //
                else
                {
                    await UserManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index", "Product");
                }

            }
        }
        [HttpGet]
        public IActionResult SignIn(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            //Go to view/user/signin
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid == false)
                return View();//Go to view/user/signin
            else
            {
                //threating 
                //Check login by username and password 
                //option Remember
                var result
                     = await SignInManager.PasswordSignInAsync
                        (model.UserName, model.Password, model.RememberMe,
                             true);
                //Failed  login
                if (result.Succeeded == false)
                {
                    ModelState.AddModelError("", "Invalid User Name Of Password");
                    return View();//Go to view/user/signin
                }
                else if (result.IsLockedOut == true)
                {
                    ModelState.AddModelError("", "You're Locked Out Please Try Again After 20 Minute");
                    return View();
                }
                else
                {
                    //Success  login And Correct Cookies
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                        return LocalRedirect(model.ReturnUrl);
                    else
                        return RedirectToAction("Index", "Product");
                }
            }
        }
        [HttpGet]
        //signout
        public new async Task<IActionResult> SignOut()
        {
            //threating 
            //Sign out
            //Get User Using Cookies
            await SignInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");//Go to view/user/signin
        }
    }
}

