using Authentication_And_Authorization.Context;
using Authentication_And_Authorization.Models;
using Authentication_And_Authorization.Services.Interface;

namespace Authentication_And_Authorization.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtContext _context;

        public EmployeeService(JwtContext context)
        {
            _context = context;
        }
        public Employee? AddEmployee(Employee employee)
        {
            try
            {
                var entity = _context.Employee.Add(employee);
                _context.SaveChanges();
                return entity.Entity;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex);
            }
            return null;
        }

        public bool DeleteEmployee(string employeeId)
        {
            try
            {
                var entity = _context.Employee.Find(employeeId);
                if (entity != null)
                {
                    _context.Employee.Remove(entity);
                    _context.SaveChanges();
                    return true;
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public Employee? GetEmployee(string employeeId)
        {
            try
            {
                var entity = _context.Employee.Find(employeeId);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                var entities = _context.Employee.ToList();
                return entities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new List<Employee>();
        }

        public Employee? UpdateEmployee(Employee employee)
        {
            try
            {
                var entity = _context.Employee.Update(employee);
                _context.SaveChanges();
                return entity.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
