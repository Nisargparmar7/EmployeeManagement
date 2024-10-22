using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.ViewComponents
{
    public class ListJobViewComponent : ViewComponent
    {
        private readonly IJobReposetory jobReposetory;

        public ListJobViewComponent(IJobReposetory jobReposetory)
        {
            this.jobReposetory = jobReposetory;
        }

        public IViewComponentResult Invoke()
        {
            List<JobModel> jobs = jobReposetory.getJobs(); // Fetch jobs from the repository
            return View(jobs); // Pass the list of jobs to the view
        }
    }
}
