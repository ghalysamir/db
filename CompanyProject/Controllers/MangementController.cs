using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace CompanyProject.Controllers
{
    public class MangementController : Controller
    {

        // /Mangement/SetCookies
        [HttpGet]
        public IActionResult SetCookies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30) 
            };

            Response.Cookies.Append(cookieName, cookieValue, cookieOptions);

            return RedirectToAction("ManageCookies");
        }

        // /Mangement/SetCookies
        public IActionResult ManageCookies()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCookies(string cookieName)
        {
            if (Request.Cookies.TryGetValue(cookieName, out string cookieValue))
            {
                ViewBag.CookieValue = cookieValue;
                ViewBag.CookieName = cookieName;
                return View("ManageCookies"); 
            }
            ViewBag.Message = $"Cookie '{cookieName}' not found.";
            return View("ManageCookies"); 
        }

        [HttpPost]
        public IActionResult DeleteCookies(string cookieName)
        {
            Response.Cookies.Delete(cookieName);
            ViewBag.Message = $"Cookie '{cookieName}' has been deleted.";
            return View("ManageCookies"); 
        }




    }
}
