using Entity.Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Project.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Users> Users { get; set; }
}
