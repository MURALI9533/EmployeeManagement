using EmployeeManagement.Models;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteByIdAsync(int id);   
        Task AddEmployeeAsync(Employee employee);
    }
}
