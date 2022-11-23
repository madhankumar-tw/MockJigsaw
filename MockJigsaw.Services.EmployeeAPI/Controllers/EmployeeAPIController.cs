using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;
using MockJigsaw.Services.EmployeeAPI.Repository;

namespace MockJigsaw.Services.EmployeeAPI.Controllers;

[Route("api/employees")]
public class EmployeeAPIController : ControllerBase
{
    private readonly EmployeeResponseDto _response;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeAPIController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        this._response = new EmployeeResponseDto();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<object> Get()
    {
        try
        {
            var employeeDtos = await _employeeRepository.GetEmployees();
            _response.Result = employeeDtos;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin,Employee",AuthenticationSchemes = "Employee")]
    [Route("{employeeId}")]
    public async Task<object> Get(long employeeId)
    {
        try
        {
            var employeeDto = await _employeeRepository.GetEmployeeById(employeeId);
            if (employeeDto == null)
            {
                throw new Exception("The employeeId was not found in the database");
            }
            _response.Result = employeeDto;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<object> Post([FromBody] EmployeeDto employeeDto)
    {
        try
        {
            var res = await _employeeRepository.UpdateEmployee(employeeDto);
            _response.Result = res;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<object> Put([FromBody] EmployeeDto employeeDto)
    {
        try
        {
            var res = await _employeeRepository.CreateEmployee(employeeDto);
            _response.Result = res;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<object> Delete(long employeeId)
    {
        try
        {
            var isSuccess = await _employeeRepository.DeleteEmployee(employeeId);
            _response.Result = isSuccess;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
}