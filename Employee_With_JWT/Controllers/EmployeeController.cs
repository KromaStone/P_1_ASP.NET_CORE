using Employee_With_JWT.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_With_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(_context.employeeRoles.ToList());
        }
    }
}
