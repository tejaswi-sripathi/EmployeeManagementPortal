using EmployeeManagementPortal.Data;
using EmployeeManagementPortal.Repositories;
using EmployeeManagementPortal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        // In Development allow any origin for easier local frontend testing.
        // In Production restrict to known frontend origins.
        if (builder.Environment.IsDevelopment())
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
        else
        {
            policy.WithOrigins("http://localhost:5173","https://employee-management-portal-frontend-a5dkgzn41.vercel.app")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    });
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

// Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Service
builder.Services.AddScoped<EmployeeService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable CORS
app.UseCors("ReactPolicy");

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();