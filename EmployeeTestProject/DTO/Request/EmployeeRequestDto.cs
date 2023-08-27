using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTestProject.DTO.Request
{
    public class EmployeeRequestDto
    {
        [Required (ErrorMessage ="First Name is required")]
        public string? FirstName { get; set; }

        [Required (ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required (ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required (ErrorMessage = "Email is required")]
        [Email(ErrorMessage = "Email is not in correct format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        public string? Address1 { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        public string? Address2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        [Required (ErrorMessage = "State is required")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]
        public string? ZipCode { get; set; }
    }
}
