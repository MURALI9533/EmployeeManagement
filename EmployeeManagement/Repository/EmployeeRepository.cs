using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _dbContext;
        public EmployeeRepository(AppDBContext context) { 
            _dbContext = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var employeeObj= await _dbContext.Employees.FindAsync(id);
            if (employeeObj != null)
            {
                _dbContext.Employees.Remove(employeeObj);
            }
            //_dbContext.Employees.
           await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Update(employee);
             await _dbContext.SaveChangesAsync();
        }
    }
}
