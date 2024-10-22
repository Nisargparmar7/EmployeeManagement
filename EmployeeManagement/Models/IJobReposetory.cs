using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IJobReposetory
    {
        public JobModel createJob(JobModel job);

        public bool deleteJob(JobModel job);

        public JobModel getJobByJobId(int jobId);

        public List<JobModel> getJobs();

        public bool updateJob(JobModel job);
    }
}
