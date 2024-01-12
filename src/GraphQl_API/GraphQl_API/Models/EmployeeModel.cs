namespace GraphQl_API.Models;

public class EmployeeModel
{
    /// <summary>
    /// Employee
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="Age"></param>
    /// <param name="DeptId"></param>
    public record Employee(int Id, string Name, int Age, int DeptId);
    
    
    
}