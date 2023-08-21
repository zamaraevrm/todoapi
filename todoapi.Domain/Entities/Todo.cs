namespace todoapi.Domain.Entities;
public class Todo
{
    public Guid Id { get; set; } = default!;
    public string Body { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
}