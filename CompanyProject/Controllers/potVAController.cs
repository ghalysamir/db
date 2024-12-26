using CompanyProject.Models;
using CompanyProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CompanyProject.Controllers
{
    public class PotVAController : Controller
    {
        CompanyContext context=new CompanyContext();
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PostVM post) 
        {
            if (ModelState.IsValid)
            {
                Post pos = new()
                {
                    Title = post.Title,
                    Categort= post.Categort,
                    Body= post.Body,
                    Likes= post.Likes,
                    Share= post.Share,
                    User_Id=post.User_Id,
                };
                context.Add(pos);
                context.SaveChanges();
                return RedirectToAction("Index", "Post");
            }
            return View(post);
          
        }

    }
}
