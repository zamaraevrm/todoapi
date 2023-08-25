using todoapi.API.Services;
using todoapi.Application.Repositories;
using todoapi.Domain.Entities;
using todoapi.Infrastructure.Repositories;

namespace todoapi.API.APIs;

public class TodoApi : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("todos", async (Todo todo, ITodoRepository todoRepository) => await todoRepository.AddAsync(todo));
        endpoints.MapGet("todos/{id}", async (Guid id, ITodoRepository todoRepository) => await todoRepository.GetByIdAsync(id));
        endpoints.MapGet("todos", async (ITodoRepository todoRepository) => await todoRepository.GetAllAsync());
        endpoints.MapPut("todos", async (Todo todo, ITodoRepository todoRepository) => await todoRepository.UpdateAsync(todo));
        endpoints.MapDelete("todos/{id}", async (Guid Id, ITodoRepository todoRepositry) => await todoRepositry.DeleteAsync(Id));
        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection builder)
    {
        builder.AddScoped<ITodoRepository, TodoRepository>();
        return builder;
    }
}
