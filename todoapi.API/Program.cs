using Microsoft.EntityFrameworkCore;
using todoapi.Application.Repositories;
using todoapi.Domain.Entities;
using todoapi.Infrastruckture;
using todoapi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();


app.MapPost("todos", async (Todo todo, ITodoRepository todoRepository) => await todoRepository.AddAsync(todo));

app.MapGet("todos/{id}", async (Guid id, ITodoRepository todoRepository) => await todoRepository.GetByIdAsync(id));

app.MapGet("todos", async (ITodoRepository todoRepository) => await todoRepository.GetAllAsync());

app.MapPut("todos", async (Todo todo, ITodoRepository todoRepository) => await todoRepository.UpdateAsync(todo));

app.MapDelete("todos/{id}", async (Guid Id, ITodoRepository todoRepositry) => await todoRepositry.DeleteAsync(Id));

app.Run();

