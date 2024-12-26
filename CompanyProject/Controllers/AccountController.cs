using CompanyProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyProject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CompanyProject.Controllers
{
    public class AccountController : Controller
    {
    

        public IActionResult LoginForm()
        {
            return View();
        }

        CompanyContext context = new(); 

        [HttpPost]
        public IActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetInt32("UserId", user.Id);

                    return RedirectToAction("Index", "User");
                }

                TempData["ErrorMessage"] = "Invalid email or password.";
                return RedirectToAction("LoginForm");
            }

            return View("LoginForm", model);
        }

        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();
            return RedirectToAction("LoginForm");  
        }


    }
}
