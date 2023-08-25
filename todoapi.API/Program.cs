using Microsoft.EntityFrameworkCore;
using todoapi.API.Services;
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

builder.Services.RegisterModules();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapEndpoints();



app.Run();

