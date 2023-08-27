using EmployeeTestProject.DTO.Request;
using EmployeeTestProject.DTO.Response;
using EmployeeTestProject.Models;

namespace EmployeeTestProject.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeResponseDto>> GetEmployees();
        Task<ResponseDto> AddEmployee(EmployeeRequestDto request);
        Task<ResponseDto> UpdateEmployee(EmployeeUpdateRequestDto employee);
        Task<ResponseDto> DeleteEmployee(Guid EmpId);
    }
}
