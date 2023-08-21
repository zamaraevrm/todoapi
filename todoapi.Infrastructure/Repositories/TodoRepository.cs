using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoapi.Application.Repositories;
using todoapi.Domain.Entities;
using todoapi.Infrastruckture;

namespace todoapi.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{

    private AppDbContext _appDbContext;

    public TodoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(Todo item)
    {
        await _appDbContext.Todos.AddAsync(item);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        _appDbContext.Todos.Remove(await _appDbContext.Todos.Where(todo => todo.Id == id).FirstAsync());
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Todo>> GetAllAsync()
    {
        return await _appDbContext.Todos.ToListAsync();
    }

    public async Task<Todo> GetByIdAsync(Guid id)
    {
        return await _appDbContext.Todos.Where(todo => todo.Id == id).FirstAsync();
    }

    public async Task UpdateAsync(Todo item)
    {
        _appDbContext.Todos.Update(item);
        await _appDbContext.SaveChangesAsync();
    }


}
