using System.ComponentModel.DataAnnotations;

namespace EmployeeTestProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTs { get; set; }
    }
}
