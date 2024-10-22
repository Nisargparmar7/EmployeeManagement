using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeeManagement.ViewComponents
{
    public class ShowJobViewComponent : ViewComponent
    {
        private readonly IJobReposetory _jobReposetory;
        private readonly IAllocationReposetory _allocationReposetory;

        public ShowJobViewComponent(IJobReposetory jobReposetory, IAllocationReposetory allocationReposetory)
        {
            _jobReposetory = jobReposetory;
            _allocationReposetory = allocationReposetory;
        }

        public IViewComponentResult Invoke()
        {
            // Retrieve the UserId from the session
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                // Return a view indicating no jobs if the user is not logged in
                return View();
            }

            // Fetch the user's allocation (assuming one allocation per user)
            var userAllocation = _allocationReposetory.GetAll()
                .FirstOrDefault(allocation => allocation.StaffId == userId);

            if (userAllocation == null)
            {
                // Return a view indicating no jobs if no allocation is found
                return View(null);
            }

            // Get the job details associated with the user's allocation
            var userJob = _jobReposetory.getJobByJobId(userAllocation.JobId);

            // Pass the job to the view
            return View(userJob);
        }
    }
}
