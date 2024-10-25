using Authentication_And_Authorization.Models;

namespace Authentication_And_Authorization.Services.Interface
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee? GetEmployee(string employeeId);
        Employee? AddEmployee(Employee employee);
        Employee? UpdateEmployee(Employee employee);
        bool DeleteEmployee(string employeeId);

    }
}
