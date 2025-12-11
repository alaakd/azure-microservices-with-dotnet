using Microsoft.EntityFrameworkCore;
using Wpm.Management.Api.DataAccess;
using Swashbuckle.AspNetCore.SwaggerGen; // Add this using directive
using Swashbuckle.AspNetCore.SwaggerUI;  // Add this using directive
using Swashbuckle.AspNetCore.Swagger;    // Add this using dir

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ManagementDbContext>(options =>
{
    options.UseInMemoryDatabase("WpmManagement");
});

var app = builder.Build();

app.EnsureDbIsCreated();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();