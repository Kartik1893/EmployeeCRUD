using EmployeeTestProject.DTO.Request;
using EmployeeTestProject.Models;
using EmployeeTestProject.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _iEmployeeService;

        public EmployeeController(IEmployeeRepository iEmployeeService)
        {
            _iEmployeeService = iEmployeeService;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {
                var result = await _iEmployeeService.GetEmployees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeRequestDto employee)
        {
            try
            {
                var result = await _iEmployeeService.AddEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateRequestDto employee)
        {
            try
            {
                var result = await _iEmployeeService.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Guid employeeId)
        {
            try
            {
                var result = await _iEmployeeService.DeleteEmployee(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
