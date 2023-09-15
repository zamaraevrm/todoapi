using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoapi.Domain.Entities;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;   
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public PersonRole Role { get; set; }

    public ICollection<Todo> todos { get; set; } = new List<Todo>();
}
