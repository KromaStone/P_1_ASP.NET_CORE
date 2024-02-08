using Employee_With_JWT.Identity;
using Employee_With_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_With_JWT.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_context.employees.ToList());
        }
        [HttpPost]
        public IActionResult SaveEmployee([FromBody]Employee employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _context.employees.Add(employee);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (ModelState.IsValid) return BadRequest(employee);
            _context.employees.Update(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.employees.Find(id);
            if (employeeInDb == null) return NotFound();
            _context.employees.Remove(employeeInDb);
            _context.SaveChanges();
            return Ok(employeeInDb);
        }
    }
}
