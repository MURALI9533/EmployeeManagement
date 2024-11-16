using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class AppDBContext:DbContext

    {
        public DbSet<Employee> Employees { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }
    }
}
