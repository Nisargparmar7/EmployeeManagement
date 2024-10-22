using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class AllocationModel
    {
        [Key] 
        public int AllocationId { get; set; }

        [Required(ErrorMessage = "Staff ID is required.")]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Job ID is required.")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}
