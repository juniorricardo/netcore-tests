using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poke.API.Business;
using Poke.API.Entities;

namespace Poke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }
        
        [HttpGet("query")]
        public async Task<IActionResult> GetEmployeeByQuery()
        {
            var response = await _employeeBusiness.GetEmployeePerQuery();
            return Ok(response);
        }

        [HttpGet("storedprocedure")]
        public async Task<IActionResult> GetEmployeeByPs()
        {
            var response = await _employeeBusiness.GetEmployeesPerPs();
            return Ok(response);
        }

        // Buscar cliente
        //    si existe traer datos con join, numero de cuenta bancaria y datos personales 
        [HttpGet("employeeid/{employeeid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] string id)
        {
            var employee = await _employeeBusiness.GetEmpoyeeById(id);
            return Ok(employee);
        }
        
    }
}