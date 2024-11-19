using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController :ControllerBase
    {
        private readonly IEmployeeRepository _employeerepository;
        public EmployeeController(IEmployeeRepository employeeRepository) { 
            _employeerepository = employeeRepository;
        }
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            await _employeerepository.AddEmployeeAsync(employee);
            return Created();
        }
        [HttpGet]

        //Task is used to represent an asynchronous operation.In web applications, operations like database queries (e.g., fetching employees) can take time, so we use Task to ensure the method doesn't block the execution thread while waiting for the database operation to complete.
        //Task helps to keep the application responsive and scalable, allowing it to handle multiple requests concurrently without waiting for long-running operations (like database or I/O operations) to finish.

        //ActionResult is used to allow flexible HTTP status code management in the response.It lets you return not only the data (like IEnumerable<Employee>) but also appropriate HTTP status codes(e.g., 200 OK, 404 Not Found, 500 Internal Server Error).
        //Using ActionResult makes the API more informative and standardized because you can return a clear status code and data, which is essential for clients to handle the response correctly.
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _employeerepository.GetAllAsync());
        }
    }
}
