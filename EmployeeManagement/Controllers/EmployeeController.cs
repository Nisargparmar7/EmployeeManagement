using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private IuserReposetory userReposetory;
        private IJobReposetory jobReposetory;
        private IAllocationReposetory allocationReposetory;

        public EmployeeController(IuserReposetory userReposetory, IJobReposetory jobReposetory, IAllocationReposetory allocationReposetory)
        {
            this.userReposetory = userReposetory;
            this.jobReposetory = jobReposetory;
            this.allocationReposetory = allocationReposetory;
        }
        private bool CheckForAuthentication()
        {
            // Check if the session value "IsLoggedIn" exists and is set to "true"
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            // Return true if the user is logged in, otherwise false
            return !string.IsNullOrEmpty(isLoggedIn) && isLoggedIn == "true";
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowEmployee()
        {
            if (CheckForAuthentication()) {
                AllocateViewModel allocateViewModel = new AllocateViewModel();
                allocateViewModel.users=userReposetory.getAll().Where((u)=>u.Role==UserRole.Employee).ToList();
                allocateViewModel.jobs = jobReposetory.getJobs();
                ViewBag.isLogIn = true;
                return View(allocateViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

            
        }

        [HttpPost]
        public IActionResult Allocate(int selectedEmployeeId, int selectedJobId)
        {

            if (CheckForAuthentication())
            {
                if (selectedEmployeeId > 0 && selectedJobId > 0)
                {
                    JobModel jobModel = jobReposetory.getJobByJobId(selectedJobId);
                    // Create a new allocation entry
                    var allocation = new AllocationModel
                    {
                        StaffId = selectedEmployeeId, // Employee ID
                        JobId = selectedJobId, // Job ID
                        City=jobModel.City, //city
                    };
                    //check for already have allocation to this user or not ok

                    List<AllocationModel> allocationList = allocationReposetory.GetAll();
                    allocationList=allocationList.Where((alloc)=>alloc.StaffId==selectedEmployeeId).ToList();
                    if (allocationList.Count == 0)
                    {
                        // Save the allocation (assuming you have a method in your repository)
                        allocationReposetory.AllocateJobToUser(allocation);

                    }
                    else
                    {
                        allocation = allocationList[0];
                        allocation.City=jobModel.City;
                        allocation.JobId=selectedJobId;
                        allocationReposetory.updateAllocation(allocation);
                    }


                    return RedirectToAction("Index","Home"); // Redirect to a suitable page after allocation
                }
                else
                {
                    ModelState.AddModelError("", "Please select both an employee and a job title.");
                }
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View(); // Return to the same view if the allocation fails
        }

    }
}
