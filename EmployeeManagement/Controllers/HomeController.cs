using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {

        private IJobReposetory JobReposetory;
        private bool CheckForAuthentication()
        {
            // Check if the session value "IsLoggedIn" exists and is set to "true"
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            // Return true if the user is logged in, otherwise false
            return !string.IsNullOrEmpty(isLoggedIn) && isLoggedIn == "true";
        }


        public HomeController(IJobReposetory jobReposetory)
        {
            JobReposetory = jobReposetory;
        }

        public IActionResult Index()
        {
            if (CheckForAuthentication())
            {
                ViewBag.Role=HttpContext.Session.GetString("Role").ToString();
                ViewBag.isLogIn = true;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
            
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult SubmitJob(JobModel job)
        {
            if (ModelState.IsValid)
            {
                JobReposetory.createJob(job); // Save the job using the repository method
                return RedirectToAction("Index"); // Redirect to the Index page after successful submission
            }

            return View("Index", job); // If invalid, return to the Index view with the current job model
        }

        public IActionResult DeleteJob(int jobId)
        {
            if (jobId > 0)
            {
                // Call the repository to delete the job
                var job = JobReposetory.getJobByJobId(jobId);
                if (job != null)
                {
                    JobReposetory.deleteJob(job);
                    TempData["SuccessMessage"] = "Job deleted successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Job not found.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Job ID.";
            }

            // Redirect back to the job list or another suitable page
            return RedirectToAction("Index","Home"); // Change to the appropriate action if needed
        }

        
           
        }

    
}
