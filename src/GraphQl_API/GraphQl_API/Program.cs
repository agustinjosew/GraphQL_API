using GraphQL;
using GraphQl_API.Models;
using GraphQl_API.Queries;
using GraphQl_API.Services;
using GraphQl_API.Services.Interfaces;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<EmployeeModel.EmployeeDetailsType>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<ISchema, EmployeeDetailsSchema>();

// GraphQL
builder.Services.AddGraphQL(b =>
{
    b.AddAutoSchema<EmployeeQuery>(); // this is the schema
    b.AddSystemTextJson(); // this is the serializer
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//graphQL endpoints
app.UseGraphQL<ISchema>("/graphql");
app.UseGraphQLPlayground(
    "/",
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
      GraphQLEndPoint  = "/graphql",
      SubscriptionsEndPoint = "/graphql",
    });

app.Run();