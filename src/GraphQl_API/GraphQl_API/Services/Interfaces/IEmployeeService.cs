using GraphQl_API.Models;

namespace GraphQl_API.Services.Interfaces;

public interface IEmployeeService
{
    public List<EmployeeModel.EmployeeDetails> GetEmployees();
    public List<EmployeeModel.EmployeeDetails> GetEmployee(int empId);
    public List<EmployeeModel.EmployeeDetails> GetEmployeesByDepartment(int deptId);
}