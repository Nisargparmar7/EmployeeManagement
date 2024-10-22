using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    // Enum to represent user roles
    public enum UserRole
    {
        Manager,
        Employee
    }

    public class UserModel
    {
        // Unique identifier for the user
        [Key] // This attribute indicates that this property is the primary key
        public int UserId { get; set; }

        // User's login name
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        // User's full name
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

        // User's email address
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        // User's role (Manager or Employee)
        [Required(ErrorMessage = "Role is required.")]
        public UserRole Role { get; set; } // Using the UserRole enum for better type safety

        // User's password
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
