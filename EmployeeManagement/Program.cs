using EmployeeManagement.Data;
using EmployeeManagement.Models;
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
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
