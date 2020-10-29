using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poke.API.Business;
using Poke.API.Models;

namespace Poke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;
        //private readonly IDemoValidatorBusinees _demoValidator;

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
        [HttpGet("storedprocedure/id/{employeeid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] string employeeid)
        {
            var employee = await _employeeBusiness.GetEmpoyeeById(employeeid);
            return Ok(employee);
        }

        [HttpGet("validator")]
        public IActionResult getDemoValidator([FromQuery] Request request )
        {
            return Ok(request);
        }
        
    }
}