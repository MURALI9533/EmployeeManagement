using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDBContext>(
    Options =>
    {
        Options.UseInMemoryDatabase("EmployeeDb");
    }
    );
builder.Services.AddCors(options =>
{
    options.AddPolicy("Mycros", builder =>
    {
        builder.WithOrigins("http//localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });

}
    );
// Registers the EmployeeRepository as the implementation of IEmployeeRepository with a scoped lifetime.
// A new instance of EmployeeRepository will be created once per HTTP request.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            c.RoutePrefix = string.Empty;
        }
        );
}
app.MapControllers();
app.Run();
