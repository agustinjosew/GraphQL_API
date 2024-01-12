using GraphQL.Types;

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

    /// <summary>
    /// Department
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    public record Department(int Id, string Name);

   /// <summary>
   /// EmployeeDetails
   /// </summary>
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? DeptName { get; set; }
    }

   /// <summary>
   /// Employee details type
   /// </summary>
    public class EmployeeDetailsType : ObjectGraphType<EmployeeDetails>
    {
        // EmployeeDetails is the model for API response but graphQL can’t understand this hence we need to create a mapping and as a result,
        // we create EmployeeDetailsType Field mapping class.
        public EmployeeDetailsType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Age);
            Field(x => x.DeptName);
            
        }
    }
    
}