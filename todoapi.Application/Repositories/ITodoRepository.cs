using todoapi.Domain.Entities;

namespace todoapi.Application.Repositories;

public interface ITodoRepository
{
    public Task<Todo> GetByIdAsync(Guid id);

    public Task<IReadOnlyList<Todo>> GetAllAsync();

    public Task AddAsync(Todo item);

    public Task UpdateAsync(Todo item);

    public Task DeleteAsync(Guid id);
}
