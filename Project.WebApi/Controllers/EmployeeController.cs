using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.WebApi.Dtos;
using Project.WebApi.Interfaces;
using Project.WebApi.Models;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] EmployeeDto employee)
            => Ok(await  employeeRepository.CreateAsync(employee));

        [HttpDelete]
        public async Task<IActionResult> DeepDeleteAsync([FromForm] int id)
            => Ok(await employeeRepository.DeepDeletedAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
            => Ok(await employeeRepository.GetAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] EmployeeDto employeeDto, int id)
            => Ok(await employeeRepository.UpdateAsync(id, employeeDto));
    }
}
    