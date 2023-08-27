using AutoMapper;
using EmployeeTestProject.DTO.Request;
using EmployeeTestProject.DTO.Response;
using EmployeeTestProject.Models;
using EmployeeTestProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTestProject.Repository.Services
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EmployeeResponseDto>> GetEmployees()
        {
            try
            {
                return await (from emp in _dataContext.Employee where emp.IsActive == true 
                       join empaddr in _dataContext.EmployeeAddress on emp.EmployeeId equals empaddr.EmployeeId into g
                       from result in g.DefaultIfEmpty()
                       select new EmployeeResponseDto()
                       {
                           EmployeeId = emp.EmployeeId,
                           FirstName = emp.FirstName,
                           LastName = emp.LastName,
                           Age = emp.Age,
                           Email = emp.Email,
                           EmployeeAddressId = result.EmployeeAddressId,
                           Address1 = result.Address1,
                           Address2 = result.Address2,
                           City = result.City,
                           State = result.State,
                           Country = result.Country,
                           ZipCode = result.ZipCode                     
                       }).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ResponseDto> AddEmployee(EmployeeRequestDto request)
        {
            try
            {
                var empID = Guid.NewGuid();
                Employee employee = new()
                {
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    Age = request.Age,
                    CreatedTs = DateTime.UtcNow,
                    Email = request.Email,
                    EmployeeId = empID,
                    IsActive = true
                };

                EmployeeAddress employeeAddress = new()
                {
                    IsActive = true,
                    EmployeeId = empID,
                    Address1 = request.Address1,
                    Address2 = request.Address2,
                    City = request.City,
                    Country = request.Country,
                    CreatedTs = DateTime.UtcNow,
                    EmployeeAddressId = Guid.NewGuid(),
                    State = request.State,
                    ZipCode = request.ZipCode
                };

                _dataContext.Employee.Add(employee);
                _dataContext.EmployeeAddress.Add(employeeAddress);
                await _dataContext.SaveChangesAsync();
                return new ResponseDto()
                {
                    Message = "Employee Details saved successfully",
                    Status = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseDto> UpdateEmployee(EmployeeUpdateRequestDto request)
        {
            try
            {
                var employee = await _dataContext.Employee.FirstOrDefaultAsync(x => x.EmployeeId == request.EmployeeId);
                if(employee is null)
                {
                    throw new KeyNotFoundException("Employee Id not found!");
                }
                var employeeAddr = await _dataContext.EmployeeAddress.FirstOrDefaultAsync(x => x.EmployeeAddressId == request.EmployeeAddressId);


                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.Email = request.Email;
                employee.Age = request.Age;

                if(employeeAddr is not null)
                {
                    employeeAddr.State = request.State;
                    employeeAddr.Address1 = request.Address1;
                    employeeAddr.Address2 = request.Address2;
                    employeeAddr.City = request.City;
                    employeeAddr.Country = request.Country;
                    employeeAddr.ZipCode = request.ZipCode;
                    _dataContext.Update(employeeAddr);
                }
                _dataContext.Update(employee);
                _dataContext.SaveChanges();
                return new ResponseDto()
                {
                    Message = "Employee updated successfully",
                    Status = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseDto> DeleteEmployee(Guid EmpId)
        {
            try
            {
                var employee = await _dataContext.Employee.FirstOrDefaultAsync(x => x.EmployeeId == EmpId);
                if(employee is null)
                {
                    throw new KeyNotFoundException("Employee Id not found!");
                }
                var employeeAddr = await _dataContext.EmployeeAddress.FirstOrDefaultAsync(x => x.EmployeeId == EmpId);
                employee.IsActive = false;
                employeeAddr.IsActive = false;
                _dataContext.Update(employeeAddr);
                _dataContext.Update(employee);
                _dataContext.SaveChanges();
                return new ResponseDto()
                {
                    Message = "Employee Deleted successfully",
                    Status = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
    }
}
