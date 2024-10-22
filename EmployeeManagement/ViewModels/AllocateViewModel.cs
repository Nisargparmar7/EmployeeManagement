using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class AllocateViewModel
    {
        public List<UserModel> users { get; set; }
        public List<JobModel> jobs { get; set; }
    }
}
