using System;
using System.Collections.Generic;

namespace Entity.DatabaseFirst.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Status { get; set; }

    public string? Role { get; set; }

    public string? Created { get; set; }

    public string? Updated { get; set; }

    public string? Deleted { get; set; }
}
