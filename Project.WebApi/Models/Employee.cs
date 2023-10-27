using Project.WebApi.Enums;

namespace Project.WebApi.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Login { get ; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string Role { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime Deleted { get; set; }
}
