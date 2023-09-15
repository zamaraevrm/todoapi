namespace todoapi.Domain.Entities;
public class Todo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Body { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
    public Person Person { get; set; } = default!;

    public Guid PersonId { get; set; } = Guid.Empty;
}