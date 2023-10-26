using Project.WebApi.Enums;

namespace Project.WebApi.Dtos;

public class EmployeeDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Status Status { get; set; }
    public Role Role { get; set; }
}
