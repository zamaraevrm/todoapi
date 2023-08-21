using Microsoft.EntityFrameworkCore;
using todoapi.Domain.Entities;

namespace todoapi.Infrastruckture;
public class AppDbContext: DbContext{

    public AppDbContext(DbContextOptions options) : base(options) { } 

    public DbSet<Todo> Todos { get; set; } = default!;
}