using EmployeeTestProject.Models;

namespace EmployeeTestProject.DTO.Response
{
    public class EmployeeDetailResponseDto
    {
        public Employee Employee { get; set; }
        public EmployeeAddress EmployeeAddress { get; set; }
    }
}
