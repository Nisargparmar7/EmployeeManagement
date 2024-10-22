using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class JobModel
    {
        // Unique identifier for the job
        [Key] // This attribute indicates that this property is the primary key
        public int JobId { get; set; }

        // Title of the job
        [Required(ErrorMessage = "Job title is required.")]
        public string JobTitle { get; set; }

        // Description of the job
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        // City where the job is located
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}
