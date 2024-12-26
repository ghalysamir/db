using CompanyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyProject.Controllers
{
    public class UserController : Controller
    {
        private CompanyContext Context = new CompanyContext();
        // /User/Index
        //get all
        public IActionResult Index()
        {
            List<User> users = Context.Users.ToList();

            return View(users);//viewName=Action=Index ,Model=employees
        }


        // User/Details/
        //get by Id
        public IActionResult Details(int id)
        {
            if (id <= 0) { return View("NotFound"); }

            User? usr = Context.Users.Where(usr => usr.Id == id).SingleOrDefault();
            if (usr != null)
            {
                return View(usr);
            }
            else
            {
                return View("NotFound");
            }

        }


        //Action to get Form
        // /User/AddForm
        public IActionResult AddForm()
        {
            return View();
        }

        // Action to save in DB
        //  /User/AddTODB
        public IActionResult AddTODB(User usr)
        {
            Context.Users.Add(usr);
            Context.SaveChanges();


            TempData["Message"] = "User added successfully";

            return RedirectToAction("Index");

        }
        //  /User/Delete/
        //Delete

        public IActionResult Delete(int id)
        {
            if (id <= 0) { return View("NotFound"); }
            User? usr = Context.Users.SingleOrDefault(u => u.Id == id);
            if (usr == null)
            {
                TempData["Message"] = "User not found";
                return View("NotFound");
            }

            Context.Users.Remove(usr);
            Context.SaveChanges();


            TempData["Message"] = "User deleted successfully";

            return RedirectToAction("Index");

        }

        // Edit form
        public IActionResult EditForm(int id)
        {
            if (id <= 0) { return View("NotFound"); }
            User? usr = Context.Users.SingleOrDefault(usr => usr.Id == id);
            if (usr == null) { return View("NotFound"); }

            return View(usr);
        }
        // Edit Db
        public IActionResult EditDB(User usr)
        {
            User? Oldusr = Context.Users.SingleOrDefault(u => u.Id == usr.Id);
            if (Oldusr == null)
            {
                TempData["Message"] = "User not found";
                return View("NotFound");
            }
            Oldusr.Name = usr.Name;
            Oldusr.Age = usr.Age;
            Oldusr.Email = usr.Email;
            Oldusr.Password = usr.Password;
            Context.SaveChanges();


            TempData["Message"] = "User data has been modified successfully";

            return RedirectToAction("Index");

        }


  
    }
} 