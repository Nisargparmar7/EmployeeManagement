using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewComponents
{
    public class AddJobViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new JobModel()); // Pass an empty JobModel to the view
        }
    }
}
