using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Data;
using UserManagement.WebHost.Models;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!, o =>
   {
       o.MigrationsAssembly(typeof(Program).Assembly.FullName);
       o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
   }));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
