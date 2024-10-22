using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class JobReposetory : IJobReposetory
    {
        private readonly EmployeeDbContext _context;

        public JobReposetory(EmployeeDbContext context)
        {
            _context = context;
        }
        public JobModel createJob(JobModel job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return job;
        }

        public bool deleteJob(JobModel job)
        {
            var existingJob = _context.Jobs.Find(job.JobId);
            if (existingJob != null)
            {
                _context.Jobs.Remove(existingJob);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public JobModel getJobByJobId(int jobId)
        {
            return _context.Jobs.Find(jobId);
        }

        public List<JobModel> getJobs()
        {
            return _context.Jobs.ToList();
        }

        public bool updateJob(JobModel job)
        {
 var existingJob = _context.Jobs.Find(job.JobId);
            if (existingJob != null)
            {
                existingJob.JobTitle = job.JobTitle;
                existingJob.Description = job.Description;
                existingJob.City = job.City;
                _context.SaveChanges();
                return true;
            }
            return false;        }
    }
}
