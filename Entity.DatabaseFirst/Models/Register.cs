using System;
using System.Collections.Generic;

namespace Entity.DatabaseFirst.Models;

public partial class Register
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
