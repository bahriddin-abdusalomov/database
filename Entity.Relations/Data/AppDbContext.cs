using Entity.Relations.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Relations.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonCars> PersonCars { get; set; }
    }
}
