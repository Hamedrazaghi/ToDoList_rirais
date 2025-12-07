using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Services.IServices;
using ToDoList.Application.Services;
using ToDoList.Domain.IRepository;
using ToDoList.Infrastucture.Context;
using ToDoList.Infrastucture.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add controller
builder.Services.AddControllers();

// swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DbContext DI
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repository and Service DI
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();


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

app.Run();
