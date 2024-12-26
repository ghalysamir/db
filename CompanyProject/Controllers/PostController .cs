using CompanyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Controllers
{
    public class PostController : Controller
    {
        CompanyContext context = new();
       

        // /Post Index
        public IActionResult Index()
        {
            List<Post> posts = context.posts.ToList();
            return View(posts);

        }

        public IActionResult UserPosts()
        {
            
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("LoginForm", "Account");  
            }

            
            List<Post> userPosts = context.posts.Where(p => p.User_Id == userId).ToList();

            return View(userPosts);
        }
        public IActionResult Details(int id)

        {
            Post? post = context.posts.SingleOrDefault(p => p.Id == id);
            if (post != null)
            {
                return View(post);
            }
            else
            {
                return View("NotFound");
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Post post) 
        {
            context.posts.Add(post);
            context.SaveChanges();
        return RedirectToAction(nameof(Index));
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Post? post = context.posts.SingleOrDefault(p=>p.Id == id);
            if (post == null) 
            {
                return View("NotFound");
            }
            return View(post);
        }
        [HttpPost]
        public IActionResult Edit(Post post) 
        {
              context.Update(post);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) { return View("NotFound"); }
            Post? Post = context.posts.SingleOrDefault(p=>p.Id==id);
            if (Post == null)
            {
                TempData["Message"] = "User not found";
                return View("NotFound");
            }

           context.posts.Remove(Post);
            context.SaveChanges();


            TempData["Message"] = "User deleted successfully";

            return RedirectToAction("Index");

        }


    }
}
