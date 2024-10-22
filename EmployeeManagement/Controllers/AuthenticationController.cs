using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IuserReposetory _userRepository;

        public AuthenticationController(IuserReposetory userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.isLogIn = false;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _userRepository.Login(userName, password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.UserName);
                HttpContext.Session.SetString("Role", user.Role.ToString());
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("IsLoggedIn", "true");
               
                // Assuming login is successful, redirect to the home or dashboard page
                return RedirectToAction("Index", "Home");
            }
            ViewBag.isLogIn = false;
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.isLogIn = false;
            return View(new UserModel());
        }

        [HttpPost]
        public IActionResult Register(UserModel model, string securityPassword)
        {
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Check if the user role is Manager
                if (model.Role == UserRole.Manager)
                {
                    // Validate the security password
                    if (string.IsNullOrEmpty(securityPassword) || securityPassword != "Nisarg123")
                    {
                        ViewBag.ErrorMessage = "For Manager role, you must enter the security password 'Nisarg123'.";
                        return View(model);
                    }
                }

                // Attempt to register the user
                var registeredUser = _userRepository.Register(model);
                if (registeredUser != null)
                {
                    // Redirect to the login page on successful registration
                    return RedirectToAction("Login");
                }

                ViewBag.ErrorMessage = "Username or email already exists.";
            }
            ViewBag.isLogIn = false;
            // If the model is not valid or registration fails, return the view with error message
            return View(model);
        }

        public IActionResult Logout()
        {
            // Clear all session data
            HttpContext.Session.Clear();

            // Optionally, you can also remove individual session keys if needed:
            // HttpContext.Session.Remove("Username");
            // HttpContext.Session.Remove("Role");
            // HttpContext.Session.Remove("UserId");
            // HttpContext.Session.Remove("IsLoggedIn");

            // Redirect the user to the login page after logging out
            return RedirectToAction("Login", "Authentication");
        }
    }
}
