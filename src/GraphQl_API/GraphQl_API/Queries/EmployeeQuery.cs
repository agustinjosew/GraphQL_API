

using GraphQL;
using GraphQl_API.Services.Interfaces;
using GraphQL.Types;
using static GraphQl_API.Models.EmployeeModel;

namespace GraphQl_API.Queries;

public class EmployeeQuery :ObjectGraphType
{
    public EmployeeQuery(IEmployeeService employeeService){
        // mapping against EmployeeService methods to fetch data
        Field<ListGraphType<EmployeeDetailsType>>(Name = "Employees", 
            resolve : x => employeeService.GetEmployees());
        
        Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee", 
            arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
            resolve: x => employeeService.GetEmployee(x.GetArgument<int>("id")));
    }
}

/// <summary>
///  Map the Employee query (EmployeeQuery) class to the GraphQL
///  schema by creating a class (EmployeeDetailsSchema) that inherits Schema.
/// </summary>
public class EmployeeDetailsSchema : Schema
{
    public EmployeeDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
        Query = serviceProvider.GetRequiredService<EmployeeQuery>();
    }
}