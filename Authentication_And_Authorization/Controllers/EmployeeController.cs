using Authentication_And_Authorization.Models;
using Authentication_And_Authorization.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_And_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeService)
        {
            _employeeService = employeService;
        }

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public ActionResult GetEmployee(string id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee != null)
                return Ok(employee);
            else
                return Ok();
        }


        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            var emp = _employeeService.AddEmployee(employee);
            return Ok(emp);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Employee employee)
        {
            var emp = _employeeService.UpdateEmployee(employee);
            return Ok(emp);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                var result = _employeeService.DeleteEmployee(id);
                return Ok(result);
            }
            catch
            {
                return Ok();
            }
        }
    }
}
