using EmployeesAPI.Interfaces;
using EmployeesAPI.Repositories;
using EmployeesAPI.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//allows calls from angularui 
builder.Services.AddCors(options => options.AddPolicy(name: "FrontEndUI",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        }
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("FrontEndUI");
app.Run();
