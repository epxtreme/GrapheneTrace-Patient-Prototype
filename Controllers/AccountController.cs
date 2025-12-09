using Microsoft.AspNetCore.Mvc;

namespace GrapheneTrace.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // patient login
        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Hard-coded demo credentials
            const string demoEmail = "patient@example.com";
            const string demoPassword = "password123";

            if (email == demoEmail && password == demoPassword)
            {
                // On success go to patient dashboard
                return RedirectToAction("Dashboard", "Patient");
            }

            // If it doesn't match, show error on the same page
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View();
        }
    }
}
